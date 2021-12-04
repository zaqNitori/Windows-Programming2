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
        public static void Swap<T>(ref T template1, ref T template2)
        {
            T temp;
            temp = template1;
            template1 = template2;
            template2 = temp;
        }

        // 判斷座標是否需要轉換
        public static void ResetMarginPoint(ref double x1, ref double y1, ref double x2, ref double y2)
        {
            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
            }

            if (y1 > y2)
            {
                Swap(ref y1, ref y2);
            }
        }
    }
}
