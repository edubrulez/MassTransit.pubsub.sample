using MassTransit;
using StructureMap.Configuration.DSL;

namespace Subscriber.CompetingConsumer2
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
					// NOTE: this competing consumer uses the same queue as the other subscriber
					cfg.ReceiveFrom("rabbitmq://localhost/Subscriber.CompetingConsumer");
					cfg.Subscribe(s => s.Consumer<CompetingConsumerMessageConsumer>());
				}));
		}
	}
}