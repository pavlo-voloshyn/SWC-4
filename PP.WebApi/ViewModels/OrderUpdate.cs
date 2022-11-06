using PP.DAL.Models.Enums;

namespace PP.WebApi.ViewModels
{
    public class OrderUpdate
    {
        public int Id { get; set; }

        public ServiceType ServiceType { get; set; }

        public bool IsUrgent { get; set; }

        public Status Status { get; set; }

        public int PassportId { get; set; }
    }
}
