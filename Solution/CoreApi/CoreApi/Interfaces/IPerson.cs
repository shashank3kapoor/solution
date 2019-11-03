using System.Collections.Generic;
using CoreApi.Models;

namespace CoreApi.Interfaces {
	public interface IPerson {
		bool AddPerson (Person person);
		IList<Person> GetAll ();
	}
}
