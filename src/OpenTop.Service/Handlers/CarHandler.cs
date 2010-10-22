using System;
using OpenRasta.Web;
using OpenTop.Service.Storage;

namespace OpenTop.Service.Handlers
{
    public class CarHandler
    {
        private readonly IGarage _cars;

        public CarHandler(IGarage showroom)
        {
            _cars = showroom;
        }

        public OperationResult Get(Guid id)
        {
            var car = _cars.GetById(id);

            return new OperationResult.OK(car);
        }

        public OperationResult Get(string manufacturer, string model)
        {
            var car = _cars.FindCar(manufacturer, model);

            if (car == null)
                return new OperationResult.NotFound();

            return new OperationResult.OK(car);
        }
    }
}