/// <summary>
/// This script is responsible for displaying the all the entries to the screen
/// It displays the top 5 times and names
/// </summary>
///<remarks>
/// Author: Chase Bennett - Hill
/// Date Created: 30 / 05 / 24
/// Bug: None at the moment
/// Notes: There is a temporary time value for the player time and the add player will be moved to be at the endscreen.
/// The Delete data is also temporary and will be either removed or moved to the settings screen
///<remarks>

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardDisplay : MonoBehaviour
{
    public GameObject container;
    public GameObject textPrefab;
    public TMP_InputField nameInput;

    void Start()
    {
        DisplayToScreen();
    }

    /// <summary>
    /// This function displays all leaderboard entries to the screen
    /// </summary>
    public void DisplayToScreen()
    {
        Leaderboard.LoadLeaderboard();

        foreach (Transform child in container.transform)
        {
            if (child.tag == "leaderboardEntry")
                Destroy(child.gameObject);
        }

        for (int i = 0; i < Leaderboard.maxEntries; i++)
        {
            GameObject inst = Instantiate(textPrefab, transform);
            inst.transform.SetParent(container.transform);
            LeaderboardDisplayEntry entry = inst.GetComponent<LeaderboardDisplayEntry>();
            if (Leaderboard.GetLeaderboardEntry(i) != null)
            {
                entry.NewEntry(
                    i + 1,
                    Leaderboard.GetLeaderboardEntry(i).userName,
                    Leaderboard.GetLeaderboardEntry(i).time
                );
            }
            else
            {
                entry.BlankEntry();
            }
        }
    }

    /// <summary>
    /// This function deletes all leaderboard entries
    /// </summary>
    public void DeleteLeaderboard()
    {
        PlayerPrefs.DeleteAll();
        DisplayToScreen();
    }
}
