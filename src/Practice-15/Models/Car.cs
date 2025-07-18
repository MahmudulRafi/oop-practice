namespace Practice_15.Models
{
    public class Car : Vehicle
    {
        private const double RENT_PER_DAY = 50.0;
        private const int CAR_AGE_TO_GET_DISCOUNT = 5;
        private const double DISCOUNT_PERCENTAGE_AMOUNT = 0.9;
        public Car(int id, string brand, string model, int yearOfManufacture)
            : base(id, brand, model, yearOfManufacture, RENT_PER_DAY)
        {

        }

        public override double CalculateRentalCost(int rentedDays)
        {
            var totalRentalCost = base.CalculateRentalCost(rentedDays);

            var carAge = GetVehicleAge();

            if (carAge > CAR_AGE_TO_GET_DISCOUNT)
                totalRentalCost *= DISCOUNT_PERCENTAGE_AMOUNT;

            return totalRentalCost;
        }
    }
}
