using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaBel.Models
{
    [Table("Employees")]
    public class EmployeeModel
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("AspNetUsers")]
        public string IDuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        [ForeignKey("EmployeePosition")]
        public int Position { get; set; }
        [ForeignKey("EmployeeDepartment")]
        public int Department { get; set; }
        public decimal Salary { get; set; }
        public virtual ICollection<EmployeeGradeModel> Grade { get; set; }
        public virtual ICollection<EmployeeRiseModel> Rise { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public virtual ApplicationUser AspNetUsers { get; set; }
        public virtual EmployeePositionModel EmployeePosition { get; set; }
        public virtual EmployeeDepartmentModel EmployeeDepartment { get; set; }
    }

    [Table("EmployeePosition")]
    public class EmployeePositionModel
    {
        [Key]
        public int ID { get; set; }
        public string PositionName { get; set; }
    }

    [Table("EmployeeDepartment")]
    public class EmployeeDepartmentModel
    {
        [Key]
        public int ID { get; set; }
        public string DepartmentName { get; set; }
    }
    [Table("EmployeeGrade")]
    public class EmployeeGradeModel
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Employees")]
        public int IDEmployee { get; set; }
        [ForeignKey("AspNetUsers")]
        public string IDuid { get; set; }
        public int Value { get; set; }
        public DateTime TimeStamp{ get; set; }

       
        public virtual EmployeeModel Employees { get; set; }
        public virtual ApplicationUser AspNetUsers { get; set; }

    }
    
    [Table("EmployeeRise")]
    public class EmployeeRiseModel
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Employees")]
        public int IDEmployee { get; set; }
        public decimal Value { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual EmployeeModel Employees { get; set; }
    }

}
