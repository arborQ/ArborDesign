using Ninject;
using Structure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ArborDesign
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private IKernel IoC { get; set; }
        public ControllerFactory()
        {
            var module = new ApplicationBindings();
            
            IoC = new StandardKernel(module);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {           
            return IoC.Get(controllerType) as IController;
        }

        //private class WebApplicationBindings : ResolveDependency.ApplicationBindings
        //{
        //    protected override void LoadBindings()
        //    {
        //        Bind<ISessionHelper>().To<SessionHelper>().InRequestScope();
        //    }
        //}
    }
}