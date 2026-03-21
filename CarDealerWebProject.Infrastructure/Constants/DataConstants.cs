namespace CarDealerWebProject.Infrastructure.Constants
{
    public static class DataConstants
    {
        //Vehicle
        public const int VehicleMakeMaxLength = 30;
        public const int VehicleMakeMinLength = 1;
        public const int VehicleModelMaxLength = 50;
        public const int VehicleModelMinLength = 1;
        public const string VehiclePriceMax = "1000000000000.00";
        public const string VehiclePriceMin = "0.00";
        public const int VehicleMileageMax = 100000000;
        public const int VehicleMileageMin = 0;
        public const int VehicleDescriptionMaxLength = 1000;
        public const int VehicleDescriptionMinLength = 0;
        public const int VehicleColorMaxLength = 35;
        public const int VehicleColorMinLength = 1;

        //Motor
        public const int MotorHorsePowerMax = 10000;
        public const int MotorHorsePowerMin = 1;
        public const int EngineCapacityCCMax = 100000;
        public const int EngineCapacityCCMin = 1;
        public const int BatteryCapacityMax = 1000;
        public const int BatteryCapacityMin = 1;

        //User
        public const int UserNameMaxLength = 200;
        public const int UserNameMinLength = 4;

        //public const int CategoryMaxLength = 35;
        //public const int CategoryMinLength = 2;

    }
}
