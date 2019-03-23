using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject bulletball;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint (touch.position);

            if (touch.phase == TouchPhase.Began) Instantiate(bulletball, touchPos, Quaternion.identity);

        }
    }
}
