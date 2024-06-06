using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CheckpointManager : MonoBehaviour
{
    private List<Checkpoint> checkpoints = new();

    void Start()
    {
        checkpoints.AddRange(FindObjectsOfType<Checkpoint>());
        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.IsActivated = false;
        }
    }



}