using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BacteriaNN
{
    class Program
    {
        static void Main(string[] args)
        {
            int populationC;
            Console.Write("population: ");
            populationC = Convert.ToInt32(Console.ReadLine());
            Field field = new Field();
            field.setStartOptions();
            field.setStartPositions();
            field.setFood_rnd();
            field.setFoodToField();
            double tempAl = 0;
            while (field.population < populationC)
            {
                if (tempAl != field.getTimeAlive())
                {
                    Console.WriteLine($"{field.population} population: alive {field.getTimeAlive()} steps");
                    tempAl = field.getTimeAlive();
                }
                field.progressFilter();
                field.makeStep();
            }

            while (true)
            {
                Console.Clear();
                field.printField();
                field.progressFilter();
                field.makeStep();
                Thread.Sleep(12);
            }
        }
    }
}
