/***********************************************************************************************************************************
 * 
 * 功能：数据结构——树形关系
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：《数据结构》——TreeManager类
 * http://www.cnblogs.com/huangxincheng/archive/2011/12/11/2283674.html BinTree类
 * 
 * 备注：
 * 数据存在这三种基本关系：
 * 1、线性关系：线性表、队列、栈；
 * 2、树形关系(顺序存储、链式存储)；
 * 3、网状关系。 
 * 
 * 二叉树的存储：顺序存储、链式存储；
 * 
 ***********************************************************************************************************************************/

namespace TreeDemo
{
    using System;
    using Helper;

    class Program
    {
        static void Main(string[] args)
        {
            TreeManagerTest();

            Console.ReadKey(true);
        }

        static void TreeManagerTest()
        {
            Tree tree = new Tree();
            TreeManager.ConstructTree(tree, 1);
            TreeManager.PreOrderTraverse(tree);
            Console.WriteLine();
            TreeManager.InOrderTraverse(tree);
            Console.WriteLine();
            TreeManager.PostOrderTraverse(tree);
        }
    }
}
