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

    public void StartRace()
    {
        currentTime = Time.time;
        isRacing = true;
    }

    public void EndRace()
    {
        isRacing = false;
        endScreen.SetActive(true);
    }

    public float GetRaceTime()
    {
        return raceTime;
    }

    public void ResetRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
