using System;
using  System.Diagnostics;
using System.Runtime.InteropServices;

namespace DataStructures
{
    public class GraphsInfo
    {
        ///Most useful and important when it comes to modelinng real life.
        /// In short, graphs are sets of values that are related in a pair-wise
        /// fashion. Each item is called a node or a vertex. Nodes are connected with
        /// Edges.
        ///
        /// Types of graphs. Graphs can be directed and undirected. Graphs can be
        /// Weighted and unweighted. Weighted and weighted assign a weight
        /// to the edges between nodes and in case of judgement calls, picks the
        /// best weight between them all for the request in hand. Graphs can be cyclic
        /// and Acyclic. Cyclic graphs are more common in weighted graphs and
        /// undirected.
        ///
        /// Graph Data - Graphs can be built by using - Edge List where the
        /// connections are the only things that are defined and in mapping them
        /// out, the graph eventually churns out. Another is Adjacent list or Adjacency
        /// Adjacency is a graph where the index is the node and the value is the
        /// nodes neighbours. Another is call Adjacent Matrix. Its more like adjacency
        /// where the index is the node and the value is the
        /// nodes neighbours, however, the relationship is defined with zeros and
        /// ones such that for and items position, 0 will mean no relationship and
        /// 1 will mean connection.
        ///
        /// Best for relationship based data but its difficult to scale.

    }

    public class Graph
    {
        private const int MAX_NODES = 5;

        private int num_nodes;
        private int[][] adjacent_list_table;

        public Graph()
        {
            num_nodes = 0;
            adjacent_list_table = new int[MAX_NODES][];
            for (int i = 0; i < MAX_NODES; i++)
            {
                adjacent_list_table[i] = new int[MAX_NODES];
                for (int j = 0; j < MAX_NODES; j++)
                {
                    adjacent_list_table[i][j] = 0;
                }
            }
        }

        public void AddVertex(int value)
        {
            adjacent_list_table[value] = new int[MAX_NODES];
            for (int i = 0; i < MAX_NODES; i++)
            {
                adjacent_list_table[value][i] = 0;
            }
            num_nodes++;
        }

        public void AddEdge(int from, int to)
        {
            adjacent_list_table[from][to] = 1;
            adjacent_list_table[to][from] = 1;
        }

        public void Print()
        {
            for (int i = 0; i < MAX_NODES; i++)
            {
                if (adjacent_list_table[i][0] != -1)
                {
                    Console.Write("{0}: ", i);
                    for (int j = 0; j < MAX_NODES; j++)
                    {
                        Console.Write("{0} ", adjacent_list_table[i][j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }

}