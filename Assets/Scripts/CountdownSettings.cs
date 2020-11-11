using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

// I either need this class to talk with TooSlowCheck or I need to put this code in that class
public class CountdownSettings : MonoBehaviour
{
    
    public GameObject slowObject;

    // Method to check if the staircase is going up or down
    public bool GetTrialHistory(Session session){
        // Get number of trials
        List<trial> trialList = new List<trial>(Session.Trials); //Problem with Session.Trials 
        int trialsDone = trialList.Count;

        // Loop through past three trials 
        bool outcome = false;
        if(trialList.Count>=3){
            for(int i = 1; i < 4; i++){
                // If one of the trials was too slow, failed = true
                if(Session.GetTrial(trialsDone-i).result["outcome"] == "tooslow"){ //I don't think this works
                   outcome = true;
                }
            }
        }

        return outcome;
    }

    // Method to adjust difficulty by changing countdown
    float DifficultyAdjuster(Session session, float time){
        // Get outcome from past trials
        bool outcome = GetTrialHistory(session);

        // Change countdown based on outcome of past trials
        float newTime;
        if(notEnoughTrials = false){
            if(outcome == false){
                newTime = time + (float)0.1;
            }
            else{
                newTime = time - (float)0.1;
            }
        }
        else{
            newTime = time;
        }
        
        slowScript = slowObject.GetComponent<TooSlowCheck>();
        slowScript.timer = newTime;

        return newTime;
    }
}
