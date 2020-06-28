using contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contacts.DataAccess
{
		public interface IPhoneBookManager
		{
				public bool AddContact(Contact contact);
				public bool DeleteContact(int id);
				public bool UpdateContact(Contact contact);
				public List<PhoneBook> GetAllContacts();
				public Contact GetContact(int id);
				public PhoneBook GetPhoneBook(int phoneBookID);
		}
}
