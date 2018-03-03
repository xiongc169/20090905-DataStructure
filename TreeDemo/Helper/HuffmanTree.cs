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
 * 
 ***********************************************************************************************************************************/

namespace TreeDemo.Helper
{
    public class HuffmanTree
    {
        public int[] leaf = { 7, 5, 2, 4 };

        public HuffmanTree left { get; set; }

        public HuffmanTree right { get; set; }
    }

    public class HuffmanTreeManager
    {
        public void ConstructHuffman(HuffmanTree tree)
        {

        }

        public void RefreshLeaf()
        { }

        public int[] GetSmallestNum()
        {
            int[] res = new int[2];
            return res;
        }

        public void SortedArray()
        {

        }
    }
}