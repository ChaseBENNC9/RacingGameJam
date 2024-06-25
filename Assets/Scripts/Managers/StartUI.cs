using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    [SerializeField] private GameObject tutCanvas;

    // Start is called before the first frame update
    void Start()
    {
        tutCanvas.SetActive(false);
    }

    public void PlayButton()
    {
        tutCanvas.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void EndTutorial()
    {
        tutCanvas.SetActive(false);
        SceneManager.LoadScene("Main Scene");
    }

}
