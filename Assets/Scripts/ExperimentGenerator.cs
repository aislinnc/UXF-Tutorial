using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add the UXF namespace
using UXF;

public class ExperimentGenerator : MonoBehaviour
{
    // Generate the blocks and trials for the session
    // The session is passed as an argument by the event call
    public void Generate(Session session){
        // Generate a single block with 10 trials
        int numTrials = 10;
        session.CreateBlock(numTrials);
    }
}
