/***********************************************************************************************************************************
 * 
 * 功能：线性关系的数据结构——线性表之顺序存储
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * http://www.cnblogs.com/huangxincheng/archive/2011/11/28/2266861.html
 * 
 * 备注：
 * 1、线性关系：线性表、队列、栈；
 * 
 ***********************************************************************************************************************************/

namespace LinearStruct.Helper
{
    /// <summary>
    /// 线性关系的数据结构——线性表
    /// 顺序存储
    /// </summary>
    public class SequenceListHelper<T>
    {
        /// <summary>
        /// 可存储的记录数的最大值
        /// </summary>
        const int maxSize = 1000;

        /// <summary>
        /// 已存储的记录数
        /// </summary>
        int CurrentIndex = 0;

        /// <summary>
        /// 顺序存储数组
        /// </summary>
        private T[] array;//= new T[maxSize];

        /// <summary>
        /// 构造函数
        /// </summary>
        public SequenceListHelper()
        {
            this.array = new T[maxSize];
            CurrentIndex = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="size"></param>
        public SequenceListHelper(int size)
        {
            this.array = new T[size];
            CurrentIndex = 0;
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="node"></param>
        public void Add(T node)
        {
            if (CurrentIndex >= maxSize)
                return;

            array[CurrentIndex++] = node;
        }

        /// <summary>
        /// 插入新记录
        /// </summary>
        /// <param name="node"></param>
        /// <param name="index"></param>
        public void Insert(T node, int index)
        {
            if (index < 0 || index > maxSize - 1)
                return;

            if (CurrentIndex >= maxSize)
                return;

            for (int i = CurrentIndex - 1; i >= index; i--)
            {
                array[i + 1] = array[i];
            }
            array[index] = node;
            CurrentIndex++;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            if (index < 0 || index > CurrentIndex - 1)
                return;

            for (int i = index; i < CurrentIndex; i++)
            {
                array[i] = array[i + 1];
            }
            CurrentIndex--;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="node"></param>
        /// <param name="index"></param>
        public void Update(T node, int index)
        {
            array[index] = node;
        }

        /// <summary>
        /// 查找记录
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T QueryByIndex(int index)
        {
            if (index < 0 || index > CurrentIndex - 1)
                return default(T);

            return array[index];
        }

        /// <summary>
        /// 查找记录
        /// </summary>
        /// <param name="node"></param>
        public void QueryByKeys(T node)
        {
            // return array.ToList().ElementAt(node);
            return;
        }
    }

    /// <summary>
    /// 学生类
    /// </summary>
    public class Student
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    /// <summary>
    /// 定义一个顺序存储结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SequenceNode<T>
    {
        private const int maxSize = 1000;

        public int MaxSize { get { return maxSize; } }

        public T[] DataList = new T[maxSize];

        public int DataListLen { get; set; }
    }
}
