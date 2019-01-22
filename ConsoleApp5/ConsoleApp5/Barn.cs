using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Barn : Person
    {
        public Barn(string a, int b, int c, int d)
            : base(a, b, c, d)
        {
            if (YearBorn > 2000)
            {
                Barn bar = new Barn(a, b, c, d);
                Person per = bar as Person;

            }
        }
    }
}
