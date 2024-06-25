///<summary>
/// Manages the checkpoints in the level
/// </summary>
///<remarks>
/// Author: Chase Bennett - Hill
/// Date Created: 06 / 06 / 24
/// Bug: None at the moment
///<remarks>
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    private List<Checkpoint> checkpoints = new();
    public static CheckpointManager inst;
    private Checkpoint lastCheckpoint;
    public TextMeshProUGUI checkpointText;

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
        checkpoints.AddRange(FindObjectsOfType<Checkpoint>()); //Finds all game objects with the Checkpoint script attached
        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.IsActivated = false;
        }
        UpdateCheckpointText();
    }

    public void UpdateCheckpointText()
    {
        List<Checkpoint> activatedCheckpoints = new();
        foreach (Checkpoint checkpoint in checkpoints)
        {
            if (checkpoint.IsActivated)
            {
                activatedCheckpoints.Add(checkpoint);
            }
        }
        checkpointText.text =
            "Checkpoints: \n" + activatedCheckpoints.Count + "/" + checkpoints.Count;
        if (AllCheckpointsActivated())
        {
            checkpointText.color = Color.green;
        }
    }

    ///<summary>
    /// Check if all checkpoints have been activated
    /// </summary>
    ///<returns>True if all checkpoints have been activated, false otherwise</returns>

    public bool AllCheckpointsActivated() //Checks if all checkpoints have been activated
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


    public Checkpoint GetLastCheckpoint() //Returns the last entered checkpoint
    {
        return lastCheckpoint;
    }

    public void SetLastCheckpoint(Checkpoint checkpoint) //Sets the last entered checkpoint
    {
        lastCheckpoint = checkpoint;
    }
}
