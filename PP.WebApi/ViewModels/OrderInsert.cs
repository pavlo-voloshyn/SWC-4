using PP.DAL.Models.Enums;
using System;

namespace PP.WebApi.ViewModels
{
    public class OrderInsert
    {
        public ServiceType ServiceType { get; set; }

        public bool IsUrgent { get; set; }

        public Status Status { get; set; }

        public int PassportId { get; set; }
    }
}
