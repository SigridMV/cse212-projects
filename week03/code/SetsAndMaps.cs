using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // Create a HashSet to store words we've already seen
        var seen = new HashSet<string>();
        // Create a list to store the result pairs
        var result = new List<string>();

        // Loop through each word in the input array
        foreach (var word in words)
        {
            // Skip words where the first letter is the same as the second letter
            if (word[0] == word[1]) continue;

            // Reverse the current word and store it as a string
            var reverse = new string(word.Reverse().ToArray());

            // Check if the reversed word is already in the seen set
            if (seen.Contains(reverse))
            {
                // If it is, add the pair (reverse & word) to the result list
                result.Add($"{reverse} & {word}");
            }
            else
            {
                // Otherwise, add the current word to the seen set
                seen.Add(word);
            }
        }
        // Return the result list as an array of strings
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        // Create a dictionary to store the degree as the key and the count as the value
        var degrees = new Dictionary<string, int>();

        // Check if the specified file exists
        if (!File.Exists(filename))
        {
            // If the file doesn't exist, throw an exception with an error message
            throw new FileNotFoundException("The specified file does not exist.");
        }

        // Loop through each line in the file
        foreach (var line in File.ReadLines(filename))
        {
            // Split the line by commas to get the individual fields
            var fields = line.Split(",");

            // If the line doesn't have at least 4 fields, skip it
            if (fields.Length < 4) continue;

            // Get the degree (the 4th field in the line) and remove any extra spaces
            var degree = fields[3].Trim();

            // If the degree is empty or null, skip this line
            if (string.IsNullOrEmpty(degree)) continue;

            // Try to get the current count for the degree from the dictionary
            degrees.TryGetValue(degree, out var count);

            // Update the dictionary with the new count for this degree
            degrees[degree] = count + 1;
        }

        // Return the dictionary containing the degree counts
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Remove any spaces from the words and convert them to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // Check if both words have the same length and if their characters match in sorted order
        return word1.Length == word2.Length && word1.OrderBy(c => c).SequenceEqual(word2.OrderBy(c => c));
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        // Define the URI (link) to get the earthquake data from the USGS
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        // Create a new HttpClient to send the GET request
        using var client = new HttpClient();

        // Create the GET request message
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

        // Send the GET request and read the response as a stream
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();

        // Create a StreamReader to read the stream data
        using var reader = new StreamReader(jsonStream);

        // Read the entire JSON content from the stream
        var json = reader.ReadToEnd();

        // Set options to ensure the property names in the JSON are case-insensitive
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // Deserialize the JSON into a FeatureCollection object
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // Extract and create a list of strings describing the place and magnitude of each earthquake
        var descriptions = featureCollection.Features
            // Filter earthquakes that have both a valid magnitude and a non-empty place name
            .Where(feature => feature.Properties.Mag.HasValue && !string.IsNullOrWhiteSpace(feature.Properties.Place))

            // Create a string with the place and magnitude formatted to two decimal places
            .Select(feature => $"{feature.Properties.Place} - Mag {feature.Properties.Mag:F2}")
            .ToArray();

        // Return the array of descriptions
        return descriptions;
    }
}