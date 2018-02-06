using System.Collections.Generic;

namespace CarDealership.Models
{
    public class Car
    {
        private string _makeModel;
        private int _price;
        private int _milage;
        private string _description;

        private static List<Car> _instances = new List<Car>();

        public Car(string makeModel, int price, int milage, string description = "")
        {
            _price = price;
            _milage = milage;
            _makeModel = makeModel;
            _description = description;
            _instances.Add(this);
        }

        public static List<Car> GetAll()
        {
            return _instances;
        }

        public bool Destroy()
        {
            return _instances.Remove(this);
        }

        public string GetMakeModel()
        {
            return _makeModel;
        }

        public int GetPrice()
        {
            return _price;
        }

        public int GetMilage()
        {
            return _milage;
        }

        public string GetDescription()
        {
            return _description;
        }
        public void SetDescription(string str)
        {
            _description = str;
        }
    }
}
