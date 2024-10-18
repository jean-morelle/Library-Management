using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager.Core.Interface
{
    public  interface IAlertServices
    {
        event Action<string> OnAlert;

        void ShowAlert(string message);
    }
}
