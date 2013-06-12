using System;

namespace Messages
{
	public class CompetingConsumerMessage
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
	}
}