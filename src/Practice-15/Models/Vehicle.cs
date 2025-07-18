namespace Practice_15.Models
{
    public class Vehicle
    {
        public int Id { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int YearOfManufacture { get; private set; }
        public double RentalCostPerDay { get; protected set; }

        public Vehicle(int id, string brand, string model, int yearOfManufacture, double rentalCostPerDay)
        {
            Id = id;
            Brand = brand;
            Model = model;
            YearOfManufacture = yearOfManufacture;
            RentalCostPerDay = rentalCostPerDay;
        }

        protected int GetVehicleAge() => DateTime.Now.Year - YearOfManufacture;

        public virtual double CalculateRentalCost(int rentedDays)
        {
            if(rentedDays < 0) throw new InvalidOperationException("Invalid rent days");

            return RentalCostPerDay * rentedDays;
        }
    }
}
