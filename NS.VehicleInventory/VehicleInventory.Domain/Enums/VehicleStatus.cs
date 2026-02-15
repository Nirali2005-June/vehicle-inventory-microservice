using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Domain.Enums;

public enum VehicleStatus
{
    Available = 1,
    Rented = 2,
    Reserved = 3,
    InService = 4
}