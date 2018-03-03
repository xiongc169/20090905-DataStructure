/***********************************************************************************************************************************
 * 
 * 功能：排序算法——交换排序
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * http://www.cnblogs.com/huangxincheng/archive/2011/11/14/2249046.html
 * 
 * 备注：
 * 
 ***********************************************************************************************************************************/

namespace ExchangeSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 排序算法——交换排序
    /// </summary>
    public class ExchangeHelper
    {
        static int[] nums = { 13, 4, 2, 11, 32, 12, 31, 85, 9, 7, 5 };

        /// <summary>
        /// 冒泡排序
        /// </summary>
        public static void BubblingSort()
        {
            //冒多少次泡
            for (int i = 0; i < nums.Length - 1; i++)
            {
                //冒泡的方向：从左往右 OR 从右往左
                for (int j = 0; j < nums.Length - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int temp = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="list"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void QuickSort(List<int> list, int left, int right)
        {
            //左下标一定小于右下标，否则就超越了
            if (left < right)
            {
                //对数组进行分割，取出下次分割的基准标号
                int i = Division(list, left, right);

                //对“基准标号“左侧的一组数值进行递归的切割，以至于将这些数值完整的排序
                QuickSort(list, left, i - 1);

                //对“基准标号“右侧的一组数值进行递归的切割，以至于将这些数值完整的排序
                QuickSort(list, i + 1, right);
            }
        }

        ///<summary>
        /// 分割函数
        ///</summary>
        ///<param name="list">待排序的数组</param>
        ///<param name="left">数组的左下标</param>
        ///<param name="right"></param>
        ///<returns></returns>
        public int Division(List<int> list, int left, int right)
        {
            //首先挑选一个基准元素
            int baseNum = list[left];

            while (left < right)
            {
                //从数组的右端开始向前找，一直找到比base小的数字为止(包括base同等数)
                while (left < right && list[right] >= baseNum)
                    right = right - 1;

                //最终找到了比baseNum小的元素，要做的事情就是此元素放到base的位置
                list[left] = list[right];

                //从数组的左端开始向后找，一直找到比base大的数字为止（包括base同等数）
                while (left < right && list[left] <= baseNum)
                    left = left + 1;


                //最终找到了比baseNum大的元素，要做的事情就是将此元素放到最后的位置
                list[right] = list[left];
            }
            //最后就是把baseNum放到该left的位置
            list[left] = baseNum;

            //最终，我们发现left位置的左侧数值部分比left小，left位置右侧数值比left大
            //至此，我们完成了第一篇排序
            return left;
        }
    }
}
