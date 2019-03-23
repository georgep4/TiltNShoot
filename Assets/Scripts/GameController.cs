using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int collectable = 0;
    public bool collectedAll = false;



    // Update is called once per frame
    void Update()
    {
        if (collectable <= 0)
        {
          collectedAll = true;
          LevelManager.Instance.Victory();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else collectedAll = false;
        

    }

}
