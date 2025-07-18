namespace Practice_15.Models
{
    public class Truck : Vehicle
    {
        private const double RENT_PER_DAY = 100.0;
        private const double MAINTAINANCE_COST_PER_DAY = 100.0;
        public Truck(int id, string brand, string model, int yearOfManufacture)
            : base(id, brand, model, yearOfManufacture, RENT_PER_DAY)
        {

        }

        public override double CalculateRentalCost(int rentedDays)
        {
            return base.CalculateRentalCost(rentedDays) + (MAINTAINANCE_COST_PER_DAY * rentedDays);
        }
    }
}
