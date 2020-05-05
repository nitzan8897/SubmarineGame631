using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BL
{
    public static class AccessConfiguration
    {
        public static string BoardSize => ConfigurationManager.AppSettings["BOARD_SIZE"];

        public static string SubmarinesNumber => ConfigurationManager.AppSettings["SUBMARINES_NUMBER"];

        public static string[] SubmarinesLengths => ConfigurationManager.AppSettings["SUBMARINES_LENGTH"].Split(',');
    }
}
