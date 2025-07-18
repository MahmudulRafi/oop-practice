namespace Practice_15.Models
{
    public class Car : Vehicle
    {
        private new const double RentalCostPerDay = 50.0;
        public Car(int id, string brand, string model, int yearOfManufacture)
            : base(id, brand, model, yearOfManufacture, RentalCostPerDay)
        {
            var carAge = base.GetVehicleAge();

            if (carAge > 5)
                base.RentalCostPerDay *= 0.9;
        }
    }
}
