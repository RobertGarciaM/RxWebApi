using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RxWebApi.Enums
{
    public class Enums
    {
        public enum MessageApplication
        {
            [Description("We are going  through turbulent cloud, sorry..")]
            ErrorApplication = 1,
        }
    }
}
