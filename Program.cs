using System;

namespace MatBooks
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите значения: ");

            Console.Write("W:");
            double W = double.Parse(Console.ReadLine());

            Console.Write("tB:");
            double tB = double.Parse(Console.ReadLine());

            Console.Write("d:");
            double d = double.Parse(Console.ReadLine());

            Formulas formulas = new Formulas(W, tB, d);

            Console.WriteLine("Ваши результаты: ");
            

            Console.WriteLine($"Re = {formulas.Re()}");

            Console.WriteLine($"Nu для коридорного пучка труб составит {formulas.NuKor}");
            Console.WriteLine($"Коэффициент теплоотдачи конвекцией третьего и последующих рядов труб составит {formulas.a3r(formulas.NuKor)}");

            Console.WriteLine($"Nu для шахматного пучка труб составит {formulas.NuShakh}");
            Console.WriteLine($"Коэффициент теплоотдачи третьего и последующих рядов труб составит {formulas.a3r(formulas.NuShakh)}");

            Console.ReadLine();
        }

    }

}
