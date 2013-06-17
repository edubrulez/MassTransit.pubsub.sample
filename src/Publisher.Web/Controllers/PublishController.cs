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
		public ActionResult MultipleConsumer()
		{
			return View(new MultipleConsumerModel
				{
					FirstName = "first",
					LastName = "last"
				});
		}

		[HttpPost]
		public ActionResult MultipleConsumer(MultipleConsumerModel multipleConsumerModel)
		{
			_publishAbstraction.Publish(new MultiConsumerMessage
				{
					Id = Guid.NewGuid(),
					FirstName = multipleConsumerModel.FirstName,
					LastName = multipleConsumerModel.LastName
				});

			return View(multipleConsumerModel);
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

		[HttpGet]
		public ActionResult SeparateCopyOfMessageClass()
		{
			return View(new SeparateCopyOfMessageClassModel
			{
				TestMessage = "test text"
			});
		}

		[HttpPost]
		public ActionResult SeparateCopyOfMessageClass(SeparateCopyOfMessageClassModel separateCopyOfMessageClassModel)
		{
			_publishAbstraction.Publish(new SeparateCopyOfMessageInSubscriber
			{
				Id = Guid.NewGuid(),
				test = separateCopyOfMessageClassModel.TestMessage,
			});

			return View(separateCopyOfMessageClassModel);
		}

	}
}