namespace Practice_06.Models
{
    public class Car
    {
        private readonly string _registrationNo;
        private readonly string _model;
        private readonly double _rentalRatePerDay;
        private bool _isAvailable;
        private DateTime _lastMaintenanceDate;

        public string RegistrationNo => _registrationNo;
        public string Model => _model;
        public double RentalRatePerDay => _rentalRatePerDay;
        public bool IsAvailable => _isAvailable;
        public DateTime LastMaintenanceDate => _lastMaintenanceDate;

        public Car(string registrationNo, string model, double rentalRatePerDay)
        {
            _registrationNo = registrationNo;
            _model = model;
            _rentalRatePerDay = rentalRatePerDay;
            _isAvailable = true;
            _lastMaintenanceDate = DateTime.Now;
        }

        public void Rent()
        {
            if (!_isAvailable)
                throw new InvalidOperationException("Car is not available.");

            _isAvailable = false;
        }

        public void ReturnCar()
        {
            _isAvailable = true;
        }

        public void SendToMaintenance()
        {
            _lastMaintenanceDate = DateTime.Now;
            _isAvailable = false;
        }

        public void ReceiveFromMaintenance()
        {
            _isAvailable = true;
        }
    }
}
