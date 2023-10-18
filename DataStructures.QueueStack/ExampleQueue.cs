using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.QueueStack;

public class ExampleQueue
{
    private const int DEFAULT_SIZE = 50;
    private int head , tail;
    private int[] elements;
    private int count;

    public ExampleQueue(int initialSize = DEFAULT_SIZE)
    {
        elements = new int[initialSize];
    }


    public void Enqueue(int item)
    {
        if (count == elements.Length)
        {
            Extend();
        }

        elements[tail] = item;
        tail++;
        count++;
    }

    public int Dequeue()
    {
        int item = elements[head];
        elements[head] = default;

        head++;

        return item;
    }

    void Extend()
    {
        Array.Resize(ref elements,elements.Length * 2);
        head = 0;
        tail = count - 1;
    }

    void Shrink()
    {
        int[] newArray = new int[elements.Length / 2];

        Array.Copy(elements,head,newArray,0,count);
        elements = newArray;
        head = 0;
        tail = count - 1;
    }

}