using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    public static int scoreAmount;
    private Text scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = GetComponent<Text>();
        scoreAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounter.text = "Score: " + scoreAmount;
    }
}
