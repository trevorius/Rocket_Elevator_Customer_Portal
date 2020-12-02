using System;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace CustomerPortal.Models
{
    public class Battery

    {
        private DateTime _date = DateTime.Now;
        public long Id { get; set; }
        public string building_id { get; set; } 
        public string type_of_building { get; set; }
        public string status { get; set; }
        public string employee_id { get; set; }
        public DateTime commissioning_date { get; set; }
        public DateTime last_inspection_date { get; set; }
        public string operations_certificate { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public DateTime created_at  { get; set; }
        public DateTime updated_at { get {return _date; } set { _date = value; } } 
        public long customer_id { get; set; }

    }
}