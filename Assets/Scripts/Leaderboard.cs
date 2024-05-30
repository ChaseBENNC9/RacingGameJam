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
    public const int maxDisplay = 5;
    public static List<PlayerInfo> topTimes = new List<PlayerInfo>();
    private const string PlayerPrefsBaseKey = "leaderboard";


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
    public static void AddPlayer(PlayerInfo player)
    {
        topTimes.Add(player);
        SortLeaderboard();
        SaveLeaderboard();

    }

    private static void SaveLeaderboard()
    {
        for (int i = 0; i < maxDisplay; i++)
        {
            var player = topTimes[i];
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].name", player.userName);
            PlayerPrefs.SetFloat(PlayerPrefsBaseKey + "[" + i + "].time", player.time);
        }
    }

    public static void LoadLeaderboard()
    {
        topTimes.Clear();
        for (int i = 0; i < maxDisplay; i++)
        {
            PlayerInfo player = new()
            {
                userName = PlayerPrefs.GetString(PlayerPrefsBaseKey + "[" + i + "].name",""),
                time = PlayerPrefs.GetFloat(PlayerPrefsBaseKey + "[" + i + "].time",1000000) //Sets to large number so the blank entries are at the bottom
            };
                topTimes.Add(player);    
        }
        SortLeaderboard();
    }

    public static PlayerInfo GetLeaderboardEntry(int i)
    {
        if (topTimes[i] == null || topTimes[i].time == 1000000 || topTimes[i].userName == ""	)
        {
            return null;
        }
        else
        {
            return topTimes[i];
        }
    }

}
