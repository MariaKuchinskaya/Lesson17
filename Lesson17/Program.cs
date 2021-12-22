using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lesson17
{
    class Program
    {
        public static List<Car> Cars;

        static void Main(string[] args)
        {

            Cars = new List<Car>();
            Random rnd = new Random();

            for (int i = 0; i < 100000; i++)
            {
                Cars.Add(new Car(rnd.Next())); ;
            };

            var timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < Cars.Count; i++)
            {
                Cars[i].Age = (343 * 34 * DateTime.Now.Millisecond * 77) / DateTime.Now.Minute;
            }

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine($"{foo}");

            timer.Start();

            var result = Parallel.ForEach(Cars, ChangeAge);

            timer.Stop();

            TimeSpan timeTaken2 = timer.Elapsed;
            string foo2 = "Time taken: " + timeTaken2.ToString(@"m\:ss\.fff");
            Console.WriteLine($"{foo2}");

            timer.Start();

            var result3 = Parallel.For(1, 100000, ChangeAge2);

            timer.Stop();

            TimeSpan timeTaken3 = timer.Elapsed;
            string foo3 = "Time taken: " + timeTaken3.ToString(@"m\:ss\.fff");
            Console.WriteLine($"{foo3}");
        }

        static void ChangeAge(Car car)
        {
            car.Age = (343 * 34 * DateTime.Now.Millisecond * 77) / DateTime.Now.Minute;
        }

        static void ChangeAge2(int i)
        {
            Cars[i].Age = (343 * 34 * DateTime.Now.Millisecond * 77) / DateTime.Now.Minute;
        }
    }
}
