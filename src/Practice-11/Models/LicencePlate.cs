namespace Practice_11.Models
{
    public class LicencePlate
    {
        public string PlateNo { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public bool IsLicenceValid => DateTime.Now.Date <= ExpireDate.Date;

        public LicencePlate(string plateNo, DateTime registrationDate, DateTime expireDate)
        {
            PlateNo = plateNo;
            RegistrationDate = registrationDate;
            ExpireDate = expireDate;
        }
    }
}
