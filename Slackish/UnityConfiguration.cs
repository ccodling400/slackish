using Slackish.Configuration;
using Slackish.Data;
using Slackish.Services;
using Slackish.Utilities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using MediatR;

namespace Slackish
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<DataContext>(new ContainerControlledLifetimeManager());
            
            
            container.RegisterType<ILoggerFactory, LoggerFactory>();            
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(t => container.Resolve(t));
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));
            container.RegisterTypes(AllClasses.FromAssemblies(typeof(UnityConfiguration).Assembly), WithMappings.FromAllInterfaces);
            container.RegisterInstance(AuthConfiguration.LazyConfig);
            container.RegisterInstance(MemoryCache.Current, new ContainerControlledLifetimeManager());         
            return container;
        }
    }
}
