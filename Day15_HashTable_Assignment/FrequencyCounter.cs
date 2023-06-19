using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15_HashTable_Assignment
{
    internal class FrequencyCounter
    {
        private LinkedList<MyMapNode<string, int>>[] hashTable;
        private int size;

        public FrequencyCounter(int size)
        {
            this.size = size;
            hashTable = new LinkedList<MyMapNode<string, int>>[size];
        }

        private int GetIndex(string key)
        {
            int index = Math.Abs(key.GetHashCode()) % size;
            return index;
        }

        public void AddWord(string word)
        {
            int index = GetIndex(word);
            if (hashTable[index] == null)
            {
                hashTable[index] = new LinkedList<MyMapNode<string, int>>();
            }

            LinkedList<MyMapNode<string, int>> linkedList = hashTable[index];
            MyMapNode<string, int> node = null;

            foreach (var mapNode in linkedList)
            {
                if (mapNode.Key.Equals(word))
                {
                    node = mapNode;
                    break;
                }
            }

            if (node == null)
            {
                MyMapNode<string, int> newNode = new MyMapNode<string, int>()
                {
                    Key = word,
                    Value = 1
                };
                linkedList.AddLast(newNode);
            }
            else
            {
                node.Value++;
            }
        }

        public void RemoveWord(string word)
        {
            int index = GetIndex(word);
            LinkedList<MyMapNode<string, int>> linkedList = hashTable[index];

            if (linkedList != null)
            {
                MyMapNode<string, int> nodeToRemove = null;

                foreach (var mapNode in linkedList)
                {
                    if (mapNode.Key.Equals(word))
                    {
                        nodeToRemove = mapNode;
                        break;
                    }
                }

                if (nodeToRemove != null)
                {
                    linkedList.Remove(nodeToRemove);
                }
            }
        }

        public void DisplayFrequency()
        {
            for (int i = 0; i < size; i++)
            {
                LinkedList<MyMapNode<string, int>> linkedList = hashTable[i];
                if (linkedList != null)
                {
                    Console.WriteLine("Words at index " + i + ":");
                    foreach (MyMapNode<string, int> node in linkedList)
                    {
                        Console.WriteLine(node.Key + ": " + node.Value);
                    }
                    Console.WriteLine();
                }
            }
        }
    }

    public class MyMapNode<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
