using System;

namespace p2lesson4
{
    class Example2
    {
        class Node
        {
            public int Value { get; private set; }
            public Node Left { get; private set; }
            public Node Right { get; private set; }
            public Node Parent { get; private set; }

            public Node(int value)
            {
                Value = value;
            }

            public Node AddNode(int value, Node root)
            {
                Node node = new Node(value);
                Node temp = null;
                if (root == null)
                {
                    root = node;
                    return root;
                }
                else
                {
                    temp = root;
                    while (temp != null)
                    {
                        if (node.Value <= temp.Value)
                        {
                            if (temp.Left != null)
                            {
                                temp = temp.Left;
                                continue;
                            }
                            else
                            {
                                temp.Left = node;
                                return root;
                            }
                        }
                        else if(node.Value > temp.Value)
                        {
                            if (temp.Right != null)
                            {
                                temp = temp.Right;
                                continue;
                            }
                            else
                            {
                                temp.Right = node;
                                return root;
                            }
                        }
                        else
                        {
                            throw new Exception("Wrong tree state.");
                        }
                    }
                }
                return root;
            }
        }
    }
}
