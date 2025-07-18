namespace Practice_15.Models
{
    public class Truck : Vehicle
    {
        private new const double RentalCostPerDay = 100.0;
        private const double MaintainanceCostPerDay = 100.0;
        public Truck(int id, string brand, string model, int yearOfManufacture)
            : base(id, brand, model, yearOfManufacture, RentalCostPerDay)
        {

        }

        public override double CalculateRentalCost(int rentedDays)
        {
            return base.CalculateRentalCost(rentedDays) + (MaintainanceCostPerDay * rentedDays);
        }
    }
}
