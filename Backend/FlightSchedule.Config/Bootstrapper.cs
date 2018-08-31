using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FlightSchedule.Application;
using FlightSchedule.Application.Contracts;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Services;
using FlightSchedule.Persistence.EF;
using FlightSchedule.Persistence.EF.Repositories;

namespace FlightSchedule.Config
{
    public static class Bootstrapper
    {
        public static void Config(IWindsorContainer container)
        {
            container.Register(Component.For<IFlightRepository>()
                .ImplementedBy<FlightRepository>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IFlightService>()
                .ImplementedBy<FlightService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IFlightCalculationService>()
                .ImplementedBy<FlightCalculationService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<FlightScheduleContext>().LifestylePerWebRequest());
        }
    }
}