using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ListWorkers6
{
    public class CompanySecurity
    {
        // check username and passowrd
        public static bool Login(string username, string password)
        {
            using(ListWorkersEntities entities = new ListWorkersEntities())
            {
                if(username == "a" && password == "a")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}