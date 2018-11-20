using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListWorkers6.Models
{
    public class WorkerViewModel
    {
        public int IdWorker { get; set; }
        public int IdCompany { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
    }
}