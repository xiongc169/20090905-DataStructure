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
    public class MergeHelperr
    {
        public static int[] nums = { 13, 4, 2, 11, 32, 12, 31, 85, 9, 7, 5 };

        ///<summary>
        /// 数组的划分
        ///</summary>
        ///<param name="array">待排序数组</param>
        ///<param name="temparray">临时存放数组</param>
        ///<param name="left">序列段的开始位置，0</param>
        ///<param name="right">序列段的结束位置,array.Length - 1</param>
        public static void MergeSort(int[] array, int[] temparray, int left, int right)
        {
            if (left < right)
            {
                //取分割位置
                int middle = (left + right) / 2;

                //递归划分数组左序列
                MergeSort(array, temparray, left, middle);

                //递归划分数组右序列
                MergeSort(array, temparray, middle + 1, right);

                //数组合并操作
                Merge(array, temparray, left, middle + 1, right);
            }
        }

        ///<summary>
        /// 数组的两两合并操作
        ///</summary>
        ///<param name="array">待排序数组</param>
        ///<param name="temparray">临时数组</param>
        ///<param name="left">第一个区间段开始位置</param>
        ///<param name="middle">第二个区间的开始位置</param>
        ///<param name="right">第二个区间段结束位置</param>
        public static void Merge(int[] array, int[] temparray, int left, int middle, int right)
        {
            //左指针尾
            int leftEnd = middle - 1;

            //右指针头
            int rightStart = middle;

            //临时数组的下标
            int tempIndex = left;

            //数组合并后的length长度
            int tempLength = right - left + 1;

            //先循环两个区间段都没有结束的情况
            while ((left <= leftEnd) && (rightStart <= right))
            {
                //如果发现有序列大，则将此数放入临时数组
                if (array[left] < array[rightStart])
                    temparray[tempIndex++] = array[left++];
                else
                    temparray[tempIndex++] = array[rightStart++];
            }

            //判断左序列是否结束
            while (left <= leftEnd)
                temparray[tempIndex++] = array[left++];

            //判断右序列是否结束
            while (rightStart <= right)
                temparray[tempIndex++] = array[rightStart++];

            //交换数据
            for (int i = 0; i < tempLength; i++)
            {
                array[right] = temparray[right];
                right--;
            }
        }
    }
}
