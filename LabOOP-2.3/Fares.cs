using System;
using System.Linq;

namespace ParkingManagement
{
    public enum Parking
    {
        Cars,
        FreightCars,
        Buses
    }

    public class Fares
    {
        private string prices;
        private string services;
        private int occupiedSpots;
        private Parking parking;
        private Auto[] autoList;

        public Fares(Parking parking, string prices, string services, int occupiedSpots, int autoListSize)
        {
            this.parking = parking;
            this.prices = prices;
            this.services = services;
            this.occupiedSpots = occupiedSpots;
            this.autoList = new Auto[autoListSize];
        }

        public Fares()
        {
            parking = Parking.Cars;
            prices = "30 грн";
            services = "Відсутні послуги";
            occupiedSpots = 180;
            autoList = new Auto[0];
        }

        public string Prices
        {
            get { return prices; }
            set { prices = value; }
        }

        public string Services
        {
            get { return services; }
            set { services = value; }
        }

        public int OccupiedSpots
        {
            get { return occupiedSpots; }
            set { occupiedSpots = value; }
        }

        public Parking Parking
        {
            get { return parking; }
            set { parking = value; }
        }

        public Auto[] AutoList
        {
            get { return autoList; }
            set { autoList = value; }
        }

        public Auto LatestParking
        {
            get
            {
                if (autoList.Length == 0)
                    return null;

                return autoList.OrderByDescending(auto => auto.ParkingDate).First();
            }
        }

        public bool this[Parking index]
        {
            get
            {
                return parking == index;
            }
        }

        public void AddAuto(params Auto[] autos)
        {
            int oldLength = autoList.Length;
            Array.Resize(ref autoList, oldLength + autos.Length);
            for (int i = 0; i < autos.Length; i++)
            {
                autoList[oldLength + i] = autos[i];
            }
        }

        public override string ToString()
        {
            return $"\nПарковка: {parking}, Ціна: {prices}, Послуги: {services}, Зайняті місця: {occupiedSpots}, К-сть автівок: {autoList.Length}";
        }

        public virtual string ToShortString()
        {
            return $"\nПарковка: {parking}, Ціна: {prices}, Послуги: {services}, Зайняті місця: {occupiedSpots}";
        }
    }
}