using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add UXF namespace
using UXF; // <-- new

public class TargetController : MonoBehaviour
{
    // Reference to the UXF Session - so we can end the trial
    public Session session; // <-- new

    // Reference to the AudioClip we want to play on trigger enter
    public AudioClip collectSound;

    void Start(){ // <-- new
        //disable the whole GameObject immediatley
        gameObject.SetActive(false); // <-- new
    }

    /// OnTriggerEnter is called when the Collider 'other' enters the trigger.
    void OnTriggerEnter(Collider other){
        if(other.name == "Cursor"){
            // Disable the whole game object
            gameObject.SetActive(false);

            // Play the collect sound (at the same position as the target, 100% volume)
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 1.0f);

            // End current trial
            session.EndCurrentTrial(); // <-- new
        }
    }
}
