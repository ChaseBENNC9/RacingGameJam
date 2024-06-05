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
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
    private float raceTime = 0.0f;
    public Image trafficLight;
    public List<Sprite> frames = new List<Sprite>();
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
    private float countdownTime = 4.0f;

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
        trafficLight.enabled = true;
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
        if (Time.time > currentTime + 1)
        {
            if (GameManager.currentGameState == GameState.Racing)
            {
                trafficLight.enabled = false;
                currentTime = Time.time;
                raceTime++;
                timerText.text = Leaderboard.FormatTime(raceTime);
            }
            else if (GameManager.currentGameState == GameState.PreGame)
            {
                currentTime = Time.time;
                if (countdownTime <= 1)
                {
                    trafficLight.enabled = false;
                    StartRace();
                    return;
                }
                countdownTime--;
                if (countdownTime > 0)
                    trafficLight.sprite = frames[(int)countdownTime - 1];
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
