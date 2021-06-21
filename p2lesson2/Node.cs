using System;

namespace p2lesson2
{
    public class Node
    {
        public int Value { get; }
        public Node NextNode { get; private set; }
        public Node PrevNode { get; private set; }

        public Node(int value)
        {
            Value = value;
        }

        public void ChangeNextNode(Node nextNode)
        {
            NextNode = nextNode;
        }

        public void ChangePrevNode(Node prevNode)
        {
            PrevNode = prevNode;
        }
    }

    public interface IChainList
    {
        int GetCount(); // возвращает количество элементов в списке
        Node AddLast(int value);  // добавляет новый элемент списка в конец
        Node AddFirst(int value);  // добавляет новый элемент списка в начало
        Node AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        bool RemoveNodeByIndex(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class ChainList : IChainList
    {
        public Node FirstNode { get; private set; }
        public Node LastNode { get; private set; }
        public int Length { get; private set; }

        public Node AddLast(int value)
        {
            Node newNode = new Node(value);
            if (FirstNode == null)
            {
                FirstNode = newNode;
                LastNode = newNode;
                Length++;
            }
            else
            {
                LastNode.ChangeNextNode(newNode);
                newNode.ChangePrevNode(LastNode);
                LastNode = newNode;
                Length++;
            }
            return newNode;
        }

        public Node AddFirst(int value)
        {
            Node newNode = new Node(value);
            if (FirstNode == null)
            {
                
                FirstNode = newNode;
                LastNode = newNode;
                Length++;
            }
            else
            {
                newNode.ChangeNextNode(FirstNode);
                FirstNode.ChangePrevNode(newNode);
                FirstNode = newNode;
                Length++;
            }
            return newNode;
        }

        public Node AddNodeAfter(Node node, int value)
        {
            if (node.NextNode == null)
            {
                Node newNode = AddLast(value);
                return newNode;
            }
            else
            {
                Node newNode = new Node(value);
                Node nextNode = node.NextNode;
                newNode.ChangeNextNode(nextNode);
                newNode.ChangePrevNode(node);
                node.ChangeNextNode(newNode);
                nextNode.ChangePrevNode(newNode);
                return newNode;
            }
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

        public int GetCount() //вообще-то в этом методе нет смысла, так как количество элементов списка можно получить, обратившись напрямую к свойству, но по условию задания он должен быть
        {
            return Length;
        }

        public bool RemoveNodeByIndex(int index)
        {
            Node current = FindNodeByIndex(index);
            if (current != null)
            {
                RemoveNode(current);
                return true;
            }
            else 
                return false;
        }

        public void RemoveNode(Node node)
        {
            Node prev = node.PrevNode;
            Node next = node.NextNode;
            if(prev == null && next == null)
            {
                FirstNode = null;
                LastNode = null;
            }
            if (prev != null)
                prev.ChangeNextNode(next);
            else
                FirstNode = next;
            if (next != null)
                next.ChangePrevNode(prev);
            else
                LastNode = prev;
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
