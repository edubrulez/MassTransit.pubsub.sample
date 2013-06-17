using System;
using MassTransit;
using Messages;

namespace Subscriber.SeparateCopyOfMessageClass
{
	public class SeparateCopyOfMessageClassConsumer : Consumes<SeparateCopyOfMessageInSubscriber>.All
	{
		public void Consume(SeparateCopyOfMessageInSubscriber updatedMessage)
		{
			Console.WriteLine("Separate Copy of Message Class ID: {0}, test: {1}", updatedMessage.Id, updatedMessage.test);
		}
	}
}