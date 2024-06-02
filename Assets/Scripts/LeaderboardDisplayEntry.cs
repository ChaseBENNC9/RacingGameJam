/// <summary>
/// This class displays the data for each entry in the leaderboard
/// </summary>
/// <remarks>
///<remarks>
/// Author: Chase Bennett - Hill
/// Date Created: 1 / 06 / 24
/// Bug: None at the moment
///<remarks>


using UnityEngine;

public class LeaderboardDisplayEntry : MonoBehaviour
{
    // Start is called before the first frame update
    public void NewEntry(int rank, string name, float time)
    {
        transform.Find("rank").GetComponent<TMPro.TextMeshProUGUI>().text = rank.ToString();
        transform.Find("name").GetComponent<TMPro.TextMeshProUGUI>().text = name;
        transform.Find("time").GetComponent<TMPro.TextMeshProUGUI>().text = Leaderboard.FormatTime(time);
    }
    public void BlankEntry()
    {
        transform.Find("rank").GetComponent<TMPro.TextMeshProUGUI>().text = "";
        transform.Find("name").GetComponent<TMPro.TextMeshProUGUI>().text = "";
        transform.Find("time").GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }

}
