﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.utils
{
    public class Logger
    {
        public static void Log(string msg)
        {
            Console.WriteLine(DateTime.Now.ToString("[yyyy-MM-dd HH':'mm':'ss] - ") + msg);
        }
    }
}
