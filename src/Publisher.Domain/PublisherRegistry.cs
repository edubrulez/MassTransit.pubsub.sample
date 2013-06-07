using System.Web.Mvc;
using MassTransit;
using StructureMap.Configuration.DSL;

namespace Publisher.Domain
{
	public class PublisherRegistry : Registry
	{
		public PublisherRegistry()
		{
			For<IPublishAbstraction>().Use<PublishAbstraction>();
			For<IServiceBus>().Use(ServiceBusFactory.New(cfg =>
				{
					cfg.UseRabbitMq();
					cfg.ReceiveFrom("rabbitmq://localhost/MassTransit.publisher.sample");
				}));
			//For<IControllerActivator>().Use<StructureMapControllerActivator>();
			For<IDependencyResolver>().Use<StructureMapDependencyResolver>();
		}
	}
}