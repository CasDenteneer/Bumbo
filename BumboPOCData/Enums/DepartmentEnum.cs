using BumboData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumboData.Enums
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
                return "VakkenVuller";
            default:
                return "Onbekend";
        }
    }
}