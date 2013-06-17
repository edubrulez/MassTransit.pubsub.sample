using System;

// this works when the namespaces are the same in the separate projects
namespace Messages
{
	public class SeparateCopyOfMessageInSubscriber
	{
		public Guid Id { get; set; }
		public string test { get; set; }
	}
}