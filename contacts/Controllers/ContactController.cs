using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contacts.ErrorLogging;
using contacts.Helpers;
using contacts.Models;
using contacts.Services.Abstract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace contacts.Controllers
{
		[Route("api/[controller]")]
		public class ContactController : Controller
		{
				private readonly IContactService _contactService;
				private readonly ILoggerManager _logger;
				public ContactController(IContactService contactService, ILoggerManager logger)
				{
						_contactService = contactService;
						_logger = logger;
				}
				[HttpPost("addNewContact")]
				public IActionResult AddNewContact([FromBody] Contact contact)
				{
						GenericResult _result = new GenericResult();
						try
						{
								var result = _contactService.AddContact(contact);
								if (result == true)
								{
										return Json(new { result = result, Message = "Contact added successfully" });
								}
								else
								{
										throw new Exception("There was a problem adding the contact");
								}
						}
						catch (Exception ex)
						{
								_result = new GenericResult()
								{
										Succeeded = false,
										Message = ex.Message
								};

								_logger.LogFatal(ex);
								return Json(_result);
						}
				}
				[HttpPut("updateContact")]
				public IActionResult UpdateContact([FromBody] Contact contact) 
				{
						GenericResult _result = new GenericResult();
						try
						{
								var result = _contactService.UpdateContact(contact);
								if (result == true)
								{
										return Json(new { result = result, Message = "Contact updated successfully" });
								}
								else
								{
										throw new Exception("There was a problem updating the contact");
								}
						}
						catch (Exception ex)
						{
								_result = new GenericResult()
								{
										Succeeded = false,
										Message = ex.Message
								};

								_logger.LogFatal(ex);
								return Json(_result);
						}
				}
				
				public IActionResult Delete(int id)
				{
						GenericResult _result = new GenericResult();
						try
						{
								var result = _contactService.DeleteContact(id);
								if (result == true)
								{
										return Json(new { result, Message = "Contact deleted successfully" });
								}
								else
								{
										throw new Exception("There was a problem deleting the contact");
								}
						}
						catch (Exception ex)
						{
								_result = new GenericResult()
								{
										Succeeded = false,
										Message = ex.Message
								};

								_logger.LogFatal(ex);
								return Json(_result);
						}
				}
				[HttpGet("getContacts")]
				public IActionResult	GetContacts()
				{
						GenericResult _result = new GenericResult();
						try
						{
								var result = _contactService.GetAllContacts();
								if (result !=null)
								{
										return Json(new { result });
								}
								else
								{
										throw new Exception("There was a problem getting contacts");
								}
						}
						catch (Exception ex)
						{
								_result = new GenericResult()
								{
										Succeeded = false,
										Message = ex.Message
								};

								_logger.LogFatal(ex);
								return Json(_result);
						}
				}
				[HttpGet("{id}")]
				public IActionResult Get(int id)
				{
						GenericResult _result = new GenericResult();
						try
						{
								var result = _contactService.GetContact(id);
								if (result != null)
								{
										return Json(new { result });
								}
								else
								{
										throw new Exception("There was a problem getting the contact");
								}
						}
						catch (Exception ex)
						{
								_result = new GenericResult()
								{
										Succeeded = false,
										Message = ex.Message
								};

								_logger.LogFatal(ex);
								return Json(_result);
						}
				}
		}
}
