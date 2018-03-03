namespace InsertSort
{
    /// <summary>
    /// 链表结点
    /// </summary>
    public class Node
    {
        public int Data { get; set; }

        public Node Next { get; set; }

        public Node()
        { }

        public Node(int data)
        {
            this.Data = data;
        }
    }
}
