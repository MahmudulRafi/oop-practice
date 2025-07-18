namespace Practice_15.Models
{
    public class Car : Vehicle
    {
        private const double RENT_PER_DAY = 50.0;
        public Car(int id, string brand, string model, int yearOfManufacture)
            : base(id, brand, model, yearOfManufacture, RENT_PER_DAY)
        {
            var carAge = base.GetVehicleAge();

            if (carAge > 5)
                base.RentalCostPerDay *= 0.9;
        }
    }
}
