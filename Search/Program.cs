/***********************************************************************************************************************************
 * 
 * 功能：查找算法
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * 
 * 备注：
 * 线性查找：顺序查找、二分查找；
 * 哈希查找、索引查找；
 * 二叉树查找；
 * 
 ***********************************************************************************************************************************/

namespace Search
{
    using System;
    using System.Collections.Generic;
    using SearchHelper;

    class Program
    {
        static void Main(string[] args)
        {
            IndexSearch.IndexSearchTest();
            Console.ReadKey(true);
        }

        /// <summary>
        /// 
        /// </summary>
        static void HashSearchTest()
        {
            //哈希表的设计函数——除法取余法
            int hashLength = 13;
            //原数据
            List<int> list = new List<int>() { 13, 29, 27, 28, 26, 30, 38 };
            //哈希表长度
            int[] hash = new int[hashLength];
            //创建hash
            for (int i = 0; i < list.Count; i++)
            {
                HashSearch.InsertHash(hash, hashLength, list[i]);
            }

            Console.WriteLine("Hash数据：" + string.Join(",", hash));

            while (true)
            {
                Console.WriteLine("\n请输入要查找数字：");
                int result = int.Parse(Console.ReadLine());
                var index = HashSearch.SearchHash(hash, hashLength, result);

                if (index != -1)
                    Console.WriteLine("数字" + result + "在索引的位置是:" + index);
                else
                    Console.WriteLine("呜呜，" + result + " 在hash中没有找到！");
            }
        }
    }
}
