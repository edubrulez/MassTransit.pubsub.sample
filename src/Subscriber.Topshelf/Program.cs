using Topshelf;

namespace Subscriber.Topshelf
{
	class Program
	{
		static void Main(string[] args)
		{
			IocAbstraction.Bootstrap();

			HostFactory.Run(service =>
				{
					service.SetServiceName("TopshelfSample");
					service.SetDisplayName("Topshelf Sample");
					service.SetDescription("a Mass Transit sample service for using Topshelf.");

					service.RunAsLocalService();

					service.Service<TopshelfService>(topshelfService =>
						{
							topshelfService.ConstructUsing(builder => IocAbstraction.Resolve<TopshelfService>());
							topshelfService.WhenStarted(o => o.Start());
							topshelfService.WhenStopped(o => o.Stop());
						});
				});
		}
	}
}
