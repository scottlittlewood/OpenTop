using System;
using System.Collections.Generic;
using System.Linq;
using OpenTop.Service.Resources;

namespace OpenTop.Service.Storage
{
    public class InMemoryGarage : IGarage
    {
        private readonly List<Car> _cars = new List<Car>();

        public Car GetById(Guid id)
        {
            return (from c in _cars
                    where c.Id == id
                    select c).SingleOrDefault();
        }

        public Car FindCar(string manufacturer, string model)
        {
            return (from c in _cars
                    where c.Manufacturer == manufacturer && c.Model == model
                    select c).SingleOrDefault();
        }

        public void Park(Car car)
        {
            _cars.Add(car);
        }
    }
}