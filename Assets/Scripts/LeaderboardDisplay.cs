using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardDisplay : MonoBehaviour
{
    private PlayerInfo newPlayer;

    public GameObject container;
    public GameObject textPrefab;
    public TMP_InputField nameInput;
    void Start() {
        DisplayToScreen();
     }

    public void DisplayToScreen()
    {
        Leaderboard.LoadLeaderboard();


        for (int i = 0; i < Leaderboard.maxDisplay; i++)
        {
  
                GameObject inst = Instantiate(textPrefab, transform);
                inst.transform.SetParent(container.transform);
               TextMeshProUGUI leaderboardText = inst.GetComponent<TextMeshProUGUI>();
            if (Leaderboard.GetLeaderboardEntry(i) != null)
            {

                leaderboardText.text = Leaderboard.GetLeaderboardEntry(i).userName + " " + Leaderboard.GetLeaderboardEntry(i).time;
            }
            else
            {
                 leaderboardText.text = "";
            }
        }
    }

 

    public void CreateEntry()
    {
        if (nameInput.text == "")
        {
            return;
        }
        PlayerInfo player = new PlayerInfo
        {
            userName = nameInput.text,
            time = 20f
        };
        Leaderboard.AddPlayer(player);
        DisplayToScreen();
    }
}
