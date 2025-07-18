namespace Practice_15.Models
{
    public class Rental
    {
        public Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Rental(Vehicle vehicle, DateTime startDate, DateTime endDate)
        {
            Vehicle = vehicle;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int GetTotalRentedDays() => (EndDate - StartDate).Days;

        public double CalculateRentalCost()
        {
            var totalDays = GetTotalRentedDays();

            return Vehicle.CalculateRentalCost(totalDays);
        }
    }
}
