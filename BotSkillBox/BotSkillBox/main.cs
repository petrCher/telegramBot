using System;
using System.Collections.Generic;
using System.Text;

namespace BotSkillBox
{
    class main
    {
        private double _temp;
        public double Temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value - 273.15;
            }
        }
        private double _pressure;
        public double Pressure
        {
            get
            {
                return _pressure;
            }
            set
            {
                _pressure = value / 1.3332239;
            }
        }
        public double Humidity { get; set; }
    }
}
