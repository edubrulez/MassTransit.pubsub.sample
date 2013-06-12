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
			_publishAbstraction.Publish(new EmployeeUpdatedMessage
				{
					Id = Guid.NewGuid(),
					FirstName = employee.FirstName,
					LastName = employee.LastName
				});

			return View(employee);
		}


		[HttpGet]
		public ActionResult CompetingConsumer()
		{
			return View(new CompetingConsumerModel
			{
				Name = "first last",
				Age = 21
			});
		}

		[HttpPost]
		public ActionResult CompetingConsumer(CompetingConsumerModel competingConsumerModel)
		{
			_publishAbstraction.Publish(new CompetingConsumerMessage
			{
				Id = Guid.NewGuid(),
				Name = competingConsumerModel.Name,
				Age = competingConsumerModel.Age
			});

			return View(competingConsumerModel);
		}

	}
}