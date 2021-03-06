[assembly: WebActivator.PostApplicationStartMethod(typeof(FootballApi.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace FootballApi.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using Services;
    using DTO;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<ICsvReader, CsvReader>(Lifestyle.Scoped);
            //container.Register<IMatchResultService, MatchResultService>(Lifestyle.Scoped);
            container.Register<IMatchResultDTOFactory, MatchResultDTOFactory>(Lifestyle.Scoped);
        }
    }
    
}