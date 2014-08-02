using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Syntax;
using Repository.Interfaces;
using Structure.IoC;
using Structure.Mock;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;


namespace ArborDesign
{
    public class IocConfig
    {
        public static void RegisterIoC(HttpConfiguration config)
        {

            var module = new ApplicationBindings((a) => {
                a.Rebind<IDataBaseContext>().To<FakeDataBaseContext>();
            });
            //module.Rebind<IDataBaseContext>().To<FakeDataBaseContext>();

            var kernel = new StandardKernel(module);

            config.DependencyResolver = new NinjectDependencyResolver(kernel);

            var jsonFormater = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonFormater.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            
        }
    }

    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Contract.Assert(resolver != null);

            this.resolver = resolver;
        }

        public void Dispose()
        {
            var disposable = resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            return resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            return resolver.GetAll(serviceType);
        }
    }

    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }
}