namespace QuickSortAlgorithm
{
    public class QuickSort
    {
        public static int[] Sort(int[] arr, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return arr;
            }

            int pivotIndex = GetPivotIndex(arr, minIndex, maxIndex);

            Sort(arr, minIndex, pivotIndex - 1);

            Sort(arr, pivotIndex + 1, maxIndex);

            return arr;
        }

        private static int GetPivotIndex(int[] arr, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;

            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (arr[i] < arr[maxIndex])
                {
                    pivot++;
                    Swap(ref arr[pivot], ref arr[i]);
                }
            }

            pivot++;
            Swap(ref arr[pivot], ref arr[maxIndex]);

            return pivot;
        }

        private static void Swap(ref int leftItem, ref int rightItem)
        {
            int temp = leftItem;

            leftItem = rightItem;

            rightItem = temp;
        }
    }
}
