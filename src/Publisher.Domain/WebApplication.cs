using MassTransit;

namespace Publisher.Domain
{
	public class WebApplication
	{
		public void Startup()
		{
			Bus.Initialize(serviceBusConfig =>
				{
					serviceBusConfig.UseRabbitMq();
					serviceBusConfig.ReceiveFrom("rabbitmq://localhost/MassTransit.publisher.sample");
				});
		}
	}
}