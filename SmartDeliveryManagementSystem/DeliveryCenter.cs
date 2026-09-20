using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeliveryManagementSystem
{
    struct DeliveryCenter
    {
        private Shipment[] _shipments;
        public string CenterName { get; set; }

        public DeliveryCenter() : this("Unknown")
        {

        }
        public DeliveryCenter(string centerName)
        {
            _shipments = new Shipment[20];
            CenterName = centerName;
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

                return default!;
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
                    return default!;
                }

                foreach (Shipment shipment in _shipments)
                {
                    if (shipment is not null && shipment.TrackingCode == trackingCode)
                        return shipment;
                }

                return default!;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            _shipments ??= new Shipment[20];

            for (int i = 0; i < _shipments.Length; i++)
            {
                if (_shipments[i] is null)
                {
                    _shipments[i] = shipment;
                    return true;
                }
            }

            return false;
        }
        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < _shipments.Length; i++)
            {
                if (_shipments[i] is not null && _shipments[i].TrackingCode == trackingCode)
                {
                    _shipments[i] = null!;
                    return true;
                }
            }

            return false;
        }
        public void PrintAllShipments()
        {
            for (int i = 0; i < _shipments!.Length; i++)
            {
                if (_shipments[i] != null)
                {
                    Console.WriteLine(CenterName);
                    _shipments[i].PrintShipment();
                }
            }
        }
    }
}
