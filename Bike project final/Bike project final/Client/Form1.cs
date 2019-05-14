using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BikeLibrary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace Bike_project_final
{
    
    public partial class Form1 : Form
    {
        
        static string binFile = @"../../data/bike1.bin";

        List<Mountain_Bike> ListMountainBike = new List<Mountain_Bike>();
        List<Road_Bike> ListRoadBikes = new List<Road_Bike>();
        List<Bike> ListBike = new List<Bike>();

        int index;
        int specindex;
        bool mountain = false;
        //public static void DisplayError(KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')//e.Keychar!=46
        //    {
        //        MessageBox.Show("Digit only!");
        //        e.Handled = true;
        //    }
        //}
        //public static void DisplayErrornodot(KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)//e.Keychar!=46
        //    {
        //        MessageBox.Show("Digit only!");
        //        e.Handled = true;
        //    }
        //}
        static void AddDays(int i,ComboBox comboBoxDay)

        {
            comboBoxDay.Enabled = true;
            comboBoxDay.Items.Add(i);
        }
       
        
        public Form1()
        {
            InitializeComponent();
        }

        private void listBoxBikes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            specindex=i;
            bool found = false;
            mountain = false;
            index = listBoxBikes.SelectedIndex;
            this.comboBoxType.Text = Convert.ToString(ListBike[index].Type1);
            this.comboBoxBrand.Text = Convert.ToString(ListBike[index].Brand);
            this.textBoxSerial.Text = Convert.ToString(ListBike[index].SerialNmbr1);
            this.textBoxSpeed.Text = Convert.ToString(ListBike[index].Speed);
            this.comboBoxColor.Text = Convert.ToString(ListBike[index].Color);
            this.comboBoxMonth.Text = Convert.ToString(ListBike[index].Date.Month);
            this.comboBoxDay.Text = Convert.ToString(ListBike[index].Date.Day);
            this.textBoxYear.Text = Convert.ToString(ListBike[index].Date.Year);
            this.comboBoxFrame.Text = Convert.ToString(ListBike[index].Frame);
            this.comboBoxBrakes.Text = Convert.ToString(ListBike[index].Brakes);

            foreach (Mountain_Bike item in this.ListMountainBike)
            {
               
                if (ListBike[index].SerialNmbr1==item.SerialNmbr1)
                {
                    specindex = i;
                    found = true;
                    mountain = true;
                }
                i++;
            }
            i = 0;
            if (found==false)
            {
                foreach(Road_Bike item in this.ListRoadBikes)
                {
                    if(ListBike[index].SerialNmbr1==item.SerialNmbr1)
                    {
                        specindex = i;
                        found = true;
                    }
                    i++;
                }
            }
            if (mountain==true)
            {
                this.comboBoxSuspension.Text = Convert.ToString(ListMountainBike[specindex].Suspension);
                this.textBoxHeight.Text = Convert.ToString(ListMountainBike[specindex].Height);
                
            }
            else
            {
                this.textBoxSeatHeight.Text = Convert.ToString(ListRoadBikes[specindex].SeatHeight);
            }
            MessageBox.Show("Selected index " + index);
            this.textBoxSerial.Enabled = false;


        }
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBoxType.Text == Convert.ToString(EnumType.Mountain_Bike))
                {
                    Mountain_Bike abike = new Mountain_Bike();
                    
                    abike.Type1 = (EnumType)this.comboBoxType.SelectedIndex;
                    abike.SerialNmbr1 = Convert.ToInt32(this.textBoxSerial.Text);
                    abike.Speed = Convert.ToInt32(this.textBoxSpeed.Text);
                    abike.Color = (EnumColor)this.comboBoxColor.SelectedIndex;
                    abike.Date.Month = (EnumMonth)this.comboBoxMonth.SelectedIndex;
                    abike.Date.Day = Convert.ToInt32(this.comboBoxDay.Text);
                    abike.Date.Year = Convert.ToInt32(this.textBoxYear.Text);
                    abike.Frame = (EnumFrame)this.comboBoxFrame.SelectedIndex;
                    abike.Brakes = (EnumBrakes)this.comboBoxBrakes.SelectedIndex;
                    abike.Suspension = (EnumSuspension)this.comboBoxSuspension.SelectedIndex;
                    abike.Height = Convert.ToDouble(this.textBoxHeight.Text);
                    abike.Brand = (EnumBrand)this.comboBoxBrand.SelectedIndex;
                    ListMountainBike.Add(abike);
                    ListBike.Add(abike);
                    MessageBox.Show("Mountain Bike Added!");

                    
                }
                else if (this.comboBoxType.Text == Convert.ToString(EnumType.Road_Bike))
                {
                    Road_Bike abike = new Road_Bike();
                    abike.Type1 = (EnumType)this.comboBoxType.SelectedIndex;
                    abike.SerialNmbr1 = Convert.ToInt32(this.textBoxSerial.Text);
                    abike.Speed = Convert.ToInt32(this.textBoxSpeed.Text);
                    abike.Color = (EnumColor)this.comboBoxColor.SelectedIndex;
                    abike.Date.Month = (EnumMonth)this.comboBoxMonth.SelectedIndex;
                    abike.Date.Day = Convert.ToInt32(this.comboBoxDay.Text);
                    abike.Date.Year = Convert.ToInt32(this.textBoxYear.Text);
                    abike.Frame = (EnumFrame)this.comboBoxFrame.SelectedIndex;
                    abike.Brakes = (EnumBrakes)this.comboBoxBrakes.SelectedIndex;
                    abike.SeatHeight = Convert.ToDouble(this.textBoxSeatHeight.Text);
                    abike.Brand = (EnumBrand)this.comboBoxBrand.SelectedIndex;
                    ListRoadBikes.Add(abike);
                    ListBike.Add(abike);
                    MessageBox.Show("Road Bike Added!");

                    

                }
            }catch
          {
              MessageBox.Show("Please enter in all the Fields");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (EnumBrand item in Enum.GetValues(typeof(EnumBrand)))
            {
                this.comboBoxBrand.Items.Add(item);
            }
            this.comboBoxBrand.Text = Convert.ToString(this.comboBoxBrand.Items[0]);
            foreach (EnumBrakes item in Enum.GetValues(typeof(EnumBrakes)))
            {
                this.comboBoxBrakes.Items.Add(item);
            }
            this.comboBoxBrakes.Text = Convert.ToString(this.comboBoxBrakes.Items[0]);
            foreach (EnumColor item in Enum.GetValues(typeof(EnumColor)))
            {
                this.comboBoxColor.Items.Add(item);
            }
            this.comboBoxColor.Text = Convert.ToString(this.comboBoxColor.Items[0]);
            foreach (EnumType item in Enum.GetValues(typeof(EnumType)))
                {
                this.comboBoxType.Items.Add(item);
            }
            this.comboBoxType.Text = Convert.ToString(this.comboBoxType.Items[0]);
            foreach (EnumFrame item in Enum.GetValues(typeof(EnumFrame)))
            {
                this.comboBoxFrame.Items.Add(item);
            }
            this.comboBoxFrame.Text=Convert.ToString(this.comboBoxFrame.Items[0]);
            foreach (EnumSuspension item in Enum.GetValues(typeof(EnumSuspension)))
            {
                this.comboBoxSuspension.Items.Add(item);
            }
            this.comboBoxSuspension.Text = Convert.ToString(this.comboBoxSuspension.Items[0]);
            foreach(EnumMonth item in Enum.GetValues(typeof(EnumMonth)))
                {
                this.comboBoxMonth.Items.Add(item);
            }
            this.comboBoxMonth.Text = Convert.ToString(this.comboBoxMonth.Items[0]);
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex==0)
            {
                
               
                this.textBoxSerial.Enabled = false;
                this.textBoxSpeed.Enabled = false;
                this.comboBoxColor.Enabled = false;
                this.comboBoxDay.Enabled = false;
                this.comboBoxMonth.Enabled = false;
                this.textBoxYear.Enabled = false;
                this.comboBoxFrame.Enabled = false;
                this.comboBoxBrakes.Enabled = false;
                this.textBoxSeatHeight.Enabled = false;
                this.comboBoxSuspension.Enabled = false;
                this.textBoxHeight.Enabled = false;
                this.buttonAdd.Enabled = false;

            }
            else if (comboBoxType.SelectedIndex==1)
            {

                this.comboBoxBrand.Enabled = true;
                this.textBoxSerial.Enabled = true;
                this.textBoxSpeed.Enabled = true;
                this.comboBoxColor.Enabled = true;
                this.comboBoxMonth.Enabled = true;
                this.textBoxYear.Enabled = true;
                this.comboBoxFrame.Enabled = true;
                this.comboBoxBrakes.Enabled = true;
                this.textBoxSeatHeight.Enabled = true;
                this.comboBoxSuspension.Enabled = false;
                this.textBoxHeight.Enabled = false;
                this.buttonAdd.Enabled = true;

            }
            else if (comboBoxType.SelectedIndex==2)
            {
                this.comboBoxBrand.Enabled = true;
                this.textBoxSerial.Enabled = true;
                this.textBoxSpeed.Enabled = true;
                this.comboBoxColor.Enabled = true;
                this.comboBoxMonth.Enabled = true;
                this.textBoxYear.Enabled = true;
                this.comboBoxFrame.Enabled = true;
                this.comboBoxBrakes.Enabled = true;
                this.textBoxSeatHeight.Enabled = false;
                this.comboBoxSuspension.Enabled = true;
                this.textBoxHeight.Enabled = true;
                this.buttonAdd.Enabled = true;
            }
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDay.Items.Clear();
            if (comboBoxMonth.SelectedIndex==1|| comboBoxMonth.SelectedIndex == 3|| comboBoxMonth.SelectedIndex == 5|| comboBoxMonth.SelectedIndex == 7|| comboBoxMonth.SelectedIndex == 8|| comboBoxMonth.SelectedIndex == 10|| comboBoxMonth.SelectedIndex == 12)
            {
                for (int i=1; i<=31;i++)
                {
                    AddDays(i, comboBoxDay);

                }
            }
            else if (comboBoxMonth.SelectedIndex==2)
            {
                for (int i=1;i<=28;i++)
                {
                    AddDays(i, comboBoxDay);
                }
            }
            else
            {
                for (int i=1; i<=30;i++)
                {
                    AddDays(i, comboBoxDay);
                }
            }
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
                       
                foreach (Road_Bike item in this.ListRoadBikes)
                {
                    this.listBoxBikes.Items.Add(item);
                }
                foreach (Mountain_Bike item in this.ListMountainBike)
                {
                    this.listBoxBikes.Items.Add(item);
                }
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {


            ListBike[index].Speed = Convert.ToInt32(this.textBoxSpeed.Text); ;
            ListBike[index].Color=(EnumColor)this.comboBoxColor.SelectedIndex;
            ListBike[index].Date.Month=(EnumMonth)this.comboBoxMonth.SelectedIndex;
            ListBike[index].Date.Day=Convert.ToInt32(this.comboBoxDay.SelectedIndex);
            ListBike[index].Date.Year=Convert.ToInt32(this.textBoxYear.Text);
            ListBike[index].Frame=(EnumFrame)this.comboBoxFrame.SelectedIndex;
            ListBike[index].Brakes=(EnumBrakes)this.comboBoxBrakes.SelectedIndex;
            ListBike[index].Brand = (EnumBrand)this.comboBoxBrand.SelectedIndex;
            if(mountain==true)
            {
                ListMountainBike[specindex].Suspension=(EnumSuspension)this.comboBoxSuspension.SelectedIndex;
                ListMountainBike[specindex].Height=Convert.ToDouble(this.textBoxHeight.Text);
            }
            else
            {
                ListRoadBikes[specindex].SeatHeight=Convert.ToDouble(this.textBoxSeatHeight.Text);

            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            this.ListBike.RemoveAt(index);
            if (mountain==true)
            {
                this.ListMountainBike.RemoveAt(specindex);
            }
            else
            {
                this.ListRoadBikes.RemoveAt(specindex);
            }
            MessageBox.Show("Bike removed!");
            this.textBoxSerial.Enabled = true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.listBoxBikes.Items.Clear();
            this.comboBoxType.SelectedIndex = 0;
            this.textBoxSerial.Text = "";
            this.textBoxSpeed.Text = "";
            this.comboBoxColor.SelectedIndex = 0;
            this.comboBoxMonth.SelectedIndex = 0;
            this.comboBoxDay.SelectedIndex = 0;
            this.textBoxYear.Text = "";
            this.comboBoxFrame.SelectedIndex = 0;
            this.comboBoxBrakes.SelectedIndex = 0;
            this.comboBoxSuspension.SelectedIndex = 0;
            this.textBoxHeight.Text = "";
            this.textBoxSeatHeight.Text = "";
            this.textBoxSerial.Enabled = true;

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            bool found = false;
            try
            {
                foreach (Mountain_Bike item in this.ListMountainBike)
                {
                    if (item.SerialNmbr1 == Convert.ToInt32(textBoxSearch.Text))
                    {
                        found = true;
                        this.listBoxBikes.Items.Add(item);

                    }

                }
                if (found == false)
                {
                    foreach (Road_Bike item in this.ListRoadBikes)
                    {
                        if (item.SerialNmbr1 == Convert.ToInt32(textBoxSearch.Text))
                        {
                            found = true;
                            this.listBoxBikes.Items.Add(item);
                        }
                    }
                }
                if (found == false)
                {
                    MessageBox.Show("No Serial Number Stored.");
                }
            }catch
            {
                MessageBox.Show("Enter Only Numbers");
            }
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void textBoxSeatHeight_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBoxSeatHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists(binFile))
            {
                FileStream fs = new FileStream(binFile, FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();

                ListBike = (List<Bike>)bin.Deserialize(fs);

                fs.Close();
            }
            foreach (Bike item in ListBike)
            {
                this.listBoxBikes.Items.Add(item);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(binFile, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter writer = new BinaryFormatter();

            writer.Serialize(fs, ListBike);

            fs.Close();
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
