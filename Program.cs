using System;
namespace Task3
{
    class Program
    {

        public class Neuron
        {
            private decimal weight = 0.5m;

            public decimal LastError { get; private set; }

            public decimal Smoothing { get; set; } = 0.00001m;

            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }

            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }

            public void Train(decimal input, decimal expectedResult)
            {
                var actualResult = weight * input;
                LastError = expectedResult - actualResult;
                var correction = (LastError / actualResult) * Smoothing;
                weight += correction;
            }
        }

        static void Main(string[] args)
        {
            decimal km = 100;
            decimal miles = 62.1371m;

            Neuron neuron = new Neuron();
            int i = 0;
            do
            {
                i++;
                neuron.Train(km, miles);

                Console.WriteLine($"Итерация: {i}\tОшибка:\t{neuron.LastError}");
            } while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);
            Console.WriteLine("Обучение завершено!");
            Console.WriteLine($"{neuron.ProcessInputData(100)} миль в {100}км");
            Console.WriteLine($"{neuron.ProcessInputData(541)} миль в {541}км");
            Console.WriteLine($"{neuron.RestoreInputData(10)} км в {100}миль");
            Console.WriteLine(neuron.ProcessInputData(km));
            Console.ReadKey();
        }
    }
}
