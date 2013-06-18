using System;
using MassTransit;
using Messages;

namespace Subscriber.Topshelf
{
	public class TopshelfMessageConsumer : Consumes<TopshelfMessage>.All
	{
		public void Consume(TopshelfMessage updatedMessage)
		{
			Console.WriteLine("Topshelf message ID: {0}, Text: {1}", updatedMessage.Id, updatedMessage.MessageText);
		}
	}
}