/***********************************************************************************************************************************
 * 
 * 功能：查找算法——索引查找
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * http://www.cnblogs.com/huangxincheng/archive/2011/11/24/2261074.html
 * 
 * 备注：
 * 
 * 索引查找术语：
 * 第一：主表，要查找的对象。
 * 第二：索引项，用函数将一个主表划分成几个子表，每个子表建立一个索引，这个索引叫做索引项。
 * 第三：索引表, 索引项的集合也就是索引表。
 * 
 * 一般“索引项”包含三种内容：index，start，length
 * 第一：index，也就是索引指向主表的关键字。
 * 第二：start， 也就是index在主表中的位置。
 * 第三：length, 也就是子表的区间长度。
 * 
 ***********************************************************************************************************************************/

namespace Search.SearchHelper
{
    using System;
    using System.Linq;

    /// <summary>
    /// 索引查找
    /// </summary>
    public class IndexSearch
    {
        ///<summary>
        /// 学生主表
        ///</summary>
        static int[] students = { 
                                   101,102,103,104,105,0,0,0,0,0,
                                   201,202,203,204,0,0,0,0,0,0,
                                   301,302,303,0,0,0,0,0,0,0
                                };
        ///<summary>
        ///学生索引表
        ///</summary>
        static IndexItem[] indexItem = { 
                                  new IndexItem(){ Index=1, Start=0, Length=5},
                                  new IndexItem(){ Index=2, Start=10, Length=4},
                                  new IndexItem(){ Index=3, Start=20, Length=3}
                                };

        ///<summary>
        /// 查找数据
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
        public static int IndexSearchMethod(int key)
        {
            IndexItem item = null;

            // 建立索引规则
            var index = key / 100;

            //首先去索引找
            for (int i = 0; i < indexItem.Count(); i++)
            {
                if (indexItem[i].Index == index)
                {
                    item = new IndexItem() { Start = indexItem[i].Start, Length = indexItem[i].Length };
                    break;
                }
            }

            //如果item为null，则说明在索引中查找失败
            if (item == null)
                return -1;

            for (int i = item.Start; i < item.Start + item.Length; i++)
            {
                if (students[i] == key)
                {
                    return i;
                }
            }
            return -1;
        }

        ///<summary>
        /// 插入数据
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
        public static int Insert(int key)
        {
            IndexItem item = null;
            //建立索引规则
            var index = key / 100;
            int i = 0;
            for (i = 0; i < indexItem.Count(); i++)
            {
                //获取到了索引
                if (indexItem[i].Index == index)
                {
                    item = new IndexItem()
                    {
                        Start = indexItem[i].Start,
                        Length = indexItem[i].Length
                    };
                    break;
                }
            }
            if (item == null)
                return -1;
            //更新主表
            students[item.Start + item.Length] = key;
            //更新索引表
            indexItem[i].Length++;
            return 1;
        }

        /// <summary>
        /// 索引查找测试方法
        /// </summary>
        public static void IndexSearchTest()
        {
            Console.WriteLine("原数据为：" + string.Join(",", students));
            int value = 205;
            Console.WriteLine("\n插入数据" + value);
            //将205插入集合
            var index = Insert(value);
            //如果插入成功，获取205元素所在的位置
            if (index == 1)
            {
                Console.WriteLine("\n插入后数据：" + string.Join(",", students));
                Console.WriteLine("\n数据元素：205在数组中的位置为 " + IndexSearchMethod(205) + "位");
            }
        }
    }

    ///<summary>
    /// 索引项实体
    ///</summary>
    class IndexItem
    {
        /// <summary>
        /// 对应主表的值
        /// </summary>
        public int Index;

        /// <summary>
        /// 主表记录区间段的开始位置
        /// </summary>
        public int Start;

        /// <summary>
        /// 主表记录区间段的长度
        /// </summary>
        public int Length;
    }
}
