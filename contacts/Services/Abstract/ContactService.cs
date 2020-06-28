using contacts.DataAccess;
using contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contacts.Services.Abstract
{
		public class ContactService : IContactService
		{
				private readonly IPhoneBookManager _phoneBookManager;
				public ContactService(IPhoneBookManager phoneBookManager)
				{
						_phoneBookManager = phoneBookManager;
				}
				public bool AddContact(Contact contact)
				{
						return _phoneBookManager.AddContact(contact);
				}

				public bool DeleteContact(int id)
				{
						return _phoneBookManager.DeleteContact(id);
				}

				public List<PhoneBook> GetAllContacts()
				{
						return _phoneBookManager.GetAllContacts();
				}

				public PhoneBook GetPhoneBook(int phoneBook)
				{
						return _phoneBookManager.GetPhoneBook(phoneBook);
				}

				public Contact GetContact(int id)
				{
						return _phoneBookManager.GetContact(id);
				}

				public bool UpdateContact(Contact contact)
				{
						return _phoneBookManager.UpdateContact(contact);
				}
		}
}
