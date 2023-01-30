using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node
    {
        public object Value;
        public Node Next;
        public Node() { }
        public Node(object value)
        {
            Value = value;
        }
    }


    public class LinkedList
    {
        public Node Head;
        public Node Tail;
        public int Length { get; set; }

        public LinkedList(object value)
        {
            this.Head = new Node()
            {
                Value = value,
                Next = null
            };
            this.Tail = this.Head;
            this.Length = 1;
        }

        public void Append(object value)
        {
            var newNode = new Node()
            {
                Value = value,
                Next = null
            };
            this.Tail.Next = newNode;
            this.Tail = newNode;
            this.Length++;
        }

        public void Prepend(object value)
        {
            var newNode = new Node()
            {
                Value = value,

            };
            newNode.Next = this.Head;
            this.Head = newNode;
            this.Length++;
        }

        public void Insert(int index, object value)
        {
            Node newNode = new Node(value);
            var lastNode = Head;

            if (index >= Length)
            {
                Append(value);
                return;
            }

            if (index == 0)
            {
                Prepend(value);
                return;
            }

            var currentNode = TransverseToIndex(index - 1);
            if (currentNode != null)
            {
                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;
            }
            return;
        }

        public void Remove(int index)
        {
            if (index == 0)
            {
                Head = Head.Next;
                Length--;
                return;
            }
            var currentNode = TransverseToIndex(index - 1);
            var removeNode = currentNode.Next;
            currentNode.Next = removeNode.Next;
            Length--;
        }

        public void Delete(object value)
        {
            Node currentNode = Head;
            Node prev = null;
            if (currentNode != null && Head.Value == value)
            {
                Head = Head.Next;
                Console.WriteLine($"Value: {value} deleted");

                return;
            }
            while (currentNode != null & currentNode.Value != value)
            {
                prev = currentNode;
                currentNode = currentNode.Next;
            }
            if (currentNode != null)
            {
                prev.Next = currentNode.Next;
                Console.WriteLine($"Value: {value} deleted");

            }

            if (currentNode == null)
                Console.WriteLine($"Value: {value} Not Found");

        }

        public void Reverse()
        {
            if (this.Head.Next == null)
            {
                Print();
                return;
            }
            Node first = this.Head;
            this.Tail = this.Head;
            Node second = this.Head.Next;

            while (second != null)
            {
                Node third = second.Next;
                second.Next = first;
                first = second;
                second = third;
            }
            this.Head.Next = null;
            this.Head = first;
        }

        public Node TransverseToIndex(int index)
        {
            int counter = 0;
            var currentNode = Head;
            while (counter != index && currentNode != null)
            {
                currentNode = currentNode.Next;
                counter++;
            }
            return currentNode;
        }

        public void Print()
        {
            object[] array = new object[this.Length];
            Node currentNode = this.Head;

            while (currentNode != null)
            {
                array = array.Append(currentNode.Value).ToArray();
                currentNode = currentNode.Next;
            }

            foreach (object item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
