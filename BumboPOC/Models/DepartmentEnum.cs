using BumboPOC.Models;

namespace BumboPOC.Models
{
    public enum DepartmentEnum
    {
        Cassiere = 0,
        Fresh = 1,
        Stocker = 2


    }
}

public static class DepartmentEnumExtension
{
    public static string GetDutchNames(DepartmentEnum departmentEnum)
    {
        switch (departmentEnum)
        {
            case DepartmentEnum.Cassiere:
                return "Kassa";
            case DepartmentEnum.Fresh:
                return "Vers";
            case DepartmentEnum.Stocker:
                return "Voorraad";
            default:
                return "Onbekend";
        }
    }
}

