using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    class DeliveryCenter
    {
        private Shipment[] _shipments;

        public DeliveryCenter()
        {
            _shipments = new Shipment[10];
        }

        public Shipment this[int index]
        {
            get
            {
                if (_shipments is not null &&
                    index >= 0 &&
                    index < _shipments.Length)
                {
                    return _shipments[index];
                }

                return default;
            }

            set
            {
                if (_shipments is not null &&
                    index >= 0 &&
                    index < _shipments.Length)
                {
                    _shipments[index] = value;
                }
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                if (_shipments is null ||
                    string.IsNullOrWhiteSpace(trackingCode))
                {
                    return default;
                }

                foreach (Shipment shipment in _shipments)
                {
                    if (shipment.TrackingCode == trackingCode)
                        return shipment;
                }

                return default;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            _shipments ??= new Shipment[10];

            for (int i = 0; i < _shipments.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(
                        _shipments[i].TrackingCode))
                {
                    _shipments[i] = shipment;
                    return true;
                }
            }

            return false;
        }
    }

}
