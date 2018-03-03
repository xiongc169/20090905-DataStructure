/***********************************************************************************************************************************
 * 
 * 功能：排序算法——归并排序
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * http://www.cnblogs.com/huangxincheng/archive/2011/11/20/2255695.html
 * 
 * 备注：
 * 
 ***********************************************************************************************************************************/


namespace MergeSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 排序算法——归并排序
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 2, 1, 8, 9, 0 };

            MergeHelperr.MergeSort(array, new int[array.Length], 0, array.Length - 1);

            Console.ReadKey(true);
        }
    }
}
