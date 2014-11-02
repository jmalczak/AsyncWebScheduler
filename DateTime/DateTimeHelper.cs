namespace AsyncWebScheduler.DateTime
{
    using System;

    using global::AsyncWebScheduler._Interfaces;

    public class DateTimeHelper : IDateTime
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}