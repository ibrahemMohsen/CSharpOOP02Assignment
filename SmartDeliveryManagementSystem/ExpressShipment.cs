using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    internal class ExpressShipment : Shipment
    {
        private decimal _extraFee;
        public decimal ExtraFee
        {
            get
            {
                return _extraFee;
            }
            set
            {
                if (value > 0)
                {
                    _extraFee = value;
                }
            }
        }
        public ExpressShipment(string TrackingCode, decimal extraFee) : base(TrackingCode)
        {
            ExtraFee = extraFee;
        }
        public ExpressShipment(
                string trackingCode,
                string description,
                double weight,
                decimal deliveryFee,
                DeliveryAddress destination,
                decimal extraFee
            ) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (decimal)(Weight * 5) + ExtraFee;
            }
        }
    }
}
