using MassTransit;

namespace Subscriber.Topshelf
{
	public class TopshelfService
	{
		private readonly IServiceBus _bus;

		public TopshelfService(IServiceBus bus)
		{
			_bus = bus;
		}

		public void Start()
		{
		}

		public void Stop()
		{
			_bus.Dispose();
		}
	}
}