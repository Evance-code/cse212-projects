using System;

public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Insert the middle value of the current range into the BST,
    /// then recursively do the same for the left and right ranges.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: no elements to insert
        if (first > last)
        {
            return;
        }

        // Find middle index
        int middle = (first + last) / 2;

        // Insert middle value
        bst.Insert(sortedNumbers[middle]);

        // Insert left half
        InsertMiddle(sortedNumbers, first, middle - 1, bst);

        // Insert right half
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}
