using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class TooSlowCheck : MonoBehaviour
{
    public AudioClip failSound;
    public Session session;
    public float timer;

    public void BeginCountdown(){
        StartCoroutine(Countdown());
    }

    public void StopCountdown(){
        StopAllCoroutines();
    }

    IEnumerator Countdown(){
        // THIS NEEDS TO CHANGE FOR TRIAL SETTINGS OR CODE NEEDS TO BE PUT HERE
        yield return new WaitForSeconds(timer);

        // if we got to this stage, that means we moved too slow
        session.CurrentTrial.result["outcome"] = "tooslow";
        session.EndCurrentTrial();

        // we will play a clip at position above origin, 50% volume
        AudioSource.PlayClipAtPoint(failSound, new Vector3(0, 1.3f, 0), 1.0f);
    }
}
