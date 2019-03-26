using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public CircularTimer timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        timer.StartTimer();
    }

    public void PauseTimer()
    {
        timer.PauseTimer();
    }

    public void DidFinishedTimer()
    {
        
    }

}
