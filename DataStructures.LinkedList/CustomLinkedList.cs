using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList;

public class CustomLinkedList<T> : IEnumerable<T>
{
    public Node<T> Head { get; private set; }
    public Node<T> Tail { get; private set; }

    public void AddFirst(T data)
    {
        Node<T> node = new(data);
        if (Head is null)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            node.Next = Head;
            Head = node;
        }
    }
    public void AddLast(T data)
    {
        Node<T> node = new(data);
        if (Head is null)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            Tail.Next = node;
            Tail = node;
        }
    }

    public void AddMiddle(T value)
    {
        if (Head is null)
        {
            AddFirst(value);
            return;
        }

        var current = Head;
        int counter = 0;
        var middleIndex = this.Count() / 2;

        while (current is not null)
        {
            if (counter == middleIndex - 1)
            {
                var newNode = new Node<T>(value)
                {
                    Next = current.Next
                };
                current.Next = newNode;
                return;
            }
            current = current.Next;
            counter++;
        }
    }

    public void RemoveFirst()
    {
        if (Head is not null)
        {
            Head = Head.Next;
        }
    }

    public void RemoveLast()
    {
        if (Head is null)
            return;
        if (Head == Tail)
        {
            Head = Tail = null;
            return;
        }

        var previous = Head;
        while (previous.Next != Tail)
        {
            previous = previous.Next;
        }
        Tail = previous;
        Tail.Next = null;
    }

    public void RemoveWithValue(T data)
    {
        if (Head == null)
            return;

        Node<T> current = Head;
        Node<T> previous = null;

        while (current is not null)
        {
            if (current.Data.Equals(data))
            {
                if (current == Head)
                {
                    Head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }

                if (current == Tail)
                {
                    Tail = previous;
                }
                return;
            }
            previous = current;
            current = current.Next;
        }

    }

    public void Deneme(T data)
    {
        var current = Head;
        while (current.Data.ToString() != data.ToString())
        {
            current = current.Next;
        }

        var deleteNode = current;
        current = Head;
        while (current != deleteNode)
        {
            current = current.Next;
        }
        current.Next = deleteNode.Next;
    }



    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = Head;
        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


public class Node<T>
{
    public Node(T data)
    {
        Data = data;
    }

    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public override string ToString()
    {
        return $"Data: {Data}";
    }

}
