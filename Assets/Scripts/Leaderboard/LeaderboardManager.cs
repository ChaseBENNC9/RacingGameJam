/// <summary>
/// This script manages the leaderboard at the end of the race
/// </summary>
///<remarks>
/// Author: Chase Bennett - Hill
/// Date Created: 02 / 06 / 24
/// Bug: None at the moment

///<remarks>

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public GameObject leaderboardEntry;
    public GameObject leaderboardPanel;
    public LeaderboardDisplayEntry entryInfo;
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI endMessage;

    void Start()
    {
        timeDisplay.text = Leaderboard.FormatTime(RaceManager.instance.GetRaceTime());
        timeDisplay.transform.parent.gameObject.SetActive(false);
        endMessage.text =
            "Congratulations, you made it to the leaderboard! Enter your name to save your time.";
        if (CheckInTopFive(RaceManager.instance.GetRaceTime()))
        {
            leaderboardEntry.gameObject.SetActive(true);
            entryInfo.NewEntry(
                Leaderboard.GetRank(RaceManager.instance.GetRaceTime()),
                "",
                RaceManager.instance.GetRaceTime()
            );
        }
        else
        {
            endMessage.text = "You didn't make it to the leaderboard. Better luck next time!";
            timeDisplay.transform.parent.gameObject.SetActive(true);
            ShowLeaderboard();
        }
    }

    /// <summary>
    /// This function checks if the player's time is in the top five
    /// </summary>
    /// <param name="time">The time of the player</param>
    /// <returns>True if the player's time is in the top five, false otherwise</returns>
    public bool CheckInTopFive(float time)
    {
        Leaderboard.LoadLeaderboard();
        if (Leaderboard.GetRank(time) > 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// This function creates a new entry in the leaderboard
    /// </summary>
    public void CreateEntry()
    {
        if (nameInput.text == "")
        {
            return;
        }
        LeaderboardEntry entry =
            new() { userName = nameInput.text, time = RaceManager.instance.GetRaceTime() };
        Leaderboard.AddPlayer(entry);
    }

    /// <summary>
    /// This function shows the leaderboard to the end screen
    /// </summary>
    public void ShowLeaderboard()
    {
        leaderboardEntry.gameObject.SetActive(false);
        leaderboardPanel.gameObject.SetActive(true);
        LeaderboardDisplay lbd = leaderboardPanel.GetComponent<LeaderboardDisplay>();
        lbd.DisplayToScreen();
    }
}
