using System;
using System.Collections.Generic;
using System.Linq;

namespace quiz
{
    // https://metanit.com/sharp/interview/1.2.php
    partial class Program
    {
        static void Run2_5()
        {
            var s1 = string.Format("{0}{1}", "abc", "cba");
            var s2 = "abc" + "cba";
            var s3 = "abccba";
            var s4 = "abccba   ".Trim();

            Console.WriteLine(s1 == s2);
            Console.WriteLine($"{((object)s1).ToString()} {((object)s2).ToString()}");
            Console.WriteLine((object)s1.ToString() == (object)s2);
            Console.WriteLine(s2 == s3);
            Console.WriteLine((object)s2 == (object)s3);
            Console.WriteLine((object)s2 == (object)s4);
            Console.WriteLine((object)s2 == (object)(string.Intern(s4)));
        }

        private static Object syncObject = new Object();
        private static void Write()
        {
            // https://www.c-sharpcorner.com/UploadFile/de41d6/monitor-and-lock-in-C-Sharp/
            // https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/lock-statement
            lock (syncObject)
            {
                // tl;dr: lock could be re-entered from the same thread
                Console.WriteLine("test");
            }
        }

        static void Run2_6()
        {
            lock (syncObject)
            {
                Write();
            }
        }

        static void Run2_7()
        {
            var c = new C7();
            A7 a = c;

            a.Print2();
            a.Print1();
            c.Print2();
        }

        static IEnumerable<int> Square(IEnumerable<int> a)
        {
            foreach (var r in a)
            {
                Console.WriteLine(r * r);
                yield return r * r;
            }
        }

        static void Run2_8()
        {
            var w = new Wrap();
            var wraps = new Wrap[3];
            for (int i = 0; i < wraps.Length; i++)
            {
                wraps[i] = w;
            }

            var values = wraps.Select(x => x.Value);
            // var results = Square(values).ToList(); // kills the magic
            var results = Square(values);
            int sum = 0;
            int count = 0;
            foreach (var r in results)
            {
                count++;
                sum += r;
            }
            Console.WriteLine("Count {0}", count);
            Console.WriteLine("Sum {0}", sum);

            Console.WriteLine("Count {0}", results.Count());
            Console.WriteLine("Sum {0}", results.Sum());
        }
    }
}
