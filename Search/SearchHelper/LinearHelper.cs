/***********************************************************************************************************************************
 * 
 * 功能：查找算法——线性查找(顺序查找、折半查找)
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * http://www.cnblogs.com/huangxincheng/archive/2011/11/20/2256351.html
 * 
 * 备注：
 * 线性查找：顺序查找；折半查找；
 * 
 * 破坏性查找：
 * 非破坏性查找：
 * 线性结构的查找不适合做破坏性操作；
 * 
 ***********************************************************************************************************************************/

namespace Search.SearchHelper
{
    using System.Collections.Generic;

    /// <summary>
    /// 查找算法——线性查找
    /// </summary>
    public class LinearHelper
    {
        public static List<int> list = new List<int>() { 2, 3, 5, 8, 7 };

        /// <summary>
        /// 顺序查找
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int SequenceSearch(List<int> list, int key)
        {
            for (int i = 0; i < list.Count; i++)
            {
                //查找成功，返回序列号
                if (key == list[i])
                    return i;
            }
            //未能查找，返回-1
            return -1;
        }

        /// <summary>
        /// 顺序表的查找-顺序查找(参考数据结构课本)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int SequentialSearch(int[] nums, int key)
        {
            //设置哨兵
            nums[0] = key;
            int i = 0;
            for (i = nums.Length; nums[i] != key; i--)
            { }
            return i;
        }

        /// <summary>
        /// 有序表的查找-折半查找
        /// 注意：数组必须有序，不是有序就必须让其有序；
        ///       只限于线性的顺序存储结构。
        /// </summary>
        /// <returns></returns>
        public static int BinarySearch(List<int> list, int key)
        {
            //最低线
            int low = 0;

            //最高线
            int high = list.Count - 1;

            while (low <= high)
            {
                //取中间值
                var middle = (low + high) / 2;

                if (list[middle] == key)
                {
                    return middle;
                }

                if (list[middle] > key)
                {
                    //下降一半
                    high = middle - 1;
                }
                else
                {
                    //上升一半
                    low = middle + 1;
                }
            }
            //未找到
            return -1;
        }

        /// <summary>
        /// 有序表的查找-折半查找(参考数据结构课本)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int BinarySearch(int key)
        {
            int[] nums = { 1, 3, 5, 7, 9, 12, 15, 22, 31, 50, 65, 77, 79, 81, 91, 93, 99 };
            int low = 0;
            int high = nums.Length - 1;
            int mid = (low + high) / 2;
            while (low <= high)
            {
                if (nums[mid] < key)
                {
                    low = mid + 1;
                    mid = (low + high) / 2;
                }
                else if (nums[mid] > key)
                {
                    high = mid - 1;
                    mid = (low + high) / 2;
                }
                else
                {
                    return mid;
                }
            }
            return 0;
        }
    }
}
