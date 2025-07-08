
namespace Practice_11.Models
{
    public class Car
    {
        private const int MaximumAgeOfRegistrationRenew = 20;
        private LicencePlate? _licencePlate;
        public string OwnerName { get; private set; }
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public int ManufactureYear { get; private set; }
        public LicencePlate LicencePlate => _licencePlate ?? throw new InvalidOperationException("No licence plat is assigned to this car");
        public bool IsValidForRegistrationRenewal => DateTime.Now.Year - ManufactureYear <= MaximumAgeOfRegistrationRenew;

        public Car(string ownerName, string manufacturer, string model, int manufactureYear)
        {
            OwnerName = ownerName ?? throw new ArgumentNullException(nameof(ownerName));
            Manufacturer = manufacturer ?? throw new ArgumentNullException(nameof(manufacturer));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            ManufactureYear = manufactureYear;
        }

        public void AssignLicencePlate(LicencePlate licencePlate)
        {
            if (licencePlate is null)
                throw new ArgumentNullException(nameof(licencePlate));

            _licencePlate = licencePlate;
        }
    }
}
