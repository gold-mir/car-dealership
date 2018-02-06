using System.Collections.Generic;

namespace CarDealership.Models
{
    public class Car
    {
        private string _makeModel;
        private int _price;
        private int _milage;
        private string _description;
        private int _id;
        private List<string> _notes = new List<string>();

        private static int ID = 0;

        private static List<Car> _instances = new List<Car>();

        public Car(string makeModel, int price, int milage, string description = "")
        {
            _price = price;
            _milage = milage;
            _makeModel = makeModel;
            _description = description;
            _instances.Add(this);
            _id = ID++;
        }

        public static List<Car> GetAll()
        {
            return _instances;
        }

        public static Car GetByID(int id)
        {
            foreach (Car car in _instances)
            {
                if (car.GetID() == id)
                {
                    return car;
                }
            }
            return null;
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

        public int GetID()
        {
            return _id;
        }

        public List<string> GetNotes()
        {
            return _notes;
        }

        public void AddNote(string note)
        {
            _notes.Add(note);
        }
    }
}
