using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Contracts
{
    public interface ISmsService
    {
        void SendSMS(SMSBody sMSBody);
    }
    public class SMSBody
    {
        public string PhoneNumber { get; set; }
        public string Body { get; set; }
    }
}
