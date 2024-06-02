///<remarks>
/// Author: Chase Bennett - Hill
/// Date Created: 30 / 05 / 24
/// Bug: None at the moment
///<remarks>
// <summary>
/// This is a static class and is used to store the leaderboard information and saves it to the player prefs
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Leaderboard
{
    public const int maxEntries = 5; //The Max number of entries to store in the leaderboard
    public static List<LeaderboardEntry> topTimes = new List<LeaderboardEntry>(); //The Global list of the top times stored into the local player prefs
    private const string PlayerPrefsBaseKey = "leaderboard"; //The base key for the player prefs for easy reference

    /// <summary>
    /// Sorts the leaderboard by the times
    /// </summary>
    public static void SortLeaderboard()
    {
        topTimes.Sort((x, y) => x.time.CompareTo(y.time));
    }

    /// <summary>
    /// Adds a player to the leaderboard
    /// </summary>
    public static void AddPlayer(LeaderboardEntry player)
    {
        topTimes.Add(player);
        SortLeaderboard();
        SaveLeaderboard();
    }

    /// <summary>
    /// Saves the leaderboard data to the player prefs
    /// </summary>
    private static void SaveLeaderboard()
    {
        for (int i = 0; i < maxEntries; i++)
        {
            var player = topTimes[i];
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].name", player.userName);
            PlayerPrefs.SetFloat(PlayerPrefsBaseKey + "[" + i + "].time", player.time);
        }
    }

    /// <summary>
    /// Loads the leaderboard data from the player prefs
    /// </summary>
    public static void LoadLeaderboard()
    {
        topTimes.Clear();
        for (int i = 0; i < maxEntries; i++)
        {
            LeaderboardEntry player =
                new()
                {
                    userName = PlayerPrefs.GetString(PlayerPrefsBaseKey + "[" + i + "].name", ""),
                    time = PlayerPrefs.GetFloat(PlayerPrefsBaseKey + "[" + i + "].time", 1000000) //Sets to large number so the blank entries are at the bottom
                };
            topTimes.Add(player);
        }
        SortLeaderboard();
    }

    /// <summary >
    /// Gets the leaderboard entry at the specified index
    /// </summary>
    ///<param name="i">The index of the entry to get</param>

    public static LeaderboardEntry GetLeaderboardEntry(int i)
    {
        if (topTimes[i] == null || topTimes[i].time == 1000000 || topTimes[i].userName == "")
        {
            return null;
        }
        else
        {
            return topTimes[i];
        }
    }

    /// <summary>
    /// Formats the time into mm:ss
    /// </summary>
    /// <param name="time">time in seconds</param>
    /// <returns>the formatted time</returns>
    public static string FormatTime(float time)
    {
        return string.Format("{0:00}:{1:00}", Mathf.Floor(time / 60), time % 60);
    }

    /// <summary>
    /// Gets the rank of the player
    /// </summary>
    /// <param name="time">The time of the player</param>
    /// <returns>The rank of the player if in the top x otherwise 0</returns>
    public static int GetRank(float time)
    {
        for (int i = 0; i < maxEntries; i++)
        {
            if (time < topTimes[i].time)
            {
                return i + 1;
            }
        }
        return 0;
    }
}
