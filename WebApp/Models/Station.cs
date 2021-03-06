﻿using System.Collections.Generic;

namespace WebApp.Models
{
    public class Station
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public List<Line> Lines { get; set; }
    }
}