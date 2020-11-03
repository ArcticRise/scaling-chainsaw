using System;
using System.ComponentModel.DataAnnotations;

namespace challenge.Models
{
    public class Compensation
    {
        [Key]
        public string EmployeeId { get; set; }
        public Decimal Salary { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}