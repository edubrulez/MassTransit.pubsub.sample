namespace Publisher.Domain
{
	public class WebApplication
	{
		public void Startup()
		{
			IocAbstraction.Bootstrap();
		}
	}
}