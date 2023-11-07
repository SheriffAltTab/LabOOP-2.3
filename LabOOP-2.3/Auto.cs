using System;

namespace ParkingManagement
{
    public class Auto
    {
        public int RegistrationNumber { get; set; }
        public string OwnerName { get; set; }
        public DateTime ParkingDate { get; set; }

        public Auto(int registrationNumber, string ownerName, DateTime parkingDate)
        {
            RegistrationNumber = registrationNumber;
            OwnerName = ownerName;
            ParkingDate = parkingDate;
        }

        public Auto()
        {
            RegistrationNumber = 0;
            OwnerName = "1";
            ParkingDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Державний номер: {RegistrationNumber}, ПІП власника: {OwnerName}, Дата паркування: {ParkingDate}";
        }
    }
}