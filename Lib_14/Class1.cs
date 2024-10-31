using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lib_14
{
    public class Liquid
    {
        

        public string Name { get; set; }
        
        private int _density;
        public int Density
        {
            get
            {
                return _density;
            }
            set
            {
                if (value > 0) _density = value;
            }
        }
        private int _volume;
        public int Volume
        {
            get 
            {
                return _volume; 
            }
            set 
            {
                if (value > 0) _volume = value; 
            }
        }

        public Liquid(string name, int density, int volume) : base()
        {
            Name = name;
            Density = density;
            Volume = volume;
        }
        


        /// <summary>
        /// метод для присваивания характеристик
        /// </summary>
        /// <param name="name">название жидкости</param>
        /// <param name="density">плотность жидкости</param>
        /// <param name="volume">объём жидкости</param>
        public void SetParams(string name, int density, int volume)
        {
            Name = name;
            Density = density;
            Volume = volume;
        }
    }
    public class Alcohol : Liquid
    {
        private double _strength;
        public double Strength
        {
            get { return _strength; }
            set { if (value > 0) _strength = (int)value; }
        }
      
        public Alcohol(string name, int density, int volume, double strength) : base(name, density, volume)
        {
            Strength = strength;
        }
       
        /// <summary>
        /// метод для присваивания характеристик
        /// </summary>
        /// <param name="name">название алкоголя</param>
        /// <param name="density">плотность алкоголя</param>
        /// <param name="volume">объём алкоголя</param>
        /// <param name="strength">крепость алкоголя</param>
        public void SetStrength(string name, int density, int volume, double strength)
        {
            Name = name;
            Density = density;
            Volume = volume;
            Strength = strength;
        }
    }
    public class Beer : Alcohol
    {
        private double _hopsPercentage;

        public double HopsPercentage 
        {
            get { return _hopsPercentage; }
            set { if (value > 0) _hopsPercentage = (int)value; }
        }

        

        public Beer(string name, int density, int volume, int strength, double hopsPercentage)
            : base(name, density, volume, strength)
        {
            HopsPercentage = hopsPercentage;
        }
       
        /// <summary>
        /// метод для присваивания характеристик
        /// </summary>
        /// <param name="name">название пива</param>
        /// <param name="density">плотность пива</param>
        /// <param name="volume">объём пива</param>
        /// <param name="strength">крепость пива</param>
        /// <param name="hopsPercentage">содержание хмеля в пиве</param>

        public void SetHopsPercentage(string name, int density, int volume, double strength, double hopsPercentage)
        {
            Name = name;
            Density = density;
            Volume = volume;
            Strength = strength;
            HopsPercentage = hopsPercentage;
        }
    }

}
