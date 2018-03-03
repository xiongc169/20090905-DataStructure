/***********************************************************************************************************************************
 * 
 * 功能：查找算法——二叉排序树查找
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * http://www.cnblogs.com/huangxincheng/archive/2011/11/27/2265427.html
 * 
 * 备注：
 * 二叉树查找
 * 
 * 二叉排序树概念：
 * 若根节点有左子树，则左子树的所有节点都比根节点小。
 * 若根节点有右子树，则右子树的所有节点都比根节点大。
 * 
 ***********************************************************************************************************************************/

namespace Search.SearchHelper
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 二叉排序树查找
    /// </summary>
    public class BSTSearch
    {
        ///<summary>
        /// 定义一个二叉排序树结构
        ///</summary>
        public class BSTree
        {
            public int Data;
            public BSTree Left;
            public BSTree Right;
        }

        ///<summary>
        /// 二叉排序树的插入操作
        ///</summary>
        ///<param name="bsTree">排序树</param>
        ///<param name="key">插入数</param>
        ///<param name="isExcute">是否执行了if语句</param>
        static void InsertBST(BSTree bsTree, int key, ref bool isExcute)
        {
            if (bsTree == null)
                return;

            //如果父节点大于key，则遍历左子树
            if (bsTree.Data > key)
                InsertBST(bsTree.Left, key, ref isExcute);
            else
                InsertBST(bsTree.Right, key, ref isExcute);

            if (!isExcute)
            {
                //构建当前节点
                BSTree current = new BSTree()
                {
                    Data = key,
                    Left = null,
                    Right = null
                };

                //插入到父节点的当前元素
                if (bsTree.Data > key)
                    bsTree.Left = current;
                else
                    bsTree.Right = current;

                isExcute = true;
            }
        }

        ///<summary>
        /// 创建二叉排序树
        ///</summary>
        ///<param name="list"></param>
        static BSTree CreateBST(List<int> list)
        {
            //构建BST中的根节点
            BSTree bsTree = new BSTree()
            {
                Data = list[0],
                Left = null,
                Right = null
            };

            for (int i = 1; i < list.Count; i++)
            {
                bool isExcute = false;
                InsertBST(bsTree, list[i], ref isExcute);
            }
            return bsTree;
        }

        ///<summary>
        /// 在排序二叉树中搜索指定节点
        ///</summary>
        ///<param name="bsTree"></param>
        ///<param name="key"></param>
        ///<returns></returns>
        static bool SearchBST(BSTree bsTree, int key)
        {
            //如果bsTree为空，说明已经遍历到头了
            if (bsTree == null)
                return false;

            if (bsTree.Data == key)
                return true;

            if (bsTree.Data > key)
                return SearchBST(bsTree.Left, key);
            else
                return SearchBST(bsTree.Right, key);
        }

        ///<summary>
        /// 中序遍历二叉排序树
        ///</summary>
        ///<param name="bsTree"></param>
        ///<returns></returns>
        static void LdrBST(BSTree bsTree)
        {
            if (bsTree != null)
            {
                //遍历左子树
                LdrBST(bsTree.Left);

                //输入节点数据
                Console.Write(bsTree.Data + "");

                //遍历右子树
                LdrBST(bsTree.Right);
            }
        }

        ///<summary>
        /// 删除二叉排序树中指定key节点
        ///</summary>
        ///<param name="bsTree"></param>
        ///<param name="key"></param>
        static void DeleteBST(ref BSTree bsTree, int key)
        {
            if (bsTree == null)
                return;

            if (bsTree.Data == key)
            {
                //第一种情况：叶子节点
                if (bsTree.Left == null && bsTree.Right == null)
                {
                    bsTree = null;
                    return;
                }
                //第二种情况：左子树不为空
                if (bsTree.Left != null && bsTree.Right == null)
                {
                    bsTree = bsTree.Left;
                    return;
                }
                //第三种情况，右子树不为空
                if (bsTree.Left == null && bsTree.Right != null)
                {
                    bsTree = bsTree.Right;
                    return;
                }
                //第四种情况，左右子树都不为空
                if (bsTree.Left != null && bsTree.Right != null)
                {
                    var node = bsTree.Right;

                    //找到右子树中的最左节点
                    while (node.Left != null)
                    {
                        //遍历它的左子树
                        node = node.Left;
                    }

                    //交换左右孩子
                    node.Left = bsTree.Left;

                    //判断是真正的叶子节点还是空左孩子的父节点
                    if (node.Right == null)
                    {
                        //删除掉右子树最左节点
                        DeleteBST(ref bsTree, node.Data);

                        node.Right = bsTree.Right;
                    }
                    //重新赋值一下
                    bsTree = node;
                }
            }

            if (bsTree.Data > key)
            {
                DeleteBST(ref bsTree.Left, key);
            }
            else
            {
                DeleteBST(ref bsTree.Right, key);
            }
        }


        /// <summary>
        /// 二叉排序树查找测试方法
        /// </summary>
        static void BSTSearchTest()
        {
            List<int> list = new List<int>() { 50, 30, 70, 10, 40, 90, 80 };

            //创建二叉遍历树
            BSTree bsTree = CreateBST(list);

            Console.Write("中序遍历的原始数据：");

            //中序遍历
            LdrBST(bsTree);

            Console.WriteLine("\n---------------------------------------------------------------------------n");

            //查找一个节点
            Console.WriteLine("\n10在二叉树中是否包含：" + SearchBST(bsTree, 10));

            Console.WriteLine("\n---------------------------------------------------------------------------n");

            bool isExcute = false;

            //插入一个节点
            InsertBST(bsTree, 20, ref isExcute);

            Console.WriteLine("\n20插入到二叉树，中序遍历后：");

            //中序遍历
            LdrBST(bsTree);

            Console.WriteLine("\n---------------------------------------------------------------------------n");

            Console.Write("删除叶子节点 20， \n中序遍历后：");

            //删除一个节点(叶子节点)
            DeleteBST(ref bsTree, 20);

            //再次中序遍历
            LdrBST(bsTree);

            Console.WriteLine("\n****************************************************************************\n");

            Console.WriteLine("删除单孩子节点 90， \n中序遍历后：");

            //删除单孩子节点
            DeleteBST(ref bsTree, 90);

            //再次中序遍历
            LdrBST(bsTree);

            Console.WriteLine("\n****************************************************************************\n");

            Console.WriteLine("删除根节点 50， \n中序遍历后：");
            //删除根节点
            DeleteBST(ref bsTree, 50);

            LdrBST(bsTree);
        }
    }
}
