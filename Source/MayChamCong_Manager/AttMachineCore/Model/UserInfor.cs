using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttMachineCore.Model
{
    public class UserInfor
    {
        //(iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled)
        public UserInfor() {
            _lFinger = new List<Finger>();
        }
        public string EnrollNumber { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Privilege { get; set; }
        public bool Enabled { get; set; }
        public string CardNumber { get; set; }
        public List<Finger> _lFinger { get; set; }
    }
    public class Finger
    {
        public int FingerIdx { get; set; }
        public byte FingerData { get; set; }
        public string FingerStr { get; set; }
        public int FingerLength { get; set; }
    }
}
