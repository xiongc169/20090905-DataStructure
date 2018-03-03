/***********************************************************************************************************************************
 * 
 * 功能：数据结构——网状关系
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：《数据结构》
 * http://www.cnblogs.com/huangxincheng/archive/2011/12/24/2300731.html
 * 
 * 备注：
 * 数据存在这三种基本关系：
 * 1、线性关系：线性表、队列、栈；
 * 2、树形关系(节点最多有一个前驱、多个后继)；
 * 3、网状关系。 
 * 
 * 图的存储： 
 * 邻接矩阵：采用两个数组，一维数组用来保存顶点信息，二维数组来用保存边的信息，缺点就是比较耗费空间；
 * 邻接表：改进后的“邻接矩阵”，缺点是不方便判断两个顶点之间是否有边，但是相比节省空间。
 * 
 * 图的使用范围很广的，比如网络爬虫，求最短路径等
 * 
 * 概念：
 * 图是由“顶点(Vertex)”的集合和“边(Edge)”的集合组成。记作：G=（V,E)；
 * 无向图的边表示为(V1,V2)，等价于(V2,V1)；有向图的边表示为<V1,V2>，不等价<V2,V1>；
 * 
 ***********************************************************************************************************************************/

namespace GraphicsDemo.Helper
{
    /// <summary>
    /// 邻接矩阵的结构图
    /// </summary>
    public class MatrixGraph
    {
        /// <summary>
        /// 顶点集合
        /// </summary>
        public string[] Vertexs;

        /// <summary>
        /// 边集合
        /// </summary>
        public int[,] Edges;

        /// <summary>
        /// 深搜、广搜的遍历标志
        /// </summary>
        public bool[] IsTrav;

        /// <summary>
        /// 顶点数
        /// </summary>
        public int VertexCnt;

        /// <summary>
        /// 边数
        /// </summary>
        public int EdgeCnt;

        /// <summary>
        /// 图类型
        /// </summary>
        public int GraphType;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="vertexCnt">顶点数</param>
        /// <param name="edgeCnt">边数</param>
        /// <param name="graphType">图类型</param>
        public MatrixGraph(int vertexCnt, int edgeCnt, int graphType)
        {
            VertexCnt = vertexCnt;
            EdgeCnt = edgeCnt;
            GraphType = graphType;

            Vertexs = new string[vertexCnt];
            Edges = new int[vertexCnt, vertexCnt];
            IsTrav = new bool[vertexCnt];
        }
    }
}
