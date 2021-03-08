using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFSClubManager.Dal.Models
{
    public class UserSettings
    {
        public enum ThemeType
        {
            Light =1,
            Dark=2
        }

        public int Id { get; set; }

        public int Currency { get; set; }

        public int Langague { get; set; }

        public int FontSize { get; set; }

        public bool? ChatOnOff { get; set; }


        public bool? EmailNotificaitons { get; set; }

        public ThemeType ColorTheme { get; set; }


    }
}
