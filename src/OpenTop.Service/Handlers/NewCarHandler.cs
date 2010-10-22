using OpenRasta.Web;
using OpenTop.Service.Resources;
using OpenTop.Service.Storage;

namespace OpenTop.Service.Handlers
{
    public class NewCarHandler
    {
        private readonly IGarage _garage;

        public NewCarHandler(IGarage garage)
        {
            _garage = garage;
        }

        public OperationResult Post(NewCar newCar)
        {
            var car = new Car { Manufacturer = newCar.Manufacturer, Model = newCar.Model };

            _garage.Park(car);

            return new OperationResult.SeeOther { RedirectLocation = car.CreateUri() };
        }

        public OperationResult Get()
        {
            var newCar = new NewCar() { Manufacturer = "Ford", Model = "Ka" };
            return new OperationResult.OK(newCar);
        }
    }
}