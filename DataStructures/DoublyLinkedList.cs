using System;
using System.Collections;
using System.Collections.Generic;

namespace TAFESA_Enrolment_System.DataStructures
{
    /// <summary>
    /// Node for a doubly linked list
    /// </summary>
    /// <typeparam name="T">Any value/reference type</typeparam>
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value) { Value = value; }

        public T Value { get; set; }
        public LinkedListNode<T>? Next { get; set; }
        public LinkedListNode<T>? Previous { get; set; }
    }

    /// <summary>
    /// Generic doubly linked list
    /// </summary>
    /// <typeparam name="T">Any comparable type</typeparam>
    public class DoublyLinkedList<T> : ICollection<T>
    {
        /// <summary>First node (null when empty)</summary>
        public LinkedListNode<T>? Head { get; private set; }

        /// <summary>Last node (null when empty)</summary>
        public LinkedListNode<T>? Tail { get; private set; }

        /// <summary>Current number of nodes</summary>
        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Add a value at the front
        /// </summary>
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        /// <summary>
        /// Add a node at the front
        /// </summary>
        /// <param name="node">Node to insert</param>
        /// <remarks>
        /// Pseudocode=
        /// temp = Head
        /// Head = node
        /// Head.Next = temp
        /// if Count == 0: Tail = Head
        /// else: temp.Previous = Head
        /// Count++
        /// </remarks>
        public void AddFirst(LinkedListNode<T> node)
        {
            // save old head
            LinkedListNode<T>? temp = Head;

            // point to new node
            Head = node;

            // chain old list after new head
            Head.Next = temp;

            if (Count == 0)
            {
                // first insert
                Tail = Head;
            }
            else
            {
                // old head now has previous
                temp!.Previous = Head;
            }

            Count++;
        }

        /// <summary>
        /// Add a value at the end
        /// </summary>
        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        /// <summary>
        /// Add a node at the end
        /// </summary>
        /// <param name="node">Node to append</param>
        /// <remarks>
        /// Pseudocode=
        /// if Count == 0: Head = node
        /// else: Tail.Next = node; node.Previous = Tail
        /// Tail = node
        /// Count++
        /// </remarks>
        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                // link both directions
                Tail!.Next = node;
                node.Previous = Tail;
            }

            // set new tail
            Tail = node;
            Count++;
        }

        /// <summary>
        /// Remove the first node
        /// </summary>
        /// <remarks>
        /// Pseudocode=
        /// if Count != 0:
        ///     Head = Head.Next
        ///     if Head == null: Tail = null
        ///     else Head.Previous = null
        ///     Count--
        /// </remarks>
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                // move head to next
                Head = Head!.Next;

                if (Head == null)
                {
                    // list now empty
                    Tail = null;
                }
                else
                {
                    // new head has no previous
                    Head.Previous = null;
                }

                Count--;
            }
        }

        /// <summary>
        /// Remove the last node
        /// </summary>
        /// <remarks>
        /// Pseudocode=
        /// if Count == 1: Head = Tail = null
        /// else: Tail.Previous.Next = null; Tail = Tail.Previous
        /// Count--
        /// </remarks>
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    // unlink old tail
                    Tail!.Previous!.Next = null;

                    // shift tail back
                    Tail = Tail.Previous;
                }

                Count--;
            }
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        /// <summary>
        /// Clear the list (Head/Tail to null, Count to 0)
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Check if the list contains a value
        /// </summary>
        /// <remarks>
        /// Pseudocode=
        /// cur = Head
        /// while cur != null:
        ///     if cur.Value == item: return true
        ///     cur = cur.Next
        /// return false
        /// </remarks>
        public bool Contains(T item)
        {
            var cur = Head;
            while (cur != null)
            {
                if (Equals(cur.Value, item))
                {
                    return true;
                }
                cur = cur.Next;
            }
            return false;
        }

        /// <summary>
        /// Copy values into an array starting at arrayIndex
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Length - arrayIndex < Count) throw new ArgumentException("Destination too small.");

            var cur = Head;
            while (cur != null)
            {
                array[arrayIndex++] = cur.Value;
                cur = cur.Next;
            }
        }

        /// <summary>
        /// Remove first occurrence of value (returns true if removed)
        /// </summary>
        /// <remarks>
        /// Pseudocode=
        /// cur = Head
        /// while cur != null:
        ///   if cur.Value == item:
        ///     if cur.Previous != null: cur.Previous.Next = cur.Next else Head = cur.Next
        ///     if cur.Next != null:     cur.Next.Previous = cur.Previous else Tail = cur.Previous
        ///     Count--; return true
        ///   cur = cur.Next
        /// return false
        /// </remarks>
        public bool Remove(T item)
        {
            LinkedListNode<T>? previous = null;
            LinkedListNode<T>? current = Head;

            while (current != null)
            {
                if (Equals(current.Value, item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            // removed tail, so update Tail
                            Tail = previous;
                        }
                        else
                        {
                            // reconnect Previous to skip the removed node
                            current.Next.Previous = previous;
                        }

                        Count--;
                    }
                    else
                    {
                        // first node
                        RemoveFirst();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Enumerate (traverse) values from Head to Tail
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T>? current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
