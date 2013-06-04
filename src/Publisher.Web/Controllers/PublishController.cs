using System;
using System.Web.Mvc;
using Messages;
using Publisher.Domain;
using Publisher.Models;

namespace Publisher.Controllers
{
	public class PublishController : Controller
	{
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
			new PublishAbstraction().Publish(new UpdateEmployeeMessage
				{
					Id = new Guid(),
					FirstName = employee.FirstName,
					LastName = employee.LastName
				});

			return View(employee);
		}
	}
}