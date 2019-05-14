using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BikeLibrary
{
    
    public enum EnumMonth { Undefined,Jan,Feb,March,April,May,June,July,Aug,Sept,Oct,Nov,Dec}
    [Serializable]
    public class MadeDate
    {
      
        private int day;
        private int year;
        private EnumMonth month;

        public int Day { get => day; set => day = value; }
        public int Year { get => year; set => year = value; }
        public EnumMonth Month { get => month; set => month = value; }

        public MadeDate()
        {
            day = 0;
            Month = EnumMonth.Undefined;
            year = 0;
        }
        public MadeDate(int day,EnumMonth month,int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        public override string ToString()
        {
            String state= day + "/" + Month + "/" + year;
            return state;
        }
    }
}
