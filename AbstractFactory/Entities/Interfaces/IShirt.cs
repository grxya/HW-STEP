﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Interfaces
{
    interface IShirt
    {
        public string Size { get; set; }
        public void ShowInfo();
    }
}
