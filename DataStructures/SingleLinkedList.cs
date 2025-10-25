using System;
using System.Collections;
using System.Collections.Generic;

namespace TAFESA_Enrolment_System.DataStructures
{
    /// <summary>
    /// Node for a single linked list
    /// </summary>
    /// <typeparam name="T">any value/reference type</typeparam>
    public class SingleLinkedNode<T>
    {
        public T Value { get; set; }
        public SingleLinkedNode<T>? Next { get; set; }

        public SingleLinkedNode(T value) { Value = value; }
        public SingleLinkedNode(T value, SingleLinkedNode<T>? next)
        {
            Value = value;
            Next = next;
        }
    }

    /// <summary>
    /// Generic single linked list
    /// </summary>
    /// <typeparam name="T">Any comparable type</typeparam>
    public class SingleLinkedList<T> : ICollection<T>
    {
        /// <summary>First node (null when empty)</summary>
        public SingleLinkedNode<T>? Head { get; private set; }

        /// <summary>Last node (null when empty)</summary>
        public SingleLinkedNode<T>? Tail { get; private set; }

        /// <summary>Current number of nodes</summary>
        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Add a value at the front
        /// </summary>
        public void AddFirst(T value)
        {
            AddFirst(new SingleLinkedNode<T>(value));
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
        /// Count++
        /// if Count == 1: Tail = Head
        /// </remarks>
        public void AddFirst(SingleLinkedNode<T> node)
        {
            // keep current head
            var temp = Head;

            // point head to new node
            Head = node;

            // chain old list after new head
            Head.Next = temp;

            // if first insert, Tail becomes Head
            Count++;
            if (Count == 1)
            {
                Tail = Head;
            }
        }

        /// <summary>
        /// Add a value at the end
        /// </summary>
        public void AddLast(T value)
        {
            AddLast(new SingleLinkedNode<T>(value));
        }

        /// <summary>
        /// Add a node at the end
        /// </summary>
        /// <param name="node">Node to append</param>
        /// <remarks>
        /// Pseudocode=
        /// if Count == 0: Head = node
        /// else: Tail.Next = node
        /// Tail = node
        /// Count++
        /// </remarks>
        public void AddLast(SingleLinkedNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail!.Next = node;
            }

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
        ///     Count--
        ///     if Count == 0: Tail = null
        /// </remarks>
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head!.Next;

                Count--;

                if (Count == 0)
                {
                    Tail = null;
                }
            }
        }

        /// <summary>
        /// Remove the last node
        /// </summary>
        /// <remarks>
        /// Pseudocode=
        /// if Count == 1: Head = Tail = null
        /// else: walk until current.Next == Tail, set current.Next = null, Tail = current
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
                    // walk to the node before tail
                    var current = Head!;
                    while (current.Next != Tail)
                    {
                        current = current.Next!;
                    }

                    // unlink old tail
                    current.Next = null;

                    // set new tail
                    Tail = current;
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
        /// current = Head
        /// while current != null:
        ///     if current.Value == item: return true
        ///     current = current.Next
        /// return false
        /// </remarks>
        public bool Contains(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (Equals(current.Value, item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Copy values into an array starting at arrayIndex
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex)
        {
            ArgumentNullException.ThrowIfNull(array);
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Length - arrayIndex < Count) throw new ArgumentException("Destination too small.");

            var current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Remove first occurrence of value (returns true if removed)
        /// </summary>
        /// <remarks>
        /// Pseudocode=
        /// prev = null; cur = Head
        /// while cur != null:
        ///   if cur.Value == item:
        ///     if prev == null: RemoveFirst()
        ///     else:
        ///       prev.Next = cur.Next
        ///       if cur.Next == null: Tail = prev
        ///       Count--
        ///     return true
        ///   prev = cur; cur = cur.Next
        /// return false
        /// </remarks>
        public bool Remove(T item)
        {
            SingleLinkedNode<T>? prev = null;
            var cur = Head;

            while (cur != null)
            {
                if (Equals(cur.Value, item))
                {
                    if (prev == null)
                    {
                        // removing the head
                        RemoveFirst();
                    }
                    else
                    {
                        // bypass current
                        prev.Next = cur.Next;

                        // fixed tail if we removed the last node
                        if (cur.Next == null)
                        {
                            Tail = prev;
                        }

                        Count--;
                    }

                    return true;
                }

                prev = cur;
                cur = cur.Next;
            }

            return false;
        }

        /// <summary>
        /// Enumerate (traverse) values from Head to Tail
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
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
