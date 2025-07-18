namespace Practice_15.Models
{
    public class Bike : Vehicle
    {
        private const double RENT_PER_DAY = 15.0;
        public Bike(int id, string brand, string model, int yearOfManufacture)
            : base(id, brand, model, yearOfManufacture, RENT_PER_DAY)
        {

        }

        public override double CalculateRentalCost(int rentedDays)
        {
            var rentelCost = base.CalculateRentalCost(rentedDays);

            if (rentedDays > 7)
                rentelCost *= 0.85;

            return rentelCost;
        }
    }
}
