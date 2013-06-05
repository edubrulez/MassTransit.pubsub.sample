using System;
using MassTransit;
using Messages;

namespace Subscriber.UpdateEmployee
{
	public class UpdateEmployeeConsumer : Consumes<UpdateEmployeeMessage>.All
	{
		public void Consume(UpdateEmployeeMessage message)
		{
			Console.WriteLine(string.Format("ID: {0}, First Name: {1}, Last Name: {2}", message.Id, message.FirstName,
			                                message.LastName));
		}
	}
}