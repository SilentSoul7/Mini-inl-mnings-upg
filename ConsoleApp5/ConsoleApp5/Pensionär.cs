using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Pensionär : Person
    {
    
        public Pensionär(string a, int b, int c, int d)
            : base(a, b, c, d)
        {
            if (YearBorn < 1950)
            {
                Pensionär p = new Pensionär(a, b, c, d);
                Person per =  p as Person;
               
            }
        }
    }
}

