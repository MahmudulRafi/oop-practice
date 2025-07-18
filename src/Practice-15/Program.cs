using Practice_15.Models;

try
{
    Vehicle car1 = new Car(101, "Toyota", "Axio", 2019);

    Vehicle car2 = new Car(102, "Mitshubishi", "Lancer", 2022);

    Vehicle bike1 = new Bike(103, "Yamaha", "FZs", 2019);

    Vehicle bike2 = new Bike(104, "Bazaz", "Pluser", 2020);

    Vehicle truck = new Truck(105, "MAN", "Finle", 2019);

    var carRental1 = new Rental(car1, new DateTime(2025, 07, 10), new DateTime(2025, 07, 13));

    var carRental2 = new Rental(car2, new DateTime(2025, 07, 10), new DateTime(2025, 07, 13));

    var bikeRental1 = new Rental(bike1, new DateTime(2025, 07, 10), new DateTime(2025, 07, 19));

    var bikeRental2 = new Rental(bike2, new DateTime(2025, 07, 10), new DateTime(2025, 07, 15));

    var truckRental = new Rental(truck, new DateTime(2025, 07, 10), new DateTime(2025, 07, 13));

    double carCost1 = carRental1.CalculateRentalCost();

    double carCost2 = carRental2.CalculateRentalCost();

    double bikeCost1 = bikeRental1.CalculateRentalCost();

    double bikeCost2 = bikeRental2.CalculateRentalCost();

    double truckCost = truckRental.CalculateRentalCost();

    Console.WriteLine($"Car 1 - {car1.Brand} {car1.Model} was rented for {carRental1.GetTotalRentedDays()} days and cost ${carCost1}");

    Console.WriteLine($"Car 2 - {car2.Brand} {car2.Model} was rented for {carRental2.GetTotalRentedDays()} days and cost ${carCost2}");

    Console.WriteLine($"Bike 1 - {bike1.Brand} {bike1.Model} was rented for {bikeRental1.GetTotalRentedDays()} days and cost ${bikeCost1}");

    Console.WriteLine($"Bike 2 - {bike2.Brand} {bike2.Model} was rented for {bikeRental2.GetTotalRentedDays()} days and cost ${bikeCost2}");

    Console.WriteLine($"Truck - {truck.Brand} {truck.Model} was rented for {truckRental.GetTotalRentedDays()} days and cost ${truckCost}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
