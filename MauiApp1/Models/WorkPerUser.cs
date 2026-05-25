using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class WorkPerUser
    {
        public string? Id { get; set; }
        public string? IdUser { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Gender { get; set; }
        public int BornYear { get; set; }
        public string? BankAccount { get; set; }
        public int BankBranch { get; set; }
        public int BankNumber { get; set; }
        public string? Password { get; set; }

        public string? IdWork { get; set; }
        public string? JobType { get; set; }
        public int MoneyPerHour { get; set; }
        public DateTime WorkDate { get; set; }

        public int Time1 = DateTime.Now.Hour;
        public string? LocationW { get; set; }
    }
}
