using System;
using System.Collections.Generic;
using CollectionHierarchy.Contracts;
using CollectionHierarchy.Models;

namespace CollectionHierarchy
{
    public class Engine
    {
        private readonly IAddCollection<string> addCollection;
        private readonly IAddRemoveCollection<string> addRemoveAddCollection;
        private readonly IMyList<string> myList;

        public Engine(
            IAddCollection<string> addCollection, 
            IAddRemoveCollection<string> addRemoveAddCollection, 
            IMyList<string> myList)
        {
            this.addCollection = addCollection;
            this.addRemoveAddCollection = addRemoveAddCollection;
            this.myList = myList;
        }

        public void Run()
        {
            var items = Console.ReadLine().Split();
            var countsToRemoveItems = int.Parse(Console.ReadLine());

            PrintResult(items, countsToRemoveItems);
        }

        private void PrintResult(string[] items, int countsToRemoveItems)
        {
            PrintAddResult(items, addCollection);
            PrintAddResult(items, addRemoveAddCollection);
            PrintAddResult(items, myList);

            PrintRemoveResult(countsToRemoveItems, addRemoveAddCollection);
            PrintRemoveResult(countsToRemoveItems, myList);
        }

        private void PrintRemoveResult(int countsToRemoveItems, IAddRemoveCollection<string> collection)
        {
            var removeResult = new List<string>();

            for (int i = 0; i < countsToRemoveItems; i++)
            {
                removeResult.Add(collection.Remove());
            }

            Console.WriteLine(string.Join(" ", removeResult));
        }

        private void PrintAddResult(string[] items, IAddCollection<string> collection)
        {
            var addResult = new List<int>();

            foreach (var item in items)
            {
                addResult.Add(collection.Add(item));
            }

            Console.WriteLine(string.Join(" ", addResult));
        }
    }
}