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
            Debug.Log("Player has crossed the finish line with a time of " + Leaderboard.FormatTime(RaceManager.instance.GetRaceTime()));
        }
    }
}
