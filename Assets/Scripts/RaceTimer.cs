using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    private float raceTime = 0.0f;
    private int currentLap = 1;
    private bool isRacing = false;
    public static RaceTimer instance;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        raceTime = Time.time; 
        StartRace();  
    }

    // Update is called once per frame
    void Update()
    {
        if (isRacing)
        {
            if (Time.time > raceTime + 1)
            {
                raceTime ++;
                timerText.text = "Time: " + Leaderboard.FormatTime(raceTime);
            }
        }
    }

    public void StartRace()
    {
        isRacing = true;
    }

    public void EndRace()
    {
        isRacing = false;
    }
    public float GetRaceTime()
    {
        return raceTime;
    }
}
