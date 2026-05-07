using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
   public class Works
    {
        public string? Id { get; set; }
        public string? JobType {  get; set; }
        public string? Gender { get; set; }
        public int MoneyPerHour {  get; set; }
        public DateTime WorkDate {  get; set; }
        
        public int Time1 = DateTime.Now.Hour;
        public string? LocationW {  get; set; }

    }
}
