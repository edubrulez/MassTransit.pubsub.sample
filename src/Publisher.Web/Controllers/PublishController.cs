using System;
using System.Web.Mvc;
using Messages;
using Publisher.Domain;
using Publisher.Models;

namespace Publisher.Controllers
{
	public class PublishController : Controller
	{
		private readonly IPublishAbstraction _publishAbstraction;

		public PublishController(IPublishAbstraction publishAbstraction)
		{
			_publishAbstraction = publishAbstraction;
		}

		[HttpGet]
		public ActionResult UpdateEmployee()
		{
			return View(new Employee
				{
					FirstName = "first",
					LastName = "last"
				});
		}

		[HttpPost]
		public ActionResult UpdateEmployee(Employee employee)
		{
			_publishAbstraction.Publish(new UpdateEmployeeMessage
				{
					Id = Guid.NewGuid(),
					FirstName = employee.FirstName,
					LastName = employee.LastName
				});

			return View(employee);
		}
	}
}