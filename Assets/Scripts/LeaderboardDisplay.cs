using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardDisplay : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    private List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    void Start()
    {
        Leaderboard.LoadLeaderboard();

        texts.Add(text1);
        texts.Add(text2);
        texts.Add(text3);
        texts.Add(text4);
        texts.Add(text5);

        for (int i = 0; i < Leaderboard.maxDisplay; i++)
        {
            if (Leaderboard.GetLeaderboardEntry(i) != null)
            {
                texts[i].text = Leaderboard.GetLeaderboardEntry(i).userName + " - " + Leaderboard.GetLeaderboardEntry(i).time;
            }
            else
            {
                texts[i].text = "";
            }
        }
    }


}
