namespace MobilePhoneDevice
{
    using System;
    using System.Diagnostics;

    internal class Call
    {
        //Fields
        public const double costPerMinute = 0.37;
        private string date;
        private string time;
        private string number;
        private double duration;

        //Properties
        public string Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public string Time
        {
            get { return this.time; }
            set { this.time = value; }
        }

        public string Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public double Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }
    }
}
