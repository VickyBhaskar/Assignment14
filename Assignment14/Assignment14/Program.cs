#nullable disable

using System;
using System.Collections.Generic;

public class LargeDataCollection<T> : IDisposable
{
    private List<T> dataCollection;

    // Constructor to initialize the collection with initial data
    public LargeDataCollection(IEnumerable<T> initialData)
    {
        dataCollection = new List<T>(initialData);
    }

    // Method to add elements to the collection
    public void AddElement(T element)
    {
        dataCollection.Add(element);
    }

    // Method to remove elements from the collection
    public void RemoveElement(T element)
    {
        dataCollection.Remove(element);
    }

    // Method to access elements in the collection
    public T GetElement(int index)
    {
        if (index >= 0 && index < dataCollection.Count)
        {
            return dataCollection[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Index out of range");
        }
    }

    // Method to get the count of elements in the collection
    public int GetElementCount()
    {
        return dataCollection.Count;
    }

    // Dispose method to release resources
    public void Dispose()
    {
        // Release any unmanaged resources here

        // Set the internal data structure to null to free up memory
        dataCollection = null!;

        // Suppress finalization to avoid unnecessary cleanup
        GC.SuppressFinalize(this);
    }
}

class Program
{
    static void Main()
    {
        // Creating an instance of LargeDataCollection with initial data
        var largeData = new LargeDataCollection<int>(new[] { 1, 2, 3, 4, 5 });

        // Demonstrating adding, removing, and accessing elements
        largeData.AddElement(6);
        Console.WriteLine("Element at index 2: " + largeData.GetElement(2));

        // Removing an element
        largeData.RemoveElement(3);

        // Displaying the elements after modification
        Console.WriteLine("Elements after modification:");
        for (int i = 0; i < largeData.GetElementCount(); i++)
        {
            Console.WriteLine(largeData.GetElement(i));
        }

        // Explicitly calling Dispose to release resources
        largeData.Dispose();
    }
}
