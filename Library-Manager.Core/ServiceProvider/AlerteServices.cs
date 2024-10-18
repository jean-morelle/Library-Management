using Library_Manager.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager.Core.ServiceProvider
{
    public class AlerteServices : IAlertServices
    {
        public event Action<string> OnAlert;

        public void ShowAlert(string message)
        {
            OnAlert?.Invoke(message);
        }
    }
}
