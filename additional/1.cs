using System;

namespace quiz
{
    class A1
    {
        public virtual void Foo()
        {
            Console.WriteLine("Class A");
        }
    }

    class B1: A1
    {
        public override void Foo()
        {
            Console.WriteLine("Class B");
        }
    }
}
