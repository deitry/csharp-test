using System;

namespace quiz
{
    public class A7
    {
        public virtual void Print1()
        {
            Console.Write("A");
        }

        public void Print2()
        {
            Console.Write("A");
        }
    }

    public class B7 : A7
    {
        public override void Print1()
        {
            Console.Write("B");
        }
    }

    public class C7 : B7
    {
        new public void Print2()
        {
            Console.Write("C");
        }
    }
}
