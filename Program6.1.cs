using System;

namespace LabWork6._1
{
    class VectorOfRealNumbers
    {
        //поля
        private double[] vector;
        private int vectorCapacity;

        // конструктор із параметрами
        public VectorOfRealNumbers(double[] vector, int vectorCapacity)
        {
            this.vector = vector;
            this.vectorCapacity = vectorCapacity;
        }

        // метод для додавання елемента в кінець вектора
        public void AddLast(ref double[] vector, double value)
        {
            double[] newVector = new double[vector.Length + 1];

            for (int i = 0; i < newVector.Length; i++)
            {
                if (i < vector.Length)
                {
                    newVector[i] = vector[i];
                }
                else
                {
                    newVector[i] = value;
                }
            }
            vector = newVector;
        }

        // метод для виводу елементів вектора в консоль
        public void WriteVector(ref double[] vector)
        {
            Console.WriteLine("\nВектор: ");
            for (int i = 0; i < vector.Length; i++)
                Console.WriteLine(vector[i]);
        }

        public double[] Vector
        {
            get { return vector; }
            set { vector = value; }
        }
        //Перевантажена операція для виконання обробки елементів вектора
        public static VectorOfRealNumbers operator -(VectorOfRealNumbers vector)
        {
            double product = 1.0;
            double[] newVector = new double[vector.Vector.Length];
            //Створення нового вектора лише з додатніх елементів
            for (int i = 0; i < newVector.Length; i++)
            {
                if(vector.Vector[i] > 0)
                {
                    newVector[i] = vector.Vector[i];
                }
                //Якщо елемент вектора менший чи дорівнює нулю,
                //то ми замінюємо його на одиницю, бо при множенні на одиницю
                //добуток змінюватися не буде
                else
                {
                    newVector[i] = 1;
                }
            }

            //Обчислення добутку додатніх елементів вектора
            vector.Vector = newVector;
            for (int i = 0; i < vector.Vector.Length; i++)
            {
                product *= vector.Vector[i];
            }
            Console.WriteLine($"Добуток додатних елементiв \"вектора\" становить: {product}");
            return vector;
        }

        //Метод, що повертає значення поля vector
        public double[] ReturnVector(double[] vector)
        {
            return vector;
        }

        //Метод, що повертає значення поля vectorCapacity
        public int ReturnVectorCapacity(int vectorCapacity)
        {
            return vectorCapacity;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введiть кiлькiсть елементiв першого вектора №1:\t");

            //Ввід кількості елементів вектора з консолі
            int vectorCapacity1 = int.Parse(Console.ReadLine());

            double[] vector1 = new double[vectorCapacity1];

            //Цикл, для вводу всіх елементів вектора з консолі
            for (int i = 0; i < vectorCapacity1; i++)
            {
                Console.Write($"Введiть {i+1}-ий елемент вектора:\t");
                vector1[i] = double.Parse(Console.ReadLine());
            }
            VectorOfRealNumbers vectorOfRealNumbers1 = new VectorOfRealNumbers(vector1, vectorCapacity1);

            Console.WriteLine("");
            Console.WriteLine("=====================================================");
            Console.WriteLine("");

            Console.Write("Введiть кiлькiсть елементiв другого вектора №2:\t");

            //Ввід кількості елементів вектора з консолі
            int vectorCapacity2 = int.Parse(Console.ReadLine());

            double[] vector2 = new double[vectorCapacity2];

            //Цикл, для вводу всіх елементів вектора з консолі
            for (int i = 0; i < vectorCapacity2; i++)
            {
                Console.Write($"Введiть {i + 1}-ий елемент вектора:\t");
                vector2[i] = double.Parse(Console.ReadLine());
            }
            VectorOfRealNumbers vectorOfRealNumbers2 = new VectorOfRealNumbers(vector2, vectorCapacity2);

            //додавання елементів до векторів
            Console.Write("Введiть елемент, який треба додати в кiнець вектора №1:\t");
            double add1 = double.Parse(Console.ReadLine());
            vectorOfRealNumbers1.AddLast(ref vector1, add1);
            Console.Write("Введiть елемент, який треба додати в кiнець вектора №2:\t");
            double add2 = double.Parse(Console.ReadLine());
            vectorOfRealNumbers2.AddLast(ref vector2, add2);

            //вивід векторів в консоль
            vectorOfRealNumbers1.WriteVector(ref vector1);
            vectorOfRealNumbers2.WriteVector(ref vector2);

            vectorOfRealNumbers1.ReturnVector(vector1);
            vectorOfRealNumbers2.ReturnVector(vector2);

            vectorOfRealNumbers1.ReturnVectorCapacity(vectorCapacity1);
            vectorOfRealNumbers2.ReturnVectorCapacity(vectorCapacity2);

            //використання унарних перевантажених операцій для виконання 
            //обробки елементів векторів
            VectorOfRealNumbers vectorOfRealNumbers3 = -vectorOfRealNumbers1;
            VectorOfRealNumbers vectorOfRealNumbers4 = -vectorOfRealNumbers2;
            Console.ReadLine();
        }
    }
}
