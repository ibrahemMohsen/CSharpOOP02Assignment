using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    internal class InternationalShipment : Shipment
    {
        public string DestinationCountry
        {
            get;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    field = value;
                }
                else
                {
                    throw new Exception("DestinationCountry Cannot be null, empty, or whitespaces");
                }
            }
        }
        public decimal CustomsFee
        {
            get;
            set
            {
                if (value >= 0)
                {
                    field = value;
                }
                else
                {
                    throw new Exception("CustomsFee Cannot be negative");
                }
            }
        }

        public InternationalShipment(
            string trackingCode,
            string destinationCountry,
            decimal customsFee)
            : base(trackingCode)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        public InternationalShipment(
                string trackingCode,
                string description,
                double weight,
                decimal deliveryFee,
                DeliveryAddress destination,
                string destinationCountry,
                decimal customsFee
            ) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (decimal)(Weight * 5) + CustomsFee;
            }
        }
    }
}
