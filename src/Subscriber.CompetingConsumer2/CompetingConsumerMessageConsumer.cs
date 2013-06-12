using System;
using MassTransit;
using Messages;

namespace Subscriber.CompetingConsumer2
{
	public class CompetingConsumerMessageConsumer : Consumes<CompetingConsumerMessage>.All
	{
		public void Consume(CompetingConsumerMessage updatedMessage)
		{
			Console.WriteLine(string.Format("Consumer 2 - ID: {0}, Name: {1}, Age: {2}", updatedMessage.Id, updatedMessage.Name,
			                                updatedMessage.Age));
		}
	}
}