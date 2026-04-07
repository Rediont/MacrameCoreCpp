#include "pch.h" 
#include "MacrameEngine.h"

double CalculateCordLength(double finishedLengthMeters, double patternMultiplier, double fringeLengthMeters) {
    if (finishedLengthMeters <= 0 || patternMultiplier <= 0) return 0;
    return ((finishedLengthMeters * patternMultiplier) + fringeLengthMeters) * 2.0;
}

int CalculateTotalCords(double projectWidthCm, double cordThicknessMm) {
    if (cordThicknessMm <= 0) return 0;
    double cords = projectWidthCm / (cordThicknessMm / 10.0);
    int intCords = (int)cords;
    return (intCords % 2 == 0) ? intCords : intCords + 1;
}

double CalculateTotalYardage(int totalCords, double lengthPerCord) {
    return totalCords * lengthPerCord;
}

int CalculateKnotsCapacity(double sectionLengthCm, double knotHeightCm) {
    if (knotHeightCm <= 0) return 0;
    return (int)(sectionLengthCm / knotHeightCm);
}

double EstimateProductionTime(int totalKnots, double knotsPerMinute) {
    if (knotsPerMinute <= 0) return 0;
    return (totalKnots / knotsPerMinute) / 60.0;
}

double EstimateMaterialCost(double totalMeters, double pricePerMeter, double accessoriesCost) {
    return (totalMeters * pricePerMeter) + accessoriesCost;
}

char GetDifficultyLevel(int totalKnots) {
    if (totalKnots < 500) return 'B';
    if (totalKnots < 2000) return 'I';
    return 'P';
}