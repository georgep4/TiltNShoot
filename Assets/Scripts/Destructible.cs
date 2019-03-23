using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public GameObject destroyedVersion; // Reference to the shattered version

    public void Destroy()
    {
    Instantiate(destroyedVersion, transform.position, transform.rotation);
    Destroy(gameObject);
    }
}
