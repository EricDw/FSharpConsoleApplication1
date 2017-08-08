using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibrary
{
    public class Numbers
    {

        public int GetOne()
        {
            return 1;
        }

    }

    public interface ICanMultiplyNumbers
    {
        int Multiply(int a, int b);
    }

}
