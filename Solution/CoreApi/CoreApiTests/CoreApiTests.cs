using System.Collections;
using System.Collections.Generic;
using CoreApi.Controllers;
using CoreApi.Interfaces;
using CoreApi.Models;
using CoreApi.Repositories;
using CoreApi.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CoreApiTests
{
    [TestFixture]
    public class Tests
    {
		public Mock<IPersonRepository> mockPersonRepository = new Mock<IPersonRepository> ();
		public static IPersonRepository personRepository = new PersonRepository ();
		public static IPerson personService = new PersonService (personRepository);
		public Mock<IPerson> mockPersonService = new Mock<IPerson> ();
		public PersonController personController = new PersonController (personService);

		[SetUp]
		public void Setup() {
			IList<Person> persons = new List<Person> ();
			persons.Add (new Person {
				firstName = "First",
				lastName = "Last"
			});
			mockPersonRepository.Setup (mpr => mpr.GetAll ())
				.Returns (persons);
		}

		[Test]
		public void Verify_PersonRepository() {
			Person person = new Person {
				firstName = "One",
				lastName = "Two"
			};
			bool personSaved = personRepository.AddPerson (person);
			var persons = personRepository.GetAll ();
			Person personAdded = persons [persons.Count - 1];

			Assert.That (personSaved, Is.EqualTo (true));
			Assert.That (persons.Count, Is.GreaterThan(0));
			Assert.That (personAdded.firstName, Is.EqualTo("One"));
			Assert.That (personAdded.lastName, Is.EqualTo ("Two"));
		}

		[Test]
		public void Verify_PersonService() {
			mockPersonRepository.Setup (mpr =>
				mpr.AddPerson (It.IsAny<Person> ())).Returns (true);

			Person person = new Person {
				firstName = "One",
				lastName = "Two"
			};
			bool result = personService.AddPerson (person);
			var persons = personService.GetAll ();

			Assert.That (result, Is.EqualTo (true));
			Assert.That (persons.Count, Is.GreaterThan(0));
		}

		[Test]
		public void Verify_PersonController() {
			var persons = personController.Get ();

			Person person = new Person {
				firstName = "One",
				lastName = "Two"
			};
			var result = personController.Post (person);

			Assert.That (persons.Count, Is.GreaterThan(0));
			Assert.That (result, Is.EqualTo (true));
		}
    }
}