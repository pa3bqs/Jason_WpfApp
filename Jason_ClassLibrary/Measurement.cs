using System;
using System.Collections.Generic;

namespace Json_ClassLibrary
{
    public class Measurment
    {
        public int Frequency { get; set; }
        public float Q_factor { get; set; }
        public float Volume { get; set; }
        public float Deactivation_field_strength { get; set; }
        public int Dect_status { get; set; }
    }

    public class Roll_info
    {
        public DateTime Start_date_time { get; set; } = DateTime.Now;
        public string Batch_info { get; set; }

        public Roll_info()
        {
            measurents = new List<Measurment>();
        }

        List< Measurment>  measurents;

        public List<Measurment> Meas
        {
            get
            {
                return measurents;
            }
            set
            {
                measurents = value;
            }
        }
    }
}
