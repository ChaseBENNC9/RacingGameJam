///<summary>
/// Manages information about a single checkpoint
/// </summary>
///<remarks>
/// Author: Chase Bennett - Hill
/// Date Created: 06 / 06 / 24
/// Bug: None at the moment
///<remarks>

using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    public Material activatedMaterial; //Material for when the checkpoint is activated
    public Material defaultMaterial; //Material for when the checkpoint is not activated
    private bool isActivated = false; //Boolean to check if the checkpoint is activated
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

    public float activatedTime = 0.0f; //Time when the checkpoint was activated




    void OnTriggerEnter(Collider other) //When the player triggers the checkpoint it is activated
{
    if (other.CompareTag("Player"))
    {
        this.IsActivated = true;
    }
}
}



