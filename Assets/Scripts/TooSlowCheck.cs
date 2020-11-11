using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class TooSlowCheck : MonoBehaviour
{
    public AudioClip failSound;
    public Session session;
    public float time;

    // Adjust difficulty by changing countdown
    public void DifficultyAdjuster(){
        // Get number of trials
        int numTrials = session.CurrentTrial.numberInBlock;

        // Get the time of the previous trial
        if(numTrials == 1){
            time = 1.0f;
        }

        // Check if there's been at lest 3 previous trials 
        float newTime = time;
        if(numTrials>=3){
            // Loop through the past 3 trials 
            for(int i = 1; i < 4; i++){
                // If one of the trials was too slow
                if(session.GetTrial(numTrials-i).result["outcome"] == "tooslow"){
                   newTime = time + 0.1f;
                }
                // If none of the trials were too slow 
                else{
                    newTime = time - 0.1f;
                }
            }
        }
        
        // Set the timer for the new trial
        time = newTime;
    }

    public void BeginCountdown(){
        StartCoroutine(Countdown());
    }

    public void StopCountdown(){
        StopAllCoroutines();
    }

    IEnumerator Countdown(){
        DifficultyAdjuster();

        // Log the time
        session.CurrentTrial.result["time"] = time;

        yield return new WaitForSeconds(time);

        // if we got to this stage, that means we moved too slow
        session.CurrentTrial.result["outcome"] = "tooslow";
        session.EndCurrentTrial();

        // we will play a clip at position above origin, 50% volume
        AudioSource.PlayClipAtPoint(failSound, new Vector3(0, 1.3f, 0), 1.0f);
    }
}
