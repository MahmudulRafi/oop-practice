using Practice_06.Models;

var rentalCompany = new CarRentalCompany();

var car1 = new Car("ABC123", "Toyota Corolla", 50);
var car2 = new Car("XYZ789", "Honda Civic", 60);

rentalCompany.AddCar(car1);
rentalCompany.AddCar(car2);

rentalCompany.PrintFleet();

var rental = new Rental(car1, "John Doe", DateTime.Today, 3);

Console.WriteLine($"\n{rental.CustomerName} rented {car1.Model} for {rental.RentalDays} days. Total: ${rental.CalculateTotalCost()}");

rentalCompany.PrintFleet();

rental.EndRental();

Console.WriteLine("\nAfter return:");

rentalCompany.PrintFleet();