using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Utilities
{
    public static class Utility
    {
        /// <summary>
        /// Linear search over an array
        /// </summary>
        /// <typeparam name="T">Any comparable type</typeparam>
        /// <param name="array">Array to search</param>
        /// <param name="target">Value to search for</param>
        /// <returns>Either the index of the target in the array, or -1 if the target is not found</returns>
        /// <remarks>
        /// Pseudocode=
        /// i = 0
        /// for i to arrayLength - 1:
        ///     if array[i] == target:
        ///         return i
        /// return -1
        /// </remarks>
        public static int LinearSearchArray<T>(T[] array, T target) where T:IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(array);
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].CompareTo(target) == 0)
                        return i;
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("LinearSearchArray comparison failed.", ex);
            }
        }

        /// <summary>
        /// Ensures the array is sorted ascending according to T.CompareTo.
        /// Throws an ArgumentException if any adjacent pair is out of order.
        /// </summary>
        private static void EnsureSortedAscending<T>(T[] array) where T : IComparable<T>
        {
            if (array.Length < 2) return;

            for (int i = 1; i < array.Length; i++)
            {
                // Ensure the array is in ascending order
                if (array[i - 1].CompareTo(array[i]) > 0)
                    throw new ArgumentException("Array must be sorted in ascending order for BinarySearch.", nameof(array));
            }
        }

        /// <summary>
        /// Binary search over a sorted (ascending) array
        /// </summary>
        /// <typeparam name="T">Any comparable type</typeparam>
        /// <param name="array">Sorted (ascending) array</param>
        /// <param name="target">Value to search for</param>
        /// <returns>Either the index of the target in the array, or -1 if the target is not found</returns>
        /// <remarks>
        /// Pseudocode=
        /// min = 0, max = arrayLength - 1
        /// while min <= max:
        ///     mid = min + ((max - min) / 2)
        ///     if array[mid] == target: return mid
        ///     else if array[mid] < target: min = mid + 1
        ///     else max = mid - 1
        /// return -1 if while loop ends and the target is not found
        /// </remarks>
        public static int BinarySearchArray<T>(T[] array, T target) where T : IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(array);

            EnsureSortedAscending(array);

            int min = 0;
            int max = array.Length - 1;
            int mid;
            // if do while, breaks on empty arrays
            try
            {
                while (min <= max)
                {
                    mid = min + ((max - min) / 2);
                    //possible replace to target.CompareTo(array[mid])
                    int compareValue = array[mid].CompareTo(target);
                    if (compareValue == 0)
                        return mid;
                    if (compareValue < 0)
                        min = mid + 1;
                    else
                        max = mid - 1;
                }
                return -1;  // -1 is returned when not found
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("BinarySearchArray comparison failed.", ex);
            }
        }

        /// <summary>
        /// Selection sort over an array (ascending order)
        /// </summary>
        /// <typeparam name="T">Any comparable type</typeparam>
        /// <param name="array">Array to sort</param>
        /// <remarks>
        /// Pseudocode=
        /// for i = 0 to arrayLength - 2:
        ///     minIndex = i
        ///     for j = i + 1 to arrayLength - 1:
        ///         if array[j] < array[minIndex]:
        ///             minIndex = j
        /// </remarks>
        public static void SelectionSortAscending<T>(T[] array) where T : IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(array);
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) < 0)
                        minIndex = j;
                }
                if (minIndex != i)
                {
                    T temp = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = temp;
                }
            }
        }

        /// <summary>
        /// Selection sort over an array (descending order)
        /// </summary>
        /// <typeparam name="T">Any comparable type</typeparam>
        /// <param name="array">Array to sort</param>
        /// <remarks>
        /// Pseudocode=
        /// for i = 0 to arrayLength - 2:
        ///     maxIndex = i
        ///     for j = i + 1 to arrayLength - 1:
        ///         if array[j] > array[maxIndex]:
        ///             maxIndex = j
        /// </remarks>
        public static void SelectionSortDescending<T>(T[] array) where T : IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(array);
            for (int i = 0; i < array.Length - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[maxIndex]) > 0)
                        maxIndex = j;
                }
                if (maxIndex != i)
                {
                    T temp = array[maxIndex];
                    array[maxIndex] = array[i];
                    array[i] = temp;
                }
            }
        }
    }
}
