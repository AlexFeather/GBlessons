using System;

namespace p2lesson2
{
    public class Node
    {
        public int Value { get; private set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }

    public interface IChainList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class ChainList : IChainList
    {
        Node FirstNode;
        Node LastNode;
        int Length;

        public void AddNode(int value)
        {
            if (FirstNode == null)
            {
                Node newNode = new Node(value);
                ChangeFirstNode(newNode);
                ChangeLastNode(newNode);
                Length++;
            }
            else
            {
                Node newNode = new Node(value);
                LastNode.NextNode = newNode;
                newNode.PrevNode = LastNode;
                ChangeLastNode(newNode);
                Length++;
            }
        }

        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node(value);
            Node nextNode = node.NextNode;
            newNode.NextNode = nextNode;
            newNode.PrevNode = node;
            node.NextNode = newNode;
            nextNode.PrevNode = newNode;
        }

        public Node FindNode(int searchValue)
        {
            Node current = FirstNode;
            while (current.NextNode != null)
            {
                if (current.Value == searchValue)
                    return current;
                else
                    current = current.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            return Length;
        }

        public void RemoveNode(int index)
        {
            Node current = FindNodeByIndex(index);
            Node prev = current.PrevNode;
            Node next = current.NextNode;
            prev.NextNode = next;
            next.PrevNode = prev;
        }

        public void RemoveNode(Node node)
        {
            Node prev = node.PrevNode;
            Node next = node.NextNode;
            prev.NextNode = next;
            next.PrevNode = prev;
        }

        private void ChangeFirstNode(Node node)
        {
            FirstNode = node;
        }

        private void ChangeLastNode(Node node)
        {
            LastNode = node;
        }

        public Node FindNodeByIndex(int index)
        {
            if (index < Length)
            {
                Node current = FirstNode;
                for (int i = 0; i < index; i++)
                {
                    current = current.NextNode;
                }
                return current;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
