using MassTransit;

namespace Publisher.Domain
{
	public interface IPublishAbstraction
	{
		void Publish(object message);
	}

	public class PublishAbstraction : IPublishAbstraction
	{
		private readonly IServiceBus _serviceBus;

		public PublishAbstraction(IServiceBus serviceBus)
		{
			_serviceBus = serviceBus;
		}

		public void Publish(object message)
		{
			_serviceBus.Publish(message);
		}
	}
}