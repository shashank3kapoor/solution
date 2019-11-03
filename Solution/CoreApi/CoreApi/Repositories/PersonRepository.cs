using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CoreApi.Interfaces;
using CoreApi.Models;

namespace CoreApi.Repositories {
	public class PersonRepository : BaseRepository, IPersonRepository {

		public PersonRepository () {
			fileName = "Person.txt";
		}

		public bool AddPerson(Person person) {
			try {
				IList<Person> persons = this.GetAll();
				persons.Add (person);

				string json = JsonSerializer.Serialize (persons);
				File.WriteAllText (Path.Combine (docPath, this.fileName), json);
				return true;
			}
			catch (Exception) {
				return false;
			}
		}

		public IList<Person> GetAll() {
			List<Person> persons = new List<Person> ();
			String line;
			if (this.FileExists ()) {
				using (StreamReader sr = new StreamReader (Path.Combine (docPath, fileName))) {
					line = sr.ReadToEnd ();
				}
				persons = JsonSerializer.Deserialize<List<Person>> (line);
			}

			return persons;
		}

		private bool FileExists() {
			return File.Exists (Path.Combine (docPath, this.fileName)) ? true : false;
		}
	}
}
