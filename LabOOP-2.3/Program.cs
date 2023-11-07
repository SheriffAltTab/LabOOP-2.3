using System;
using System.Text;

namespace ParkingManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Fares fares1 = new Fares();
            Fares fares2 = new Fares();
            Fares fares3 = new Fares();
            
            Fares fares4 = new Fares();


            fares1.Prices = "30 грн";
            fares1.Services = "Відсутні послуги";
            fares1.OccupiedSpots = 150;
            fares1.Parking = Parking.Cars;
            Auto auto1 = new Auto(12345, "Шпінталь М.Я.", DateTime.Now);
            fares1.AddAuto(auto1);

            fares2.Prices = "90 грн";
            fares2.Services = "Мінімальні послуги";
            fares2.OccupiedSpots = 50;
            fares2.Parking = Parking.FreightCars;
            Auto auto2 = new Auto(67890, "Сусла М.В.", DateTime.Now);
            fares2.AddAuto(auto2);

            fares3.Prices = "70 грн";
            fares3.Services = "Максимальні послуги";
            fares3.OccupiedSpots = 82;
            fares3.Parking = Parking.Buses;
            Auto auto3 = new Auto(54321, "Плішко І.В.", DateTime.Now);
            fares3.AddAuto(auto3);

            Console.WriteLine($"Значення індексатора для Parking.Cars: {fares1[Parking.Cars]}");
            Console.WriteLine($"Значення індексатора для Parking.FreightCars: {fares2[Parking.FreightCars]}");
            Console.WriteLine($"Значення індексатора для Parking.Buses: {fares3[Parking.Buses]}");


            Console.WriteLine(fares1.ToString());
            Console.WriteLine(fares2.ToString());
            Console.WriteLine(fares3.ToString());

            fares4.AddAuto(auto1, auto2, auto3); //для того шоб вивести коректну інформацію про найпізнішу дату

            Auto latestParking = fares4.LatestParking;
            Console.WriteLine($"\nАвто з найпізнішою датою паркування: {latestParking}");

            Console.WriteLine("\nРозмір масиву: 100:\n");
            TimeChecker(100);
            Console.WriteLine("\nРозмір масиву: 1000:\n");
            TimeChecker(1000);
            Console.WriteLine("\nРозмір масиву: 5000:\n");
            TimeChecker(5000);

            Console.ReadLine();
        }

        public static void TimeChecker(int size)
        {
            Auto[] oneArray = new Auto[size];
            Auto[,] rectangularArray = new Auto[size, size];
            Auto[][] jaggedArray = new Auto[size][];

            for (int i = 0; i < size; i++)
            {
                jaggedArray[i] = new Auto[size];
            }

            var sw1 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < size; i++)
            {
                oneArray[i] = new Auto();
            }
            sw1.Stop();
            Console.WriteLine($"Час для одновимірного масиву: {sw1.ElapsedMilliseconds} мс");

            var sw2 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    rectangularArray[i, j] = new Auto();
                }
            }
            sw2.Stop();
            Console.WriteLine($"Час для двовимірного прямокутного масиву: {sw2.ElapsedMilliseconds} мс");

            var sw3 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    jaggedArray[i][j] = new Auto();
                }
            }
            sw3.Stop();
            Console.WriteLine($"Час для двовимірного ступінчастого масиву: {sw3.ElapsedMilliseconds} мс");
        }
    }
}
