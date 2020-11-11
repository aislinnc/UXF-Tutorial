using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add UXF namespace
using UXF;

public class StartPointController : MonoBehaviour
{
    // Reference to the UXF Session - so we can start the trial
    public Session session; // <-- new
    
    // Define 3 public variable - we can then assign their color values in the inspector
    public Color red;
    public Color amber;
    public Color green;

    // Reference to the material we want to change the color of 
    Material material;

    /// Awake is called when the script instance is being loaded
    void Awake(){
        // Get the material that is used to render this object (via the MeshRenderer component)
        material = GetComponent<MeshRenderer>().material;
    }

    IEnumerator Countdown(){
        yield return new WaitForSeconds(0.5f);
        material.color = green;
        session.BeginNextTrial(); // <-- new
    }

    /// OnTriggerEnter is called when the Collider 'other' enters the trigger
    void OnTriggerEnter(Collider other){
        if(other.name == "Cursor" & !session.InTrial){ // <-- new
            material.color = amber;
            StartCoroutine(Countdown());
        }
    }

    /// OnTriggerExit is called when the Collider 'other' enters the trigger
    void OnTriggerExit(Collider other){
        if(other.name == "Cursor"){    
            StopAllCoroutines();
            material.color = red;
        }
    }
}
