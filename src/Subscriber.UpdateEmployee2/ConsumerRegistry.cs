using MassTransit;
using StructureMap.Configuration.DSL;

namespace Subscriber.UpdateEmployee2
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

					// NOTE: Notice that this is a different queue than the other consumer of the same message
					cfg.ReceiveFrom("rabbitmq://localhost/Subscriber.CooperatingConsumer");

					cfg.Subscribe(s => s.Consumer<MultiConsumerMessageConsumer>());
				}));
		}
	}
}