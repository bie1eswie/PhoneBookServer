using System;
using System.IO;
using contacts.DataAccess;
using contacts.ErrorLogging;
using contacts.Models;
using contacts.Services.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;

namespace contacts
{
		public class Startup
		{
				public Startup(IConfiguration configuration, IWebHostEnvironment env)
				{
						var builder = new ConfigurationBuilder()
							 .SetBasePath(env.ContentRootPath)
							 .AddJsonFile("appsettings.json");

						Configuration = builder.Build();
				}

				public IConfiguration Configuration { get; }

				// This method gets called by the runtime. Use this method to add services to the container.
				public void ConfigureServices(IServiceCollection services)
				{
						services.AddCors(options =>
						{
								options.AddPolicy(name: "CorsPolicy",
																	builder =>
																	{
																			builder.AllowAnyOrigin()
																			.AllowAnyHeader()
																			.AllowAnyMethod();
																	});
						});

						LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
						services.AddControllers();
						var connection = Configuration.GetConnectionString("PhoneBook_Application");
						services.AddDbContext<ContactContext>(options => options.UseSqlServer(connection));

						services.AddControllersWithViews();
						services.AddControllers().AddNewtonsoftJson();

						// Services
						services.AddScoped<IPhoneBookManager, PhoneBookManager>();
						services.AddScoped<IContactService, ContactService>();
						services.AddScoped<ILoggerManager, LoggerManager>();
				}

				// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
				public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
				{
						if (env.IsDevelopment())
						{
								app.UseDeveloperExceptionPage();
						}


						//app.UseHttpsRedirection();

						app.UseRouting();
						
						app.UseCors("CorsPolicy");

						app.UseAuthorization();


						app.UseEndpoints(endpoints =>
						{
								endpoints.MapControllers();
						});
				}
		}
}
