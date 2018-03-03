/***********************************************************************************************************************************
 * 
 * 功能：数据结构——树形关系
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-05-18
 * 
 * 参考：
 * 《数据结构》
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

namespace TreeDemo.Helper
{
    using System;

    public class TreeManager
    {
        static char[] input = { 'a', 'b', 'd', 'h', '#', '#', '#', 'e', '#', '#', 'c', 'f', '#', '#', 'g', '#', '#' };

        /// <summary>
        /// 递归生成(先序遍历构造树)
        /// </summary>
        /// <param name="tree"></param>
        public static void ConstructTree(Tree tree, int index)
        {
            string line = Console.ReadLine();
            if (line != "#")
            {
                tree.data = line;
                tree.deepth = index++;
                tree.left = new Tree();
                tree.right = new Tree();
                ConstructTree(tree.left, index);
                ConstructTree(tree.right, index);
            }
        }

        /// <summary>
        /// 先序遍历
        /// </summary>
        /// <param name="tree"></param>
        public static void PreOrderTraverse(Tree tree)
        {
            if (tree != null && !String.IsNullOrEmpty(tree.data))
            {
                Console.Write("{0} ", tree.data);
                PreOrderTraverse(tree.left);
                PreOrderTraverse(tree.right);
            }
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="tree"></param>
        public static void InOrderTraverse(Tree tree)
        {
            if (tree != null && !String.IsNullOrEmpty(tree.data))
            {
                InOrderTraverse(tree.left);
                Console.Write("{0} ", tree.data);
                InOrderTraverse(tree.right);
            }
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="tree"></param>
        public static void PostOrderTraverse(Tree tree)
        {
            if (tree != null && !String.IsNullOrEmpty(tree.data))
            {
                PostOrderTraverse(tree.left);
                PostOrderTraverse(tree.right);
                Console.Write("{0} ", tree.data);
            }
        }
    }

    public class Tree
    {
        public Tree left { get; set; }

        public string data { get; set; }

        public int deepth { get; set; }

        public Tree right { get; set; }

        public Tree()
        {
        }

        public Tree(string data)
        {
            this.data = data;
        }
    }
}
