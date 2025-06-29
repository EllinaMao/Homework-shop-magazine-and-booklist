using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{   
    public interface INameIO
    {
        string Name { get; set; }
        void InputName();
    }
    public interface IDescriptionIO
    {
        string Description { get; set; }
        void InputDescription();
    }
    public interface IIPAddressIO
    {
        string IPAddress { get; set; }
        void InputIPAddress();
    }

    public interface IPhoneIO
    {
        long Phone { get; set; }
        void InputPhone();
    }
    public interface IEmailIO
    {
        MailAddress Email { get; set; }
        void InputEmail();
    }

    public interface IDisplayInfo
    {
        void DisplayInfo();
    }
}
