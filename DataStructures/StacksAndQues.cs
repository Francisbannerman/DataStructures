using System;
using System.Linq;

namespace DataStructures
{
    public class StacksAndQues
    //linear data structures i.e one-by-one
    {
        //Stacks = Last In First Out.
        //lookup = BigO(n)
        //pop = BigO(1)
        //push = BigO(1)
        //peek = BigO(1)
        //usage example is a browser history. Can be built with arrays with arrays or linked lists.
        //
        
        //Queues = First In First Out
        //lookup = BigO(n)
        //pop/ dequeue/ remove = BigO(1)
        //push/ enqueue/add = BigO(1)
        //peek = BigO(1)
        //usage example is a waiting list queue. Can be built with arrays with arrays or linked lists.
        //
        
    }
    public class StackNode //Stacked by Linked List
    {
        public object Value;
        public StackNode Next;

        public StackNode()
        {
        }
        public StackNode(object value)
        {
            Value = value;
            Next = null;
        }
    }

    public class Stack //Stacked Implementation by Linked List
    {
        public StackNode Head;
        public StackNode Tail;
        public int length;

        public void Push(object value)
        {
            var newStackNode = new StackNode(value);

            if (Head == null)
            {
                newStackNode = Head;
                newStackNode = Tail;
            }
            else
            {
                StackNode currentHead = this.Head;
                newStackNode = Head;
                Head.Next = currentHead;
            }
            length++;
        }

        public void Peek()
        {
            Console.WriteLine(Head);
        }

        public void Pop()
        {
            if (Head == null)
            {
                return;
            }
            Head = Head.Next;
            length--;
        }

        public void Print()
        {
            object[] array = new object[this.length];
            StackNode currentNode = this.Head;

            while (currentNode != null)
            {
                array.Append(currentNode.Value).ToArray();
                currentNode = currentNode.Next;
            }

            foreach (object item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
    
    public class StackedNodes //Stacked By Arrays
    {
        public string Peek(string[] array)
        {
            var peeking = array[array.Length - 1];
            return peeking;
        }

        public string[] Push(string[] array, string value)
        {
            array = array.Append(value).ToArray();
            return array;
        }

        public string[] Pop(string[] array)
        {
            var arrayList = array.ToList();
            arrayList.RemoveAt(array.Length - 1);
            array = arrayList.ToArray();
            return array;
        }
    }

    public class QueueNode //Queued by Linked List
    {
        public object Value;
        public QueueNode Next;
    }

    public class Queue //Queue Implementation by Linked List
    {
        private QueueNode first;
        public QueueNode last;
        public int length = 0;

        public QueueNode Peek()
        {
            return this.first;
        }

        public QueueNode Enqueue()
        {
            QueueNode queueNode = new QueueNode();
            if (length == 0)
            {
                first = queueNode;
                last = queueNode;
            }
            else
            {
                last.Next = queueNode;
                queueNode = last;
            }
            length++;
            return this.last;
        }

        public QueueNode Dequeue()
        {
            if (first == null)
            {
                return null;
            }
            first = first.Next;
            length--;
            return first;
        }
    }
}