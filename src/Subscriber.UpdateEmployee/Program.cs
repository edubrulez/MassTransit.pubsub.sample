using MassTransit;

namespace Subscriber.UpdateEmployee
{
	class Program
	{
		static void Main(string[] args)
		{
			Bus.Initialize(serviceBusConfig =>
				{
					serviceBusConfig.UseRabbitMq();
					serviceBusConfig.ReceiveFrom("rabbitmq://localhost/Subscriber.Console");
					serviceBusConfig.Subscribe(s => s.Consumer<UpdateEmployeeConsumer>());
				});
		}
	}
}
