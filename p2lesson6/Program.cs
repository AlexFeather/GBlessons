using System.Collections.Generic;
using System.Linq;

namespace p2lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            Node node1 = graph.AddNode(1);
            Node node2 = graph.AddNode(2);
            Node node3 = graph.AddNode(3);
            Node node4 = graph.AddNode(4);
            Node node5 = graph.AddNode(5);
            node1.AddEdgeWithWeightTo(2, node3);
            node1.AddEdgeWithWeightTo(4, node5);
            node2.AddEdgeWithWeightTo(3, node5);
            node3.AddEdgeWithWeightTo(1, node2);
            node3.AddEdgeWithWeightTo(1, node4);
            node4.AddEdgeWithWeightTo(2, node2);
            node5.AddEdgeWithWeightTo(4, node1);
            graph.DFSearch(node1, 5);
            graph.DFSearch(node1, 6);

        }
    }

    public class Graph
    {
        public List<Node> Nodes { get; private set; }
        public int Size { get; private set; }

        public Node AddNode(int value)
        {
            Node newNode = new Node(value);
            System.Console.WriteLine($"Node with value = {value} is created.");
            return newNode;
        }

        public Node BFSearch(Node startNode, int value)
        {
            Queue<Node> queue = new Queue<Node>();
            System.Console.WriteLine("Created queue.");
            queue.Enqueue(startNode);
            System.Console.WriteLine("Enqueued starting Node.");
            startNode.WaveHeight = 1;
            System.Console.WriteLine("Starting Node WaveHeight is set to 1.");
            while (queue.Count > 0)
            {
                Node temp = queue.Dequeue();
                System.Console.WriteLine("Dequeued node.");
                if (temp.Value == value)
                {
                    System.Console.WriteLine("Result found!");
                    return temp;
                }
                else
                {
                    foreach (Edge element in temp.Edges)
                    {
                        if(element.Dest.WaveHeight == 0)
                        {
                            System.Console.WriteLine("Enqueued Node.");
                            queue.Enqueue(element.Dest);
                            element.Dest.WaveHeight = temp.WaveHeight + 1;
                            System.Console.WriteLine($"Node WaveHeight is set to {element.Dest.WaveHeight}");
                        }
                    }
                }
            }
            System.Console.WriteLine("Result not found.");
            return null;
        }

        public Node DFSearch(Node startNode, int value)
        {
            Stack<Node> stack = new Stack<Node>();
            System.Console.WriteLine("Created stack.");
            stack.Push(startNode);
            System.Console.WriteLine("Pushed starting Node.");
            startNode.WaveHeight = 1;
            System.Console.WriteLine("Starting Node WaveHeight is set to 1.");
            while (stack.Count > 0)
            {
                Node temp = stack.Pop();
                System.Console.WriteLine("Popped node.");
                if (temp.Value == value)
                {
                    System.Console.WriteLine("Result found!");
                    return temp;
                }
                else
                {
                    foreach (Edge element in temp.Edges)
                    {
                        if (element.Dest.WaveHeight == 0)
                        {
                            System.Console.WriteLine("Pushed Node.");
                            stack.Push(element.Dest);
                            element.Dest.WaveHeight = temp.WaveHeight + 1;
                            System.Console.WriteLine($"Node WaveHeight is set to {element.Dest.WaveHeight}");
                        }
                    }
                }
            }
            System.Console.WriteLine("Result not found.");
            return null;
        }

        //public void Wave(Node startNode)
        //{
        //    List<Node> dryNodes = new List<Node>();
        //    List<Node> wetNodes = new List<Node>();
        //    List<Node> waterfront = new List<Node>();
        //    dryNodes = Nodes;
        //    waterfront.Add(dryNodes.Find(node => node == startNode));
        //    int i = 0;
        //    do
        //    {
        //        foreach(Node element in waterfront)
        //        {
        //            element.WaveHeight = i;
        //            dryNodes.Remove(element);
        //        }

        //        foreach (Node element in waterfront)
        //        {
        //            wetNodes.Add(element);
        //            waterfront.AddRange(element.GetAllDestinatedNodes());
        //            waterfront.Remove(element);
        //        }

        //    }
        //    while (dryNodes.Count > 0);

        //}
    }


    public class Node
    {
        public int Value { get; private set; }
        public List<Edge> Edges { get; private set; }
        public int WaveHeight { get; set; }

        public Node(int value)
        {
            Value = value;
            Edges = new List<Edge>();
        }

        public Edge AddEdgeWithWeightTo(int weight, Node destination)
        {
            Edge temp = new Edge(weight, destination);
            Edges.Add(temp);
            System.Console.WriteLine("Added edge to another Node.");
            return temp;
        }

        public bool FindEdgeTo(Node destination, out Edge result)
        {
            result = Edges.Find(edge => edge.Dest == destination);
            if (result != null)
                return true;
            else
                return false;
        }

        public bool FindCheapestEdge(out Edge result)
        {
            int lowestWeight = Edges.Any() ? Edges.Min(edge => edge.Weight) : 0;
            result = Edges.Find(edge => edge.Weight == lowestWeight);
            if (result != null)
                return true;
            else
                return false;
        }

        public bool DeleteEdgeTo(Node destination)
        {
            Edge sentenced;
            if (FindEdgeTo(destination, out sentenced))
            {
                Edges.Remove(sentenced);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Node[] GetAllDestinatedNodes()
        {
            if (Edges.Count > 0)
            {
                int i = 0;
                Node[] nodes = new Node[Edges.Count];
                foreach (Edge element in Edges)
                {
                    nodes[i] = element.Dest;
                    i++;
                }
                return nodes;
            }
            else return null;
        }

    }

    public class Edge
    {
        public int Weight { get; private set; }
        public Node Dest { get; private set; }

        public Edge(int weight, Node destination)
        {
            Weight = weight;
            Dest = destination;
        }
    }

}
