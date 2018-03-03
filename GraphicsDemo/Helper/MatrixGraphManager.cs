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
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 邻接矩阵的结构图管理类
    /// </summary>
    public class MatrixGraphManager
    {
        /// <summary>
        /// 构造图
        /// </summary>
        /// <returns></returns>
        public MatrixGraph CreateGraph()
        {
            //初始化图的信息：顶点个数、边条数、图类型
            Console.WriteLine("请输入创建图的顶点个数，边条数，是否为无向图(0,1来表示)，以逗号隔开：");
            List<int> initData = Console.ReadLine().Split(',').Select(i => int.Parse(i)).ToList();
            MatrixGraph graph = new MatrixGraph(initData[0], initData[1], initData[2]);

            //请输入各顶点的信息
            Console.WriteLine("请输入各顶点信息：");
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                Console.Write("\n第" + (i + 1) + "个顶点为:");
                string single = Console.ReadLine();
                //顶点信息加入集合中
                graph.Vertexs[i] = single;
            }

            //请输入各边的信息
            Console.WriteLine("\n请输入构成两个顶点的边和权值，以逗号隔开。\n");
            for (int i = 0; i < graph.EdgeCnt; i++)
            {
                Console.Write("第" + (i + 1) + "条边:\t");
                //输入边的起点、终点、权重
                initData = Console.ReadLine().Split(',').Select(j => int.Parse(j)).ToList();
                int start = initData[0];
                int end = initData[1];
                int weight = initData[2];

                //给矩阵指定坐标位置赋值
                graph.Edges[start - 1, end - 1] = weight;

                //如果是无向图，则数据呈“二，四”象限对称
                if (graph.GraphType == 1)
                {
                    graph.Edges[end - 1, start - 1] = weight;
                }
            }

            //返回构建完成的图
            return graph;
        }

        #region 广度优先

        /// <summary>
        /// 广度优先
        /// </summary>
        /// <param name="graph"></param>
        public void BFSTraverse(MatrixGraph graph)
        {
            //访问标记默认初始化
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                graph.IsTrav[i] = false;
            }

            //遍历每个顶点
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                //广度遍历未访问过的顶点
                if (!graph.IsTrav[i])
                {
                    BFSM(ref graph, i);
                }
            }
        }

        /// <summary>
        /// 广度遍历具体算法
        /// </summary>
        /// <param name="graph"></param>
        public void BFSM(ref MatrixGraph graph, int vertex)
        {
            //这里就用系统的队列
            Queue<int> queue = new Queue<int>();

            //先把顶点入队
            queue.Enqueue(vertex);

            //标记此顶点已经被访问
            graph.IsTrav[vertex] = true;

            //输出顶点
            Console.Write(" ->" + graph.Vertexs[vertex]);

            //广度遍历顶点的邻接点
            while (queue.Count != 0)
            {
                var temp = queue.Dequeue();

                //遍历矩阵的横坐标
                for (int i = 0; i < graph.VertexCnt; i++)
                {
                    if (!graph.IsTrav[i] && graph.Edges[temp, i] != 0)
                    {
                        graph.IsTrav[i] = true;

                        queue.Enqueue(i);

                        //输出未被访问的顶点
                        Console.Write(" ->" + graph.Vertexs[i]);
                    }
                }
            }
        }

        #endregion

        #region 深度优先

        /// <summary>
        /// 深度优先
        /// </summary>
        /// <param name="graph"></param>
        public void DFSTraverse(MatrixGraph graph)
        {
            //访问标记默认初始化
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                graph.IsTrav[i] = false;
            }

            //遍历每个顶点
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                //广度遍历未访问过的顶点
                if (!graph.IsTrav[i])
                {
                    DFSM(ref graph, i);
                }
            }
        }

        /// <summary>
        /// 深度递归的具体算法
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="vertex"></param>
        public void DFSM(ref MatrixGraph graph, int vertex)
        {
            Console.Write("->" + graph.Vertexs[vertex]);

            //标记为已访问
            graph.IsTrav[vertex] = true;

            //要遍历的六个点
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                if (graph.IsTrav[i] == false && graph.Edges[vertex, i] != 0)
                {
                    //深度递归
                    DFSM(ref graph, i);
                }
            }
        }

        #endregion
    }
}
