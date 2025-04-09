﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    public class Node
    {
        public User Data { get; set; }
        public Node Next { get; set; } //default value: null

        public Node( User data)
        {
            this.Data = data;
        }
    }
}
