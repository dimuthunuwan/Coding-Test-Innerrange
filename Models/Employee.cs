using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace full_stack.Models
{
    public class Employee : ValidateEmployee
    {
        //name of the emplyee
        public String Name { get; set; }

        //state of the emplyee
        public int State { get; set; }

        //salary of the emplyee
        public Double Salary { get; set; }

        //DOB of the emplyee
        [Name("Date of birth")]
        public String DOB { get; set; }

        //post code of the emplyee
        [Name("Postcode")]
        public String PostCode { get; set; }
    }
}
