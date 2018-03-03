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
    using System.Collections.Generic;

    /// <summary>
    /// 排序算法——插入排序
    /// </summary>
    class InsertSort
    {
        static int[] nums = { 13, 4, 2, 11, 32, 12, 31, 85, 9, 7, 5 };

        /// <summary>
        /// 直接插入排序(数据结果Demo)
        /// </summary>
        /// <returns></returns>
        public static int[] StraightInsertionSort()
        {
            int flag = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    flag = nums[i];
                    nums[i] = nums[i - 1];
                    int j = 0;
                    for (j = i - 2; j >= 0 && nums[j] < flag; j--)
                    {
                        nums[j + 1] = nums[j];
                    }
                    nums[j + 1] = flag;
                }
            }
            return nums;
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="list"></param>
        public static void InsertSortCopy(List<int> list)
        {
            //无须序列
            for (int i = 1; i < list.Count; i++)
            {
                var temp = list[i];

                int j;

                //有序序列
                for (j = i - 1; j >= 0 && temp < list[j]; j--)
                {
                    list[j + 1] = list[j];
                }
                list[j + 1] = temp;
            }
        }

        /// <summary>
        /// 希尔排序
        /// 考虑插入排序遇到倒序数组的情况，融入缩小增量排序法思想
        /// 是插入排序的改进版，w级别的排序中，相差70几倍
        /// </summary>
        public static void ShellSort(List<int> list)
        {
            //取增量
            int step = list.Count / 2;

            while (step >= 1)
            {
                //无须序列
                for (int i = step; i < list.Count; i++)
                {
                    var temp = list[i];

                    int j;

                    //有序序列
                    for (j = i - step; j >= 0 && temp < list[j]; j = j - step)
                    {
                        list[j + step] = list[j];
                    }
                    list[j + step] = temp;
                }
                step = step / 2;
            }
        }

        /// <summary>
        /// 折半插入排序 pk 折半查找
        /// </summary>
        /// <returns></returns>
        public int[] BInsertSort()
        {
            int[] nums = { 13, 4, 2, 11, 32, 12, 31, 85, 9, 7, 5 };
            return nums;
        }

        /// <summary>
        /// 链表排序
        /// </summary>
        /// <returns></returns>
        public Node NodeSort()
        {
            Node myList = new Node();
            Node head = myList;

            for (int i = 0; i < nums.Length; i++)
            {
                int toInsert = nums[i];
                Node node = new Node(toInsert);
                while (head.Next != null)
                {
                    Node next = head.Next;
                    if (next.Data > toInsert)
                        break;
                    head = head.Next;
                }
            }

            return head;
        }
    }
}
