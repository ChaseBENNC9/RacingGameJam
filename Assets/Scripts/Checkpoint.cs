using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public Material activatedMaterial;
    public Material defaultMaterial;
    private bool isActivated = false;
    public bool IsActivated
    {
        get => isActivated; 
        set
        {
            isActivated = value;
            if (isActivated) //When the value is changed it updates the material of the checkpoint corresponding to the value
            {
                transform.GetComponentInChildren<MeshRenderer>().material = activatedMaterial;
            }
            else
            {
                transform.GetComponentInChildren<MeshRenderer>().material = defaultMaterial;
            }
        }
    }

    public float activatedTime = 0.0f;




    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        this.IsActivated = true;
    }
}
}



