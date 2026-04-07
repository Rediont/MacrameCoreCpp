
#pragma once

extern "C" {
    // 1. Розрахунок довжини робочої нитки
    __declspec(dllexport) double CalculateCordLength(double finishedLengthMeters, double patternMultiplier, double fringeLengthMeters);

    // 2. Розрахунок кількості ниток для основи
    __declspec(dllexport) int CalculateTotalCords(double projectWidthCm, double cordThicknessMm);

    // 3. Загальний метраж шнура
    __declspec(dllexport) double CalculateTotalYardage(int totalCords, double lengthPerCord);

    // 4. Місткість вузлів у секції
    __declspec(dllexport) int CalculateKnotsCapacity(double sectionLengthCm, double knotHeightCm);

    // 5. Прогноз часу на виготовлення (в годинах)
    __declspec(dllexport) double EstimateProductionTime(int totalKnots, double knotsPerMinute);

    // 6. Собівартість матеріалів
    __declspec(dllexport) double EstimateMaterialCost(double totalMeters, double pricePerMeter, double accessoriesCost);

    // 7. Рівень складності (B - Beginner, I - Intermediate, P - Pro)
    __declspec(dllexport) char GetDifficultyLevel(int totalKnots);
}