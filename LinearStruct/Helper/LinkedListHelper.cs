/***********************************************************************************************************************************
 * 
 * 功能：线性关系的数据结构——线性表之链式存储
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * http://www.cnblogs.com/huangxincheng/archive/2011/11/30/2268904.html
 * 
 * 备注：
 * 1、线性关系：线性表、队列、栈；
 * 
 * 链表的“每个节点”都包含一个”数据域“和”指针域“
 * ”数据域“中包含当前的数据。
 * ”指针域“中包含下一个节点的指针。
 * ”头指针”也就是head，指向头结点数据。
 * “末节点“作为单向链表，因为是最后一个节点，通常设置指针域为null。
 * 
 ***********************************************************************************************************************************/

namespace LinearStruct.Helper
{
    using System;

    /// <summary>
    /// 线性关系的数据结构——链表
    /// </summary>
    public class LinkedListHelper<T>
    {
        public Node<T> Head;

        public LinkedListHelper()
        {
            Head = null;
        }

        /// <summary>
        /// 将节点添加到链表的末尾
        /// </summary>
        /// <param name="node"></param>
        public void AddToTrail(Node<T> node)
        {
            if (Head == null)
            {
                Head = node;
                return;
            }
            Node<T> cursor = Head;
            while (cursor.Next != null)
            {
                cursor = cursor.Next;
            }
            cursor.Next = node;

            //GetLastNode(Head).Next = node;

        }

        /// <summary>
        /// 将节点添加到链表的开头
        /// </summary>
        /// <param name="node"></param>
        public void AddToHead(Node<T> node)
        {
            node.Next = Head.Next;
            Head = node;
        }

        /// <summary>
        /// 将节点插入到指定位置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="newNode"></param>
        /// <param name="key"></param>
        /// <param name="where"></param>
        public void Insert<T, W>(Node<T> newNode, string key, Func<T, W> where) where W : IComparable
        {
            //if (Head == null)
            //    return;
            //if (where(Head.Data).CompareTo(key) == 0)
            //{
            //    newNode.Next = Head.Next;
            //    Head.Next = newNode;
            //}
            //Insert<T, W>(newNode, key, where);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="delNode"></param>
        /// <param name="key"></param>
        /// <param name="where"></param>
        public void Delete<T, W>(Node<T> delNode, string key, Func<T, W> where) where W : IComparable
        {
            //if (Head == null)
            //    return;
            ////这是针对只有一个节点的解决方案
            //if (where(Head.Data).CompareTo(key) == 0)
            //{
            //    if (Head.Next != null)
            //        Head = Head.Next;
            //    else
            //        return Head = null;
            //}
            //else
            //{
            //    //判断一下此节点是否是要删除的节点的前一节点
            //    while (Head.Next != null && where(Head.Next.Data).CompareTo(key) == 0)
            //    {
            //        //将删除节点的next域指向前一节点
            //        Head.Next = Head.Next.Next;
            //    }
            //}
            //Delete<T, W>(delNode, key, where);
        }

        /// <summary>
        /// 按关键字查找节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="key"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public Node<T> Find<T, W>(string key, Func<T, W> where) where W : IComparable
        {
            //if (Head == null)
            //    return null;

            //if (where(Head.Data).CompareTo(key) == 0)
            //    return Head;

            //return Find<T, W>(Head.Next, key, where);

            return null;
        }

        /// <summary>
        /// 返回链表的最后一个节点
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node<T> GetLastNode(Node<T> head)
        {
            if (head.Next == null)
                return head;
            return GetLastNode(head.Next);
        }
    }

    /// <summary>
    /// 链表结点类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public T Data;

        public Node<T> Next;
    }
}
