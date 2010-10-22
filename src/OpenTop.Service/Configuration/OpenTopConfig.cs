using OpenRasta.Configuration;
using OpenRasta.DI;
using OpenTop.Service.Handlers;
using OpenTop.Service.Resources;
using OpenTop.Service.Storage;

namespace OpenTop.Service.Configuration
{
    public class OpenTopConfig : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Uses.CustomDependency<IGarage, InMemoryGarage>(DependencyLifetime.Singleton);

                ResourceSpace.Has.ResourcesOfType<Car>()
                    .AtUri("/car/{id}")
                    .And.AtUri("/car/{manufacturer}/{model}")
                    .HandledBy<CarHandler>()
                    .AsXmlSerializer();

                ResourceSpace.Has.ResourcesOfType<NewCar>()
                    .AtUri("/car/new")
                    .HandledBy<NewCarHandler>()
                    .AsXmlSerializer();
            }
        }
    }
}