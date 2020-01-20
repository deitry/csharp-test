using System;
using System.Collections.Generic;

namespace quiz
{
    // https://metanit.com/sharp/interview/1.1.php
    partial class Program
    {
        static void Run1_1()
        {
            // B obj1 = new A(); // illegal
            A1 obj1 = new A1();
            obj1.Foo();

            B1 obj2 = new B1();
            obj2.Foo();

            A1 obj3 = new B1();
            obj3.Foo();

            // a, b, b
        }

                static void Run1_2()
        {
            // doesn't compile at all if change S from struct to class
            // unsafe
            {
                var s = new S();
                // Console.WriteLine($"s before using {new IntPtr(&s)}"); // another way to print an address
                // Console.WriteLine($"s before using {(long)&s:X}");
                using (s)
                {
                    Console.WriteLine(s.GetDispose()); // > false
                    // Console.WriteLine($"s inside using {(long)&s:X}");
                }
                // Console.WriteLine($"s after using {(long)&s:X}");
                Console.WriteLine(s.GetDispose()); // > false
                // even though Dispose is called!
            }
        }

        static void Run1_3()
        {
            List<Action> actions = new List<Action>();
            for (var count = 0; count < 10; count++)
            {
                if (count % 2 == 0)
                {
                    // these actions will share they count == 10
                    actions.Add(() => Console.WriteLine(count));
                }
                else
                {
                    // these will get local values == 1, 3, 5, 7, 9
                    var i = count;
                    actions.Add(() => Console.WriteLine(i));
                }
            }

            foreach (var action in actions)
            {
                action();
            }
        }

        static void Run1_4()
        {
            // https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/types/boxing-and-unboxing

            int i = 1;
            object obj = i;
            ++i;
            Console.WriteLine($"{i} {i.GetType()}");
            Console.WriteLine($"{obj} {obj.GetType()}");
            Console.WriteLine((short)obj); // System.InvalidCastException
        }
    }
}
