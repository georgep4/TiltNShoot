using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScoreTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("ExplosiveWaste"))
        {
            Destroy(gameObject);
        }
    }


}
