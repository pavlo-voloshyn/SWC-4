using PP.DAL.Models.Enums;
using System;

namespace PP.WebApi.ViewModels
{
    public class OrderView
    {
        public int Id { get; set; }

        public ServiceType ServiceType { get; set; }

        public bool IsUrgent { get; set; }

        public Status Status { get; set; }

        public int PassportId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
