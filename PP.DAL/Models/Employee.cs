using PP.DAL.Models.Enums;
using System.Collections.Generic;

namespace PP.DAL.Models;

public class Employee : EntityBase
{
    public string FirstName { get; set; }

    public string Surname { get; set; }

    public EmployeeRole Role { get; set; }

    public string Office { get; set; }
}
