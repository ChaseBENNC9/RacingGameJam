using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CheckpointManager : MonoBehaviour
{
    private List<Checkpoint> checkpoints = new();
    public static CheckpointManager inst;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        checkpoints.AddRange(FindObjectsOfType<Checkpoint>());
        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.IsActivated = false;
        }
    }


    public bool AllCheckpointsActivated()
    {
        foreach (Checkpoint checkpoint in checkpoints)
        {
            if (!checkpoint.IsActivated)
            {
                return false;
            }
        }
        return true;
    }



}