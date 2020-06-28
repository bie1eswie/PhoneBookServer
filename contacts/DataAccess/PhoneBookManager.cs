using contacts.ErrorLogging;
using contacts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace contacts.DataAccess
{
		public class PhoneBookManager : IPhoneBookManager
		{
				private readonly ContactContext _contactContext;
				private readonly ILoggerManager _logger;

				public PhoneBookManager(ContactContext contactContext, ILoggerManager logger)
				{
						_contactContext = contactContext;
						_logger = logger;
				}
				public bool AddContact(Contact contact)
				{
						try
						{
								_contactContext.Contacts.Add(contact);
										return _contactContext.SaveChanges() > 0;
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return false;
						}
				}

				public bool DeleteContact(int id)
				{
						try
						{
										var contact = _contactContext.Contacts.FirstOrDefault(x => x.id == id);
										if (contact != null)
										{
										_contactContext.Contacts.Remove(contact);
										}
										return _contactContext.SaveChanges() > 0;
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return false;
						}
				}

				public List<PhoneBook> GetAllContacts()
				{
						try
						{
									var item = (from a in _contactContext.PhoneBooks
														 select a).Include(x=>x.Contacts);
								return item.ToList();
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return null;
						}
				}

				public Contact GetContact(int id)
				{
						try
						{
										return _contactContext.Contacts.FirstOrDefault(x=>x.id==id);
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return null;
						}
				}

				public PhoneBook GetPhoneBook(int phoneBookID)
				{
						throw new NotImplementedException();
				}

				public bool UpdateContact(Contact contact)
				{
						try
						{
								_contactContext.Contacts.Update(contact);
										return _contactContext.SaveChanges() > 0;
						}
						catch (Exception ex)
						{
								_logger.LogFatal(ex);
								return false;
						}
				}
		}
}
