using Practice_11.Models;

var car = new Car("Mr. X", "Toyota", "Corolla Filder", 2020);

car.AssignLicencePlate(new LicencePlate("DHK Metro Ka - 232425", DateTime.Now, DateTime.Now.AddYears(3)));

if (car.LicencePlate.IsLicenceValid)
    Console.WriteLine($"The car from {car.OwnerName} has a valid licence plate. Expire Date - {car.LicencePlate.ExpireDate.ToString("dd.mm.yyyy")}");