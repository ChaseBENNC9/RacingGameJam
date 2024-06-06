///<summary>
/// Manages the checkpoints in the level
/// </summary>
///<remarks>
/// Author: Chase Bennett - Hill
/// Date Created: 06 / 06 / 24
/// Bug: None at the moment
///<remarks>
using System.Collections.Generic;
using UnityEngine;



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

    ///<summary>   
    /// Check if all checkpoints have been activated
    /// </summary>
    ///<returns>True if all checkpoints have been activated, false otherwise</returns>

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