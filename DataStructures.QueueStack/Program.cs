using DataStructures.QueueStack;



ExampleQueue exampleQueue = new();
for (int i = 0; i < 50; i++)
{
    exampleQueue.Enqueue(i);
}

for (int i = 0; i < 11; i++)
{
    Console.WriteLine(exampleQueue.Dequeue());
}