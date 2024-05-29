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
                userName = PlayerPrefs.GetString(PlayerPrefsBaseKey + "[" + i + "].name", "Player " + i),
                time = PlayerPrefs.GetFloat(PlayerPrefsBaseKey + "[" + i + "].time", 0)
            };
            topTimes.Add(player);
        }
        SortLeaderboard();
    }

    public static PlayerInfo GetLeaderboardEntry(int i)
    {
        if (topTimes[i] == null)
        {
            return null;
        }
        return topTimes[i];
    }

}
