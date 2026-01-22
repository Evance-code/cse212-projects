using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    
    // Problem 1 - Find symmetric pairs
    
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // skip "aa"-type words
            var reversed = new string(new char[] { word[1], word[0] });

            if (wordSet.Contains(reversed))
            {
                // Avoid duplicates: only add if original is "smaller" alphabetically
                if (string.Compare(word, reversed) < 0)
                    result.Add($"{word} & {reversed}");
            }
        }

        return result.ToArray();
    }

    
    // Problem 2 - Summarize degrees
    
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length < 4) continue; // skip invalid lines

            string degree = fields[3].Trim(); // column 4 is the degree

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    
    // Problem 3 - Check anagrams
   
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length) return false;

        var count = new Dictionary<char, int>();
        foreach (var c in word1)
        {
            if (!count.ContainsKey(c)) count[c] = 0;
            count[c]++;
        }

        foreach (var c in word2)
        {
            if (!count.ContainsKey(c)) return false;
            count[c]--;
            if (count[c] < 0) return false;
        }

        return true;
    }

    
    // Problem 5 - Earthquake daily summary
    
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result; // simpler synchronous fetch
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // Use the existing FeatureCollection class from the project
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var result = new List<string>();
        if (featureCollection?.features != null) // lowercase 'features'
        {
            foreach (var f in featureCollection.features) // lowercase
            {
                result.Add($"{f.properties.place} - Mag {f.properties.mag}");
            }
        }

        return result.ToArray();
    }
}
