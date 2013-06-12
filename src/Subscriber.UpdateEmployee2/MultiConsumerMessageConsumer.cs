using System;
using MassTransit;
using Messages;

namespace Subscriber.UpdateEmployee2
{
	public class MultiConsumerMessageConsumer : Consumes<MultiConsumerMessage>.All
	{
		public void Consume(MultiConsumerMessage updatedMessage)
		{
			Console.WriteLine("Multiple Consumer 1 - ID: {0}, First Name: {1}, Last Name: {2}", updatedMessage.Id, updatedMessage.FirstName,
			                                updatedMessage.LastName);
		}
	}
}