using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Common
    {
        //交換
        public static void Swap<T>(ref T t1, ref T t2)
        {
            T temp;
            temp = t1;
            t1 = t2;
            t2 = temp;
        }
    }
}
