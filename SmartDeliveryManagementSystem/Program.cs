using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter center name: ");
            string centerName = Console.ReadLine()!;

            DeliveryCenter center = new DeliveryCenter(centerName);

            StandardShipment standardShipment = ReadStandardShipment();
            ExpressShipment expressShipment = ReadExpressShipment();
            InternationalShipment internationalShipment =
                ReadInternationalShipment();

            center.AddShipment(standardShipment);
            center.AddShipment(expressShipment);
            center.AddShipment(internationalShipment);

            Console.WriteLine("All shipments:");
            center.PrintAllShipments();

            Console.Write("Enter a tracking code to search for: ");
            string searchCode = Console.ReadLine()!;

            Shipment? foundShipment = center[searchCode];

            if (foundShipment is not null)
                foundShipment.PrintShipment();
            else
                Console.WriteLine("Shipment not found.");

            Console.Write("Enter a tracking code to remove: ");
            string removalCode = Console.ReadLine()!;

            Console.WriteLine(
                center.RemoveShipment(removalCode)
                    ? "Shipment removed successfully."
                    : "Shipment not found.");

            Console.WriteLine("Remaining shipments:");
            center.PrintAllShipments();
        }
        static StandardShipment ReadStandardShipment()
        {
            Console.WriteLine("\nEnter Standard Shipment Data");

            Console.Write("Tracking code: ");
            string trackingCode = Console.ReadLine()!;

            Console.Write("Description: ");
            string description = Console.ReadLine()!;

            Console.Write("Weight: ");
            double weight = double.Parse(Console.ReadLine()!);

            Console.Write("Delivery fee: ");
            decimal deliveryFee = decimal.Parse(Console.ReadLine()!);

            DeliveryAddress destination = ReadDeliveryAddress();

            return new StandardShipment(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination);
        }

        static ExpressShipment ReadExpressShipment()
        {
            Console.WriteLine("\nEnter Express Shipment Data");

            Console.Write("Tracking code: ");
            string trackingCode = Console.ReadLine()!;

            Console.Write("Description: ");
            string description = Console.ReadLine()!;

            Console.Write("Weight: ");
            double weight = double.Parse(Console.ReadLine()!);

            Console.Write("Delivery fee: ");
            decimal deliveryFee = decimal.Parse(Console.ReadLine()!);

            DeliveryAddress destination = ReadDeliveryAddress();

            Console.Write("Extra fee: ");
            decimal extraFee = decimal.Parse(Console.ReadLine()!);

            return new ExpressShipment(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination,
                extraFee);
        }

        static InternationalShipment ReadInternationalShipment()
        {
            Console.WriteLine("\nEnter International Shipment Data");

            Console.Write("Tracking code: ");
            string trackingCode = Console.ReadLine()!;

            Console.Write("Description: ");
            string description = Console.ReadLine()!;

            Console.Write("Weight: ");
            double weight = double.Parse(Console.ReadLine()!);

            Console.Write("Delivery fee: ");
            decimal deliveryFee = decimal.Parse(Console.ReadLine()!);

            DeliveryAddress destination = ReadDeliveryAddress();

            Console.Write("Destination country: ");
            string destinationCountry = Console.ReadLine()!;

            Console.Write("Customs fee: ");
            decimal customsFee = decimal.Parse(Console.ReadLine()!);

            return new InternationalShipment(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination,
                destinationCountry,
                customsFee);
        }
        static DeliveryAddress ReadDeliveryAddress()
        {
            Console.Write("Enter City Name");
            string city = Console.ReadLine()!;

            Console.Write("Enter Street: ");
            string street = Console.ReadLine()!;

            Console.Write("Enter Building Number: ");
            int buildingNumber = int.Parse(Console.ReadLine()!);

            return new DeliveryAddress(city, street, buildingNumber);
        }
    }
}
