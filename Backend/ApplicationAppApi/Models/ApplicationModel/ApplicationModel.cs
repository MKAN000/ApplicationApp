﻿using System.ComponentModel.DataAnnotations;

namespace ApplicationAppApi.Models.ApplicationModel
{
    public class ApplicationModel
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationPurpose { get; set; }
        public string ToWhom { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string Reason { get; set; }
        public bool IsOnDuty { get; set; }
        public bool IsHavingClasses { get; set; }
        public string arrears { get; set; }
        public bool IsHavingDisciplinaryPenalty { get; set; }
        public string VacDestination { get; set; }
    }
}
