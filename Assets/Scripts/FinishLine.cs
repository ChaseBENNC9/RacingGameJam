///<summary>
/// Manages collision with finish line
/// </summary>
///<remarks>
/// Author: Chase Bennett - Hill
/// Date Created: 01 / 06 / 24
/// Bug: None at the moment
///<remarks>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RaceManager.instance.EndRace();
            Debug.Log(
                "Player has crossed the finish line with a time of "
                    + Leaderboard.FormatTime(RaceManager.instance.GetRaceTime())
            );
        }
    }
}
