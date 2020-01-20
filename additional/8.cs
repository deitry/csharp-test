using System.Collections.Generic;

namespace quiz
{
    class Wrap
    {
        private static int init = 0;
        public int Value
        {
            get => ++init;
        }
    }
}
