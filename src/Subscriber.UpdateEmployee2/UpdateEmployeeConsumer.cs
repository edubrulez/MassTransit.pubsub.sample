using System;
using MassTransit;
using Messages;

namespace Subscriber.UpdateEmployee2
{
	public class UpdateEmployeeConsumer : Consumes<EmployeeUpdatedMessage>.All
	{
		public void Consume(EmployeeUpdatedMessage updatedMessage)
		{
			Console.WriteLine(string.Format("Cooperating Consumer - ID: {0}, First Name: {1}, Last Name: {2}", updatedMessage.Id, updatedMessage.FirstName,
			                                updatedMessage.LastName));
		}
	}
}