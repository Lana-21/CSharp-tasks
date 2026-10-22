using System;
using System.Collections.Generic;
using System.Text;

namespace Practice8Interface
{
    public interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int search);
    }
}
