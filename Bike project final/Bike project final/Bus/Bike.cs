using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BikeLibrary
{
    
    public enum EnumType { Undefined,Road_Bike,Mountain_Bike}
    public enum EnumBrand { Undefined, Trek, Liv, Frog, Carbonnedale}
    public enum EnumColor { Undefined,Black,Blue,Red,Purple}
    public enum EnumFrame { Undefined,Aluminum,Carbon_Fiber,Steel,Titanium}
    public enum EnumBrakes { Undefined,Calipur,Disc_Brakes,Drum_Brakes}
    [Serializable]
    public class Bike
    {
        
        private int SerialNmbr;

        private MadeDate date;

        private EnumBrand brand; 
        private EnumColor color;
        private EnumFrame frame;
        private EnumBrakes brakes;
        private EnumType Type;

        private int speed;
        public int SerialNmbr1 { get => SerialNmbr; set => SerialNmbr = value; }
        
        public int Speed { get => speed; set => speed = value; }
        public EnumColor Color { get => color; set => color = value; }
        public MadeDate Date { get => date; set => date = value; }
        public EnumFrame Frame { get => frame; set => frame = value; }
        public EnumBrakes Brakes { get => brakes; set => brakes = value; }
        public EnumType Type1 { get => Type; set => Type = value; }
        public EnumBrand Brand { get => brand; set => brand = value; }

        public Bike()
        {
            this.SerialNmbr = 0;
            
            this.speed = 0;
            this.color=EnumColor.Undefined;
            this.date=new MadeDate();
            this.frame=EnumFrame.Undefined;
            this.brakes=EnumBrakes.Undefined;
            this.Type1 = EnumType.Undefined;
            this.brand = EnumBrand.Undefined;
    }
        public Bike(int serial,int speed,EnumColor color,MadeDate date,EnumFrame frame,EnumBrakes brakes,EnumType type, EnumBrand brand)
        {
            this.SerialNmbr = serial;
            
            this.Speed = speed;
            this.Color = color;
            this.Date = date;
            this.Frame = frame;
            this.Brakes = brakes;
            this.Type1 = type;
            this.Brand = brand;

        }

        public override string ToString()
        {
            String state = SerialNmbr + "\t" + Brand + "\t" + "\t" + Speed + "\t" + Color + "\t" + Date + "\t" + Frame + "\t" + Brakes + "\t" + Type1;
            return state; 
        }

    }


}
