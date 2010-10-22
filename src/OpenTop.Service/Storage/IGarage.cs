using System;
using OpenTop.Service.Resources;

namespace OpenTop.Service.Storage
{
    public interface IGarage
    {
        Car GetById(Guid id);
        Car FindCar(string manufacturer, string model);
        void Park(Car car);
    }
}