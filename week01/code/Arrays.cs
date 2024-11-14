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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        //Two inputs
        // Number: double 
        // length: int 

        //Start with an empty array of size 'length'
        //'number' is the starting number, and the array will contain its multiples
        // and create a double array with the specified length

        double[] multiplesArray = new double[length];

        // Loop through from 0 to the size of the array
        for (int i = 0; i < length; i++) {
            // For each position, assign the multiple of 'number'
            multiplesArray[i] = number* (i + 1);
        }

        return multiplesArray;   // Return the array with the calculated multiples
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
    // TODO Problem 2 Start
    // Remember: Using comments in your program, write down your process for solving this problem
    // step by step before you write the code. The plan should be clear enough that it could
    // be implemented by another person.

        //first calculate how much we actually need to move the elements
         // We use the modulo (%) with the list size to avoid moving more than necessary
        int effectiveAmount = amount % data.Count;

        // Create a new array to store the rotated values
        int[] rotatedArray = new int[data.Count];

         // Loop through the original list and calculate the new positions for the elements
        for (int i = 0; i < data.Count; i++)
        {
            // Calculate the new index for the current element by adding 'effectiveAmount'
            int newIndex = (i + effectiveAmount) % data.Count;
            rotatedArray[newIndex] = data[i]; // Place the element in its new position
        }

         // Finally, copy the rotated values back into the original 'data' list
        for (int i = 0; i < data.Count; i++)
        {
            data[i] = rotatedArray[i];  // Update the original list with the new values
        }

    }
}
