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

    /// <summary>
    /// This function creates a new entry in the leaderboard
    /// </summary>
    /// <param name="rank">The rank of the player</param>
    /// <param name="name">The name of the player</param>
    /// <param name="time">The time of the player</param>
    public void NewEntry(int rank, string name, float time)
    {
        transform.Find("rank").GetComponent<TMPro.TextMeshProUGUI>().text = rank.ToString();
        transform.Find("name").GetComponent<TMPro.TextMeshProUGUI>().text = name;
        transform.Find("time").GetComponent<TMPro.TextMeshProUGUI>().text = Leaderboard.FormatTime(time);
    }
    /// <summary>
    /// This function creates a blank entry in the leaderboard
    /// </summary>
    public void BlankEntry()
    {
        transform.Find("rank").GetComponent<TMPro.TextMeshProUGUI>().text = "";
        transform.Find("name").GetComponent<TMPro.TextMeshProUGUI>().text = "";
        transform.Find("time").GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }

}
