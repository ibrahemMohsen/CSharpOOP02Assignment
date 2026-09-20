using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    internal class StandardShipment : Shipment
    {
        public StandardShipment(string TrackingCode) : base(TrackingCode)
        {

        }
        public StandardShipment(
                string trackingCode,
                string description,
                double weight,
                decimal deliveryFee,
                DeliveryAddress destination
            ) : base(trackingCode, description, weight, deliveryFee, destination)
        {

        }
    }
}
