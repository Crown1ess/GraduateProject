﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EmployeeSchedule
    {
        private int days;
        public int Days
        {
            get => days;
            set => days = value;
        }

        private string actionOnDay;
        public string ActionOnDay
        {
            get => actionOnDay;
            set => actionOnDay = value;
        }
    }
}
