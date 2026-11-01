#nullable disable
using System;
using System.Collections.Generic;

namespace TallerListasLigadas
{
    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public bool IsEmpty() => head == null;

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (IsEmpty())
            {
                head = tail = newNode;
                return;
            }

            if (value.CompareTo(head.Value) <= 0)
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
                return;
            }

            if (value.CompareTo(tail.Value) >= 0)
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
                return;
            }

            Node<T> current = head;
            while (current != null && current.Value.CompareTo(value) < 0)
            {
                current = current.Next;
            }

            Node<T> prev = current.Previous;
            prev.Next = newNode;
            newNode.Previous = prev;
            newNode.Next = current;
            current.Previous = newNode;
        }

        public void DisplayForward()
        {
            if (IsEmpty())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Node<T> current = head;
            List<string> elements = new List<string>();
            while (current != null)
            {
                elements.Add(current.Value.ToString());
                current = current.Next;
            }
            Console.WriteLine(string.Join(", ", elements));
        }

        public void DisplayBackward()
        {
            if (IsEmpty())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Node<T> current = tail;
            List<string> elements = new List<string>();
            while (current != null)
            {
                elements.Add(current.Value.ToString());
                current = current.Previous;
            }
            Console.WriteLine(string.Join(", ", elements));
        }

        public void SortDescending()
        {
            if (IsEmpty() || head == tail) return;

            Node<T> current = head;
            while (current != null)
            {
                Node<T> temp = current.Next;
                current.Next = current.Previous;
                current.Previous = temp;
                current = temp;
            }

            Node<T> tempHead = head;
            head = tail;
            tail = tempHead;
        }

        private Dictionary<T, int> GetFrequencies()
        {
            Dictionary<T, int> frequencies = new Dictionary<T, int>();
            Node<T> current = head;
            while (current != null)
            {
                if (frequencies.ContainsKey(current.Value))
                    frequencies[current.Value]++;
                else
                    frequencies[current.Value] = 1;
                current = current.Next;
            }
            return frequencies;
        }

        public void DisplayModes()
        {
            if (IsEmpty())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Dictionary<T, int> frequencies = GetFrequencies();
            int maxFrequency = 0;
            foreach (var pair in frequencies)
            {
                if (pair.Value > maxFrequency)
                {
                    maxFrequency = pair.Value;
                }
            }

            List<T> modes = new List<T>();
            foreach (var pair in frequencies)
            {
                if (pair.Value == maxFrequency)
                {
                    modes.Add(pair.Key);
                }
            }

            if (modes.Count == 1)
            {
                Console.WriteLine($"La moda es {modes[0]}.");
            }
            else
            {
                Console.WriteLine($"Las modas son {string.Join(" y ", modes)}.");
            }
        }

        public void DisplayChart()
        {
            if (IsEmpty())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Dictionary<T, int> frequencies = GetFrequencies();
            List<T> processed = new List<T>();
            Node<T> current = head;
            bool hasNumbers = false;

            while (current != null)
            {
                if (current.Value != null && double.TryParse(current.Value.ToString(), out _))
                {
                    if (!processed.Contains(current.Value))
                    {
                        processed.Add(current.Value);
                        int count = frequencies[current.Value];
                        Console.WriteLine($"{current.Value} {new string('*', count)}");
                        hasNumbers = true;
                    }
                }
                current = current.Next;
            }

            if (!hasNumbers)
            {
                Console.WriteLine("No hay ocurrencias numéricas.");
            }
        }

        public bool Exists(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public bool DeleteFirst()
        {
            if (IsEmpty()) return false;

            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            return true;
        }

        public void ClearList()
        {
            head = null;
            tail = null;
        }
    }
}