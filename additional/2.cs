using System;

namespace quiz
{
    // https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/using-structs
    public struct S : IDisposable
    {
        // default values:
        // https://stackoverflow.com/questions/39846708/how-to-make-a-default-value-for-the-struct-in-c
        private bool m_dispose;

        private bool dispose
        {
            get
            {
                Console.WriteLine($"getting! {m_dispose}");
                return m_dispose;
            }
            set
            {
                Console.WriteLine($"setting! old: {m_dispose} new: {value}");
                m_dispose = value;
            }
        }

        // https://habr.com/ru/post/89720/
        public void Dispose()
        {
            this.dispose = true;
        }

        public bool GetDispose()
        {
            Console.Write("Get S: ");
            return dispose;
        }
    }
}
