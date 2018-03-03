/***********************************************************************************************************************************
 * 
 * 功能：数据结构——树形关系
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * http://www.cnblogs.com/huangxincheng/archive/2011/12/11/2283674.html
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
    /// <summary>
    /// 数据结构——树形关系
    /// </summary>
    public class BinTree<T>
    {
        /// <summary>
        /// 根节点
        /// </summary>
        public ChainTree<T> Root = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public BinTree()
        { }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="direction"></param>
        public void AddNode(ChainTree<T> node, int direction)
        {
            if (Root == null)
            {
                Root = node;
            }

            switch (direction)
            {
                case 0:
                    if (Root.Left == null)
                        Root.Left = node;
                    break;
                case 1:
                    if (Root.Left == null)
                        Root.Left = node;
                    break;
            }

            AddNode(node, 0);
            AddNode(node, 1);
        }
    }
    
    /// <summary>
    /// 二叉树链式存储节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ChainTree<T>
    {
        public T Date;

        public ChainTree<T> Left;

        public ChainTree<T> Right;
    }
}
