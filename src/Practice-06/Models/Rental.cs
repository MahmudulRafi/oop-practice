namespace Practice_06.Models
{
    public class Rental
    {
        public Car RentedCar { get; private set; }
        public string CustomerName { get; private set; }
        public DateTime StartDate { get; private set; }
        public int RentalDays { get; private set; }

        public Rental(Car car, string customerName, DateTime startDate, int rentalDays)
        {
            if (!car.IsAvailable)
                throw new InvalidOperationException("Car is already rented.");

            RentedCar = car;
            CustomerName = customerName;
            StartDate = startDate;
            RentalDays = rentalDays;

            car.Rent();
        }

        public double CalculateTotalCost()
        {
            return RentalDays * RentedCar.RentalRatePerDay;
        }

        public void EndRental()
        {
            RentedCar.ReturnCar();
        }
    }
}
