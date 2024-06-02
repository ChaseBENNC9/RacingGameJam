/// <summary>
/// Manages the current state of the race
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
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    private float raceTime = 0.0f;
    private int currentLap = 1;
    private bool isRacing = false;
    public static RaceManager instance;
    public TextMeshProUGUI timerText;
    public GameObject endScreen;
    public float currentTime;

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
        StartRace();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }


/// <summary>
/// This function updates the timer every second
/// </summary>
    public void UpdateTime()
    {
        if (isRacing)
        {
            if (Time.time > currentTime + 1)
            {
                currentTime = Time.time;
                raceTime++;
                timerText.text = Leaderboard.FormatTime(raceTime);
            }
        }
    }

/// <summary>
/// This function starts the race timer
/// </summary>
    public void StartRace()
    {
        currentTime = Time.time;
        isRacing = true;
    }

/// <summary>
/// This function ends the race and shows the end panel
/// </summary>
    public void EndRace()
    {
        isRacing = false;
        endScreen.SetActive(true);
    }

/// <summary>
/// This function gets the current race time
/// </summary>
/// <returns>The current time
/// </returns>
    public float GetRaceTime()
    {
        return raceTime;
    }
    /// <summary>
    /// This function resets the scene
    /// </summary>
    public void ResetRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
