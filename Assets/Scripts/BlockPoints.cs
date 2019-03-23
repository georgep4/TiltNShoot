using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPoints : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Block_LV2")
        {
            KeepScore.Score += 100;
            Destroy(gameObject);

        }
    }



}
