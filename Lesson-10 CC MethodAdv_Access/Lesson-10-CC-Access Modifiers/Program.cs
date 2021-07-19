using Lesson_10_CC_MethodAdv_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_10_CC_Access_Modifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(45);
            Console.WriteLine(p.GetAge());
        }
    }
}
