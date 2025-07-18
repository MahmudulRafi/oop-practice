namespace Practice_15.Models
{
    public class Bike : Vehicle
    {
        private const double RENT_PER_DAY = 15.0;
        private const int DAY_USAGE_TO_GET_DISCOUNT = 7;
        private const double DISCOUNT_PERCENTAGE_AMOUNT = 0.85;
        public Bike(int id, string brand, string model, int yearOfManufacture)
            : base(id, brand, model, yearOfManufacture, RENT_PER_DAY)
        {

        }

        public override double CalculateRentalCost(int rentedDays)
        {
            var rentelCost = base.CalculateRentalCost(rentedDays);

            if (rentedDays > DAY_USAGE_TO_GET_DISCOUNT)
                rentelCost *= DISCOUNT_PERCENTAGE_AMOUNT;

            return rentelCost;
        }
    }
}
