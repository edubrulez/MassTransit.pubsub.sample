using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;

namespace Subscriber.UpdateEmployee2
{
	public class IocAbstraction
	{
		private static bool _wasBootstrapped;

		public static void Bootstrap()
		{
			if (_wasBootstrapped)
			{
				return;
			}

			ObjectFactory.Initialize(y => y.Scan(x =>
			                                     {
			                                     	x.TheCallingAssembly();
			                                     	x.WithDefaultConventions();
			                                     	x.LookForRegistries();
			                                     }));

			_wasBootstrapped = true;
		}

		public static T Resolve<T>()
		{
			return ObjectFactory.GetInstance<T>();
		}

		public static IEnumerable<T> ResolveAll<T>()
		{
			return ObjectFactory.GetAllInstances<T>();
		}

		public static void Inject<T>(T fake)
		{
			ObjectFactory.Inject(fake);
		}

		public static void ReleaseAndDisposeAllHttpScopedObjects()
		{
			ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
		}

		public static Func<Type, object> ResolveByType = (pluginType => ObjectFactory.GetInstance(pluginType));
		public static Func<Type, IEnumerable<object>> ResolveAllByType = (pluginType => ObjectFactory.GetAllInstances(pluginType).Cast<object>().ToArray());
	}
}