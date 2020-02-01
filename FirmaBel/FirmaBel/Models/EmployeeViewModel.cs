using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaBel.Models
{
    public class EmployeeViewModel
    {
        public List<EmployeeModel> Employees { get; set; }
        public List<EmployeePositionModel> Positions { get; set; }
    }
}
