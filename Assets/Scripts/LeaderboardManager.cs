using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
        endMessage.text = "Congratulations, you made it to the leaderboard! Enter your name to save your time.";
        if (CheckInTopFive(RaceManager.instance.GetRaceTime()))
        {
            leaderboardEntry.gameObject.SetActive(true);
            Debug.Log(Leaderboard.GetRank(RaceManager.instance.GetRaceTime())); 
            entryInfo.NewEntry(Leaderboard.GetRank(RaceManager.instance.GetRaceTime()), "", RaceManager.instance.GetRaceTime());
        }
        else
        {
            endMessage.text = "You didn't make it to the leaderboard. Better luck next time!";
            timeDisplay.transform.parent.gameObject.SetActive(true);
            ShowLeaderboard();
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


    public void ShowLeaderboard()
    {
        leaderboardEntry.gameObject.SetActive(false);
        leaderboardPanel.gameObject.SetActive(true);
        LeaderboardDisplay lbd = leaderboardPanel.GetComponent<LeaderboardDisplay>();
        lbd.DisplayToScreen();

}
}

