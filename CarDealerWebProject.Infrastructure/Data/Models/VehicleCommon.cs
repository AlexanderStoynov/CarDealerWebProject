using CarDealerWebProject.Infrastructure.Data.Enums;

namespace CarDealerWebProject.Infrastructure.Data.Models;

public sealed record VehicleCommon(
    string Make,
    string Model,
    string Color,
    string Description,
    Transmission Transmission,
    DateTime ManufacturingDate,
    int MotorHorsePower,
    FuelType Fuel,
    decimal Price,
    int Milage,
    List<string> VehicleImages
);