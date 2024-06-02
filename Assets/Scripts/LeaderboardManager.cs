using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LeaderboardManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public GameObject leaderboardEntry;
    public LeaderboardDisplayEntry entryInfo;
    void Start()
    {
        if (CheckInTopFive(RaceManager.instance.GetRaceTime()))
        {
            leaderboardEntry.gameObject.SetActive(true);
            Debug.Log(Leaderboard.GetRank(RaceManager.instance.GetRaceTime())); 
            entryInfo.NewEntry(Leaderboard.GetRank(RaceManager.instance.GetRaceTime()), "", RaceManager.instance.GetRaceTime());
        }
        else
        {
            leaderboardEntry.gameObject.SetActive(false);
        }
    }

    public bool CheckInTopFive(float time)
    {
        Leaderboard.LoadLeaderboard();
        if (Leaderboard.GetRank(time) > 0)
        {
            return true;
        }
        return false;
    }

    public void CreateEntry()
    {
        if (nameInput.text == "")
        {
            return;
        }
        LeaderboardEntry entry = new ()
        {
            userName = nameInput.text,
            time = RaceManager.instance.GetRaceTime()
        };
        Leaderboard.AddPlayer(entry);
    }

}

