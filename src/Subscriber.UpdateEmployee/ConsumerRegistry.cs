using MassTransit;
using StructureMap.Configuration.DSL;

namespace Subscriber.UpdateEmployee
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
					cfg.ReceiveFrom("rabbitmq://localhost/Subscriber.Console");
					cfg.Subscribe(s => s.Consumer<MultiConsumerMessageConsumer>());
				}));
		}
	}
}