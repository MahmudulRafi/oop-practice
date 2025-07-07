namespace Practice_06.Models
{
    public class CarRentalCompany
    {
        private readonly List<Car> _fleet = new();

        public void AddCar(Car car)
        {
            _fleet.Add(car);
        }

        public Car FindAvailableCar()
        {
            return _fleet.Find(c => c.IsAvailable)!;
        }

        public void PrintFleet()
        {
            foreach (var car in _fleet)
            {
                Console.WriteLine($"{car.Model} ({car.RegistrationNo}) - {(car.IsAvailable ? "Available" : "Rented")}");
            }
        }
    }

}
