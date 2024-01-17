using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttMachineCore.Model
{
    public class InOutInfor
    {
        public string EnrollNumber { get; set; }
        public DateTime DatePunch { get; set; }
        public DateTime DateTimePunch { get; set; }
        public TimeSpan TimePunch { get; set; }
    }
}
