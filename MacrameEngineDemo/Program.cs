using System;
using System.Runtime.InteropServices;

namespace MacrameDemo
{
    class Program
    {
        // Вказуємо ім'я скомпільованої C++ бібліотеки
        private const string DllName = "MacrameCoreCpp.dll";

        // Імпортуємо всі 7 функцій з C++ DLL
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double CalculateCordLength(double finishedLength, double multiplier, double fringe);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CalculateTotalCords(double projectWidthCm, double cordThicknessMm);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double CalculateTotalYardage(int totalCords, double lengthPerCord);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CalculateKnotsCapacity(double sectionLengthCm, double knotHeightCm);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double EstimateProductionTime(int totalKnots, double knotsPerMinute);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double EstimateMaterialCost(double totalMeters, double pricePerMeter, double accessoriesCost);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetDifficultyLevel(int totalKnots); // byte для сумісності з char у C++

        static void Main()
        {
            Console.WriteLine("=== Калькулятор Макраме (C++ DLL Core) ===\n");

            // Вхідні дані для проєкту: Велике панно на стіну
            double lengthMeters = 1.5;
            double widthCm = 80.0;
            double thicknessMm = 5.0; // Товстий шнур 5мм
            double patternComplexity = 4.5;
            double fringeMeters = 0.4;
            int estimatedKnots = 2500;

            Console.WriteLine($"Параметри проєкту: Панно {widthCm}см x {lengthMeters}м\n");

            // Виклик функцій з DLL
            int cords = CalculateTotalCords(widthCm, thicknessMm);
            Console.WriteLine($"1. Кiлькiсть ниток для основи: {cords} шт.");

            double cordLength = CalculateCordLength(lengthMeters, patternComplexity, fringeMeters);
            Console.WriteLine($"2. Довжина однiєї нитки для нарiзки: {cordLength:F2} м");

            double totalYardage = CalculateTotalYardage(cords, cordLength);
            Console.WriteLine($"3. Загальний метраж необхiдного шнура: {totalYardage:F2} м");

            int knotsInSection = CalculateKnotsCapacity(15.0, 1.2); // Секція 15см, висота вузла 1.2см
            Console.WriteLine($"4. Мiсткiсть вузлiв у секцiї 15см: {knotsInSection} вузлiв");

            double hours = EstimateProductionTime(estimatedKnots, 5.0); // 5 вузлів на хв
            Console.WriteLine($"5. Орiєнтовний час плетiння: {hours:F1} годин");

            double cost = EstimateMaterialCost(totalYardage, 3.2, 200.0); // 3.2 грн/м шнура, 200 грн за палицю
            Console.WriteLine($"6. Орiєнтовна собiвартiсть матерiалів: {cost:F2} грн");

            char difficulty = (char)GetDifficultyLevel(estimatedKnots);
            Console.WriteLine($"7. Рiвень складностi проєкту: {difficulty} (B=Новачок, I=Середнiй, P=Профi)");

            Console.WriteLine("\nНатиснiть Enter для завершення...");
            Console.ReadLine();
        }
    }
}