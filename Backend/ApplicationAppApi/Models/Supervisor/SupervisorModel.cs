﻿using System.ComponentModel.DataAnnotations;

namespace ApplicationAppApi.Models.Supervisor
{
    public class SupervisorModel
    {
        [Key]
        public int Id { get; set; }
        public string SupervisorRank { get; set; }
        public string Origin { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
    }
}
