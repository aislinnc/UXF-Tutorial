using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

// I either need this class to talk with TooSlowCheck or I need to put this code in that class
public class TrialSettings : MonoBehaviour
{
    // Method to check if the staircase is going up or down
    public bool GetTrialHistory(Session session){
        // Get number of trials
        List<int> trialList = new List<int>(UXF.Session.Trials);
        int trialsDone = trialList.Count;

        // Loop through past three trials 
        bool outcome = false;
        if(trialList.Count>=3){
            for(int i = 1; i < 4; i++){
                // If one of the trials was too slow, failed = true
                if(Session.GetTrial(trialsDone-i).result["outcome"] == "tooslow"){
                   outcome = true;
                }
            }
        }
        else{
            // What do I do if their aren't three trials to look at?
        }

        return outcome;
    }

    // Method to adjust difficulty by changing countdown
    float DifficultyAdjuster(Session session, float time){
        // Get outcome from past trials
        bool outcome = GetTrialHistory(session);

        // Change countdown based on outcome of past trials
        float newTime;
        if(outcome == false){
            newTime = time + 0.1;
        }
        else{
            newTime = time - 0.1;
        }
    }
}
