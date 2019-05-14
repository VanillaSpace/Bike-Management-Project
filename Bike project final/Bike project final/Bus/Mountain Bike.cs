using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BikeLibrary
{
    
    public enum EnumSuspension { Undefined, Front, Rear, FrontRear }

    [Serializable]
    public class Mountain_Bike:Bike
    {
        private EnumSuspension suspension;
        private double height;

        public double Height { get => height; set => height = value; }
        public EnumSuspension Suspension { get => suspension; set => suspension = value; }

        public Mountain_Bike():base()
        {
            suspension = EnumSuspension.Undefined;
            height = 0;
        }
        public Mountain_Bike(EnumSuspension suspension,int height, int serial, int speed, EnumColor color, MadeDate date, EnumFrame frame, EnumBrakes brakes,EnumType type, EnumBrand brand):base(serial, speed, color,  date, frame, brakes,type,brand)
        {
            this.Suspension = suspension;
            this.height = Height;
        }
        public override string ToString()
        {
            String state;
            state= Suspension + "\t" + Height;
            return base.ToString() + "\t" + state;
        }
    }
}
