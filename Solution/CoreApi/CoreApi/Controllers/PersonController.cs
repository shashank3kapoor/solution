using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Interfaces;
using CoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreApi.Controllers {
	[ApiController]
	[Route ("api/[controller]")]
	public class PersonController : ControllerBase {
		private IPerson personService;

		public PersonController (IPerson personService
			) {
			this.personService = personService;
		}

		[HttpGet]
		public IList<Person> Get() {
			return this.personService.GetAll();
		}

		[HttpPost]
		public bool Post([FromBody] Person person) {
			return this.personService.AddPerson (person);
		}
	}
}
