using PP.DAL.Models.Enums;

namespace PP.WebApi.ViewModels
{
    public class EmployeeView
    {
        public int Id { get; set; } 

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public EmployeeRole Role { get; set; }

        public string Office { get; set; }
    }
}
