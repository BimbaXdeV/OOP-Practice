using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    internal static class SortUtilities
    {
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int i = low;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < arr[high])
                {
                    Swap(ref arr[i], ref arr[j]);
                    i++;
                }
            }
            Swap(ref arr[i], ref arr[high]);
            return i;
        }

        private static void QuickSort(int[] arr, int low = 0, int high = 0)
        {
            if (low < high)
            {
                int pivot = Partition(arr, low, high);
                QuickSort(arr, low, pivot - 1);
                QuickSort(arr, pivot + 1, high);
            }
        }

        public static void QuickSort(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void Heapify(int[] arr, int l, int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            int largest = i;
            if (left < l && arr[left] > arr[largest]) largest = left;
            if (right < l && arr[right] > arr[largest]) largest = right;

            if (largest != i)
            {
                Swap(ref arr[i], ref arr[largest]);
                Heapify(arr, l, largest);
            }
        }

        public static void HeapSort(int[] arr)
        {
            int length = arr.Length;
            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, length, i);
            }

            for (int i = length - 1; i >= 0; i--)
            {
                Swap(ref arr[0], ref arr[i]);
                Heapify(arr, i, 0);
            }
        }

        private static void Merge(int[] arr, int[] temp, int left, int mid, int right)
        {
            int i = left;
            int j = mid + 1;
            int k = left;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                }
            }

            while (i <= mid)
            {
                temp[k++] = arr[i++];
            }

            while (j <= right)
            {
                temp[k++] = arr[j++];
            }

            for (i = left; i <= right; i++)
            {
                arr[i] = temp[i];
            }
        }

        public static void MergeSort(int[] arr)
        {
            int length = arr.Length;
            int[] temp = new int[length];

            for (int currentSize = 1; currentSize <= length - 1; currentSize = 2 * currentSize)
            {
                for (int left = 0; left < length - 1; left += 2 * currentSize)
                {
                    int mid = Math.Min(left + currentSize - 1, length - 1);
                    int right = Math.Min(left + 2 * currentSize - 1, length - 1);
                    Merge(arr, temp, left, mid, right);
                }
            }
        }

        private static void RecursiveStep(int[] arr, int[] temp, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                RecursiveStep(arr, temp, left, mid);
                RecursiveStep(arr, temp, mid + 1, right);
                Merge(arr, temp, left, mid, right);
            }
        }

        public static void MergeSortRecursive(int[] arr)
        {
            int[] temp = new int[arr.Length];
            RecursiveStep(arr, temp, 0, arr.Length - 1);
        }
    }
}
