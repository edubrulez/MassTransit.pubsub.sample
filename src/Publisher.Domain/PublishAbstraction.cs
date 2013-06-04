using MassTransit;

namespace Publisher.Domain
{
	public class PublishAbstraction
	{
		public void Publish(object message)
		{
			Bus.Instance.Publish(message);
		}
	}
}