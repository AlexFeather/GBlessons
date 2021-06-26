using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace p2lesson4
{


    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                tree.Insert(rnd.Next(0, 9999));
            }
            tree.PrintTree();
            Console.SetCursorPosition(0, 50);
        }

        class Tree
        {
            public int Center { get; private set; }
            public Node Root { get; private set; }
            public int Size { get; private set; }

            public void ChangeCenterPoint(int posInLine)
            {
                Center = posInLine;
            }
            public void Insert(int value)
            {
                Node temp = null;
                if (Root == null)
                {
                    Root = new Node(value);
                }
                else
                {
                    temp = Root;
                    while (temp != null)
                    {
                        if (value <= temp.Value)
                        {
                            if (temp.Left != null)
                            {
                                temp = temp.Left;
                                continue;
                            }
                            else
                            {
                                temp.SetLeft(temp.AddNode(value));
                                return;
                            }
                        }
                        else if (value > temp.Value)
                        {
                            if (temp.Right != null)
                            {
                                temp = temp.Right;
                                continue;
                            }
                            else
                            {
                                temp.SetRight(temp.AddNode(value));
                                return;
                            }
                        }
                        else
                        {
                            throw new Exception("Wrong tree state.");
                        }
                    }
                }
                Size++;
                return;
            }

            public bool StraightSearch(int value, out Node result)
            {
                Node temp;
                temp = Root;
                while (temp != null)
                {
                    if (temp.Value == value)
                    {
                        result = temp;
                        return true;
                    }
                    else if (temp.Value > value)
                    {
                        temp = temp.Left;
                        continue;
                    }
                    else
                    {
                        temp = temp.Right;
                        continue;
                    }

                }
                result = null;
                return false;
            }

            public Node FindMaxValue(Node head)
            {
                while (head.Value < head.Right.Value)
                {
                    head = head.Right;
                }
                return head;
            }

            public bool Withdraw(Node sentenced)
            {
                if (sentenced.Left == null && sentenced.Right == null)
                {
                    if (sentenced.Parent.Left == sentenced)
                    {
                        sentenced.Parent.NullifyLeft();
                    }
                    else
                    {
                        sentenced.Parent.NullifyRight();
                    }
                    sentenced.NullifyParent();
                    return true;
                }
                else if (sentenced.Left != null && sentenced.Right != null)
                {
                    Node temp = FindMaxValue(sentenced.Left);
                    sentenced.SetValue(temp.Value);
                    Withdraw(temp);
                    return true;
                }
                else if (sentenced.Left != null && sentenced.Right == null)
                {
                    if (sentenced.Parent.Left == sentenced)
                    {
                        sentenced.Parent.SetLeft(sentenced.Left);
                        sentenced.Left.SetParent(sentenced.Parent);
                        sentenced.NullifyParent();
                        sentenced.NullifyLeft();
                    }
                    else
                    {
                        sentenced.Parent.SetRight(sentenced.Left);
                        sentenced.Left.SetParent(sentenced.Parent);
                        sentenced.NullifyParent();
                        sentenced.NullifyLeft();
                    }
                }
                else if (sentenced.Left == null && sentenced.Right != null)
                {
                    if (sentenced.Parent.Left == sentenced)
                    {
                        sentenced.Parent.SetLeft(sentenced.Left);
                        sentenced.Right.SetParent(sentenced.Parent);
                        sentenced.NullifyParent();
                        sentenced.NullifyRight();
                    }
                    else
                    {
                        sentenced.Parent.SetRight(sentenced.Left);
                        sentenced.Right.SetParent(sentenced.Parent);
                        sentenced.NullifyParent();
                        sentenced.NullifyRight();
                    }
                }
                else
                {
                    throw new Exception("Unexpected outcome in Withdraw method");
                }
                return true;
            }

            public void CalcIndents()
            {
                Node temp = Root;
                while (temp.Left != null)
                {
                    temp = temp.Left;
                }

                temp.SetIndent(0);
                do
                {
                    temp = temp.Parent;
                    temp.SetIndent(temp.Left.Indent + temp.Left.Width);
                }
                while (temp.Parent != null);
                if (Root.Left != null)
                    Root.Left.CalcIndent(Root.Left);
                if (Root.Right != null)
                    Root.Right.CalcIndent(Root.Right);

            }

            public void PrintTree()
            {
                Root.CalcWidth(Root);
                CalcIndents();
                Root.PrintNode();

            }

            public Node BFSearch(int value)
            {
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(Root);
                while(queue.Count != 0)
                {
                    Node temp = queue.Dequeue();
                    if(temp.Value == value)
                    {
                        return temp;
                    }
                    else 
                    {
                        if (temp.Left != null)
                            queue.Enqueue(temp.Left);
                        if (temp.Right != null)
                            queue.Enqueue(temp.Right);
                    }
                }
                return null;
            }

            public Node DFSearch(int value)
            {
                Stack<Node> queue = new Stak<Node>();
                queue.Push(Root);
                while (queue.Count != 0)
                {
                    Node temp = queue.Pop();
                    if (temp.Value == value)
                    {
                        return temp;
                    }
                    else
                    {
                        if (temp.Left != null)
                            queue.Push(temp.Left);
                        if (temp.Right != null)
                            queue.Pop(temp.Right);
                    }
                }
                return null;
            }




        }
    }

    class Node
    {
        public int Value { get; private set; }
        public int Width { get; private set; }
        public int Indent { get; private set; }
        public int Row { get; private set; }
        public int ValueWidth { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }
        public Node Parent { get; private set; }

        public Node(int value)
        {
            Value = value;
        }

        private void CalcValueWidth()
        {
            ValueWidth = Value.ToString().Length;
        }

        public int CalcWidth(Node node)
        {
            int result = node.ValueWidth;
            if (node.Left != null)
            {
                result += CalcWidth(node.Left);
            }
            if (node.Right != null)
            {
                result += CalcWidth(node.Right);
            }
            node.Width = result;
            return result;
        }

        public Node AddNode(int value)
        {
            Node node = new Node(value);
            node.Parent = this;
            if (node.Parent != null)
                node.Row = node.Parent.Row + 1;
            else
                Row = 0;
            node.CalcValueWidth();
            return node;
        }

        public void SetValue(int value)
        {
            Value = value;
        }

        public void SetParent(Node node)
        {
            Parent = node;
        }

        public void NullifyParent()
        {
            Parent = null;
        }

        public void SetLeft(Node node)
        {
            Left = node;
        }

        public void NullifyLeft()
        {
            Left = null;
        }

        public void SetRight(Node node)
        {
            Right = node;
        }

        public void NullifyRight()
        {
            Right = null;
        }

        public void SetIndent(int value)
        {
            Indent = value;
        }

        public int CalcIndent(Node node)
        {
            int indent = 0;
            if (node == null)
                return indent;
            else
            {
                if (Parent.Left == node)
                {
                    indent = Parent.Indent - Width;
                    node.Indent = indent;
                    return indent;
                }
                else
                {
                    indent = Parent.Indent + Parent.Width;
                    node.Indent = indent;
                    return indent;
                }
            }

        }

        public void PrintNode()
        {
            Console.SetCursorPosition(Indent, Row);
            Console.WriteLine(Value);
            if (Left != null)
                Left.PrintNode();
            if (Right != null)
                Right.PrintNode();
        }
    }
}

