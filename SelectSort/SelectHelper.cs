/***********************************************************************************************************************************
 * 
 * 功能：排序算法——选择排序
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * http://www.cnblogs.com/huangxincheng/archive/2011/11/16/2251196.html
 * 
 * 备注：
 * 
 ***********************************************************************************************************************************/

namespace SelectSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 排序算法——选择排序
    /// </summary>
    public class SelectHelper
    {
        /// <summary>
        /// 直接选择排序
        /// </summary>
        public static List<int> SelectSort(List<int> list)
        {
            //要遍历的次数
            for (int i = 0; i < list.Count - 1; i++)
            {
                //假设tempIndex的下标的值最小
                int tempIndex = i;

                for (int j = i + 1; j < list.Count; j++)
                {
                    //如果tempIndex下标的值大于j下标的值,则记录较小值下标j
                    if (list[tempIndex] > list[j])
                        tempIndex = j;
                }

                //最后将假想最小值跟真的最小值进行交换
                var tempData = list[tempIndex];
                list[tempIndex] = list[i];
                list[i] = tempData;
            }
            return list;
        }


        ///<summary>
        /// 构建堆
        ///</summary>
        ///<param name="list">待排序的集合</param>
        ///<param name="parent">父节点</param>
        ///<param name="length">输出根堆时剔除最大值使用</param>
        static void HeapAdjust(List<int> list, int parent, int length)
        {
            //temp保存当前父节点
            int temp = list[parent];

            //得到左孩子(这可是二叉树的定义，大家看图也可知道)
            int child = 2 * parent + 1;

            while (child < length)
            {
                //如果parent有右孩子，则要判断左孩子是否小于右孩子
                if (child + 1 < length && list[child] < list[child + 1])
                    child++;

                //父亲节点大于子节点，就不用做交换
                if (temp >= list[child])
                    break;

                //将较大子节点的值赋给父亲节点
                list[parent] = list[child];

                //然后将子节点做为父亲节点，已防止是否破坏根堆时重新构造
                parent = child;

                //找到该父亲节点较小的左孩子节点
                child = 2 * parent + 1;
            }
            //最后将temp值赋给较大的子节点，以形成两值交换
            list[parent] = temp;
        }

        ///<summary>
        /// 堆排序
        ///</summary>
        ///<param name="list"></param>
        public static void HeapSort(List<int> list)
        {
            //list.Count/2-1:就是堆中父节点的个数
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                HeapAdjust(list, i, list.Count);
            }

            //最后输出堆元素
            for (int i = list.Count - 1; i > 0; i--)
            {
                //堆顶与当前堆的第i个元素进行值对调
                int temp = list[0];
                list[0] = list[i];
                list[i] = temp;

                //因为两值交换，可能破坏根堆，所以必须重新构造
                HeapAdjust(list, 0, i);
            }
        }
    }
}
