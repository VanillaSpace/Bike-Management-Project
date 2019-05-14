using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BikeLibrary
{
    [Serializable]
    public class  Road_Bike : Bike
    {
        private double seatHeight;

        public double SeatHeight { get => seatHeight; set => seatHeight = value; }

       public Road_Bike() : base()
        {
            seatHeight = 0;
        }
       public Road_Bike(double seatheight, int serial,  int speed, EnumColor color, MadeDate date, EnumFrame frame, EnumBrakes brakes,EnumType type, EnumBrand brand) : base(serial,  speed, color, date, frame, brakes,type, brand)
        {
            this.SeatHeight = seatheight;
        }
        public override string ToString()
        {
            String state= Convert.ToString(SeatHeight);
            return base.ToString() +"\t" +state;
           
        }

    }
}
