using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioSource source;
    public AudioClip explodeblock;
    GameController gc;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gc.collectable++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
           Destroy(gameObject);
            GameObject impactGo = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(impactGo, 2f);
            source.PlayOneShot(explodeblock);
            ScoreCounter.scoreAmount += 1;
           gc.collectable--;

        }
    }


}
