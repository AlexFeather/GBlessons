using System;
using System.Collections.Generic;
using System.Linq;

namespace p2lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Node
    {
        public int Value { get; private set; }
        public List<Edge> Edges { get; private set; }

        public Node(int value)
        {
            Value = value;
        }

        public Edge AddEdgeWithWeightTo(int weight, Node destination)
        {
            Edge temp = new Edge(weight, destination);
            Edges.Add(temp);
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
