using System.Collections.Generic;
using CoreApi.Interfaces;
using CoreApi.Models;

namespace CoreApi.Services {
	public class PersonService : IPerson {
		private IPersonRepository personRepository;

		public PersonService (IPersonRepository personRepository) {
			this.personRepository = personRepository;
		}

		public bool AddPerson (Person person) {
			return personRepository.AddPerson (person);
		}

		public IList<Person> GetAll() {
			return personRepository.GetAll ();
		}
	}
}
