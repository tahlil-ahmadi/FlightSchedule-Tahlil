using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace FlightSchedule.RestApi
{
    public class WindsorCompositionRoot : IHttpControllerActivator
    {
        private readonly IWindsorContainer container;

        public WindsorCompositionRoot(IWindsorContainer container)
        {
            this.container = container;
        }

        public IHttpController Create(HttpRequestMessage request,HttpControllerDescriptor controllerDescriptor,Type controllerType)
        {
            var controller = (IHttpController)this.container.Resolve(controllerType);
            return controller;
        }
    }
}