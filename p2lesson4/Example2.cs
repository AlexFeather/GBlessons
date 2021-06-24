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
        }
    }

    class Node
    {
        public int Value { get; private set; }
        public int Width { get; private set; }
        public int Indent { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }
        public Node Parent { get; private set; }

        public Node(int value)
        {
            Value = value;
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
            return node;
        }

        public void SetLeft(Node node)
        {
            Left = node;
        }

        public void SetRight(Node node)
        {
            Right = node;
        }

        public void PrintNode()
        {

        }
    }
}
}
