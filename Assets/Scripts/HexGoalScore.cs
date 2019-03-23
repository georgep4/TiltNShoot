using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGoalScore : MonoBehaviour
{
    public GameObject explosionEffect;
    public AudioSource source;
    public AudioClip explodehex;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("BulletBall"))
        {
            ScoreCounter.scoreAmount += 5;
            source.PlayOneShot(explodehex);
            
            GameObject impactGo = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(impactGo, 2f);
            
            
        }
        Destroy(gameObject);
    }
}
