/***********************************************************************************************************************************
 * 
 * 功能：排序算法——插入排序
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

namespace InsertSort
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Output(InsertSort.StraightInsertionSort());
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        public static void Output(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("{0}  ", nums[i]);
            }
        }
    }
}
