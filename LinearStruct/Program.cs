/***********************************************************************************************************************************
 * 
 * 功能：线性关系的数据结构
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * http://www.cnblogs.com/huangxincheng/archive/2011/11/28/2266861.html
 * 
 * 备注：
 * 数据存在这三种基本关系：
 * 1、线性关系：线性表(顺序存储;链式存储)、队列、栈(节点最多有一个前驱、一个后继)；
 * 2、树形关系；
 * 3、网状关系。 
 * 
 ***********************************************************************************************************************************/

namespace LinearStruct
{
    using System;
    using Helper;

    class Program
    {
        static void Main(string[] args)
        {
            LinkTest();

            Console.ReadKey(true);
        }

        static void LinkTest()
        {
            SequenceListHelper<Student> helper = new SequenceListHelper<Student>();
            helper.Add(new Student { Age = 001, ID = "001", Name = "Name001" });
            helper.Add(new Student { Age = 002, ID = "002", Name = "Name002" });
            helper.Add(new Student { Age = 003, ID = "003", Name = "Name003" });
            helper.Add(new Student { Age = 004, ID = "004", Name = "Name004" });
            helper.Add(new Student { Age = 005, ID = "005", Name = "Name005" });

            helper.Insert(new Student { Age = 005, ID = "001New", Name = "Name001New" }, 1);
        }
    }
}
