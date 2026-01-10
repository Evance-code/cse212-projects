public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Okay, so I need to make an array that has 'length' items in it
        // Each item should be a multiple of 'number'
        // First multiple is just number * 1
        // Second is number * 2, and so on

        // Let me think about the steps:
        // 1. Make a new array that can hold 'length' doubles
        // 2. Use a loop to fill it up
        // 3. For position i in the array, put number * (i+1)
        //    Wait, why i+1? Because arrays start at 0 but multiples start at 1
        //    So when i=0 (first spot), we want number*1
        //    When i=1 (second spot), we want number*2
        // 4. Give back the filled array

        double[] result = new double[length];  // Step 1

        // Step 2 & 3: Fill it up
        for (int i = 0; i < length; i++)
        {
            // This feels right - each spot gets number times (position+1)
            result[i] = number * (i + 1);
        }

        return result;  // Step 4
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Hmm, rotating right... so if amount is 3, last 3 items move to front
        // Need to think this through carefully

        // First check: if the list is empty or if we rotate by full length, nothing changes
        if (data.Count == 0 || amount == data.Count)
        {
            return;  // Nothing to do here
        }

        // Actually, I should probably handle if amount is 0 too, but problem says it's 1 or more

        // My plan:
        // 1. Grab the last 'amount' items from the list
        //    Like if list is [1,2,3,4,5,6,7,8,9] and amount=3
        //    Grab [7,8,9]
        // 2. Remove those items from where they are
        // 3. Stick them at the beginning

        // Let me try this approach...

        // Step 1: Get the items that need to move
        // Starting position is total items minus amount
        // Like 9 items total, amount=3, start at position 6 (which is index 6? Wait, 0-based...)
        // Actually, 9-3=6, and index 6 has value 7 in [1,2,3,4,5,6,7,8,9]
        // Yes that's right!
        int startPosition = data.Count - amount;
        List<int> movingItems = data.GetRange(startPosition, amount);

        // Step 2: Take them out from the end
        data.RemoveRange(startPosition, amount);

        // Step 3: Put them at the front
        // There's InsertRange that lets me insert a bunch at once
        data.InsertRange(0, movingItems);

        // That should work... let me mentally test:
        // Original: [1,2,3,4,5,6,7,8,9], amount=3
        // GetRange(6,3) = [7,8,9]
        // RemoveRange(6,3) leaves [1,2,3,4,5,6]
        // InsertRange(0,[7,8,9]) gives [7,8,9,1,2,3,4,5,6]
        // Wait, that's 8 items? Oh, [7,8,9,1,2,3,4,5,6] is 9 items, correct!

        // Another thought: what if amount is bigger than half the list?
        // Like [1,2,3,4,5], amount=4
        // Should become [2,3,4,5,1]?
        // Actually rotating [1,2,3,4,5] right by 4:
        // Last 4 are [2,3,4,5], remove them: [1]
        // Insert at front: [2,3,4,5,1] ✓
    }
}