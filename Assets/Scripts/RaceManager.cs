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
using UnityEngine.UIElements.Experimental;

public class RaceManager : MonoBehaviour
{
    private float raceTime = 0.0f;
    private int currentLap = 1;
    private bool isRacing
    {
        get { return isRacing; }
        set
        {
            if (value)
            {
                GameManager.currentGameState = GameState.Racing;
            }
        }
    }
    public static RaceManager instance;
    public TextMeshProUGUI timerText;
    public GameObject endScreen;
    private float currentTime;
    private float countdownTime = 3.0f;

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
        GameManager.currentGameState = GameState.PreGame;
        timerText.text = countdownTime.ToString();
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
        if (GameManager.currentGameState == GameState.Racing)
        {
            if (Time.time > currentTime + 1)
            {
                timerText.text = Leaderboard.FormatTime(raceTime);
                currentTime = Time.time;
                raceTime++;
            }
        }
        else if (GameManager.currentGameState == GameState.PreGame)
        {
            if (Time.time > currentTime + 1)
            {
                countdownTime--;
                timerText.text = countdownTime.ToString();
                currentTime = Time.time;
                if (countdownTime <= 0)
                {
                    timerText.text = "GO!";
                    StartRace();
                }
            }
        }
    }

    /// <summary>
    /// This function starts the race timer
    /// </summary>
    public void StartRace()
    {
        currentTime = Time.time;
        GameManager.currentGameState = GameState.Racing;
    }

    /// <summary>
    /// This function ends the race and shows the end panel
    /// </summary>
    public void EndRace()
    {
        GameManager.currentGameState = GameState.End;
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
