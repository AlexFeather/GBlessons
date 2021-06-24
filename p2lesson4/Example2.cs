using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace p2lesson4
{
    class Example2
    {
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
                while(temp != null)
                {
                    if(temp.Value == value)
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
                while(head.Value < head.Right.Value)
                {
                    head = head.Right;
                }
                return head;
            }

            public bool Withdraw(Node sentenced)
            {
                if(sentenced.Left == null && sentenced.Right == null)
                {
                    if(sentenced.Parent.Left == sentenced)
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
                else if(sentenced.Left != null && sentenced.Right != null)
                {
                    Node temp = FindMaxValue(sentenced.Left);
                    sentenced.SetValue(temp.Value);
                    Withdraw(temp);
                    return true;
                }
                else if(sentenced.Left != null && sentenced.Right == null)
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

        }
    }

    class Node
    {
        public int Value { get; private set; }
        public int Width { get; private set; }
        public int Indent { get; private set; }
        public int Row { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }
        public Node Parent { get; private set; }

        public Node(int value)
        {
            Value = value;
            Row = 0;
        }

        private int CalcWidth()
        {
            Width = Left.CalcWidth() + Right.CalcWidth() + Value.ToString().Length;
            return Width;
        }

        public Node AddNode(int value)
        {
            Node node = new Node(value);
            node.Parent = this;
            Row = Parent.Row + 1;
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

        public void PrintNode()
        {

        }
    }
}
}
