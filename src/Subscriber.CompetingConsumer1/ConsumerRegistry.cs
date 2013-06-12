using MassTransit;
using StructureMap.Configuration.DSL;

namespace Subscriber.CompetingConsumer1
{
	public class ConsumerRegistry : Registry
	{
		public ConsumerRegistry()
		{
			Scan(x =>
				{
					x.TheCallingAssembly();
					x.WithDefaultConventions();
					x.LookForRegistries();
				});

			For<IServiceBus>().Use(ServiceBusFactory.New(cfg =>
				{
					cfg.UseRabbitMq();
					cfg.ReceiveFrom("rabbitmq://localhost/Subscriber.CompetingConsumer");
					cfg.Subscribe(s => s.Consumer<UpdateEmployeeConsumer>());
				}));
		}
	}
}