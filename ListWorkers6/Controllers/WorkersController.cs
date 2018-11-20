using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ListWorkers6.Controllers
{
    public class WorkersController : ApiController
    {
        public int IdWorker { get; set; }
        public int IdCompany { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
    }
}
