using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetBonusWeaponTarget : MonoBehaviour
{

    public AudioSource source;
    public AudioClip explodeblock;
    GameController gc;
    public GameObject pickupEffect;


    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gc.collectable++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletBall"))
        {
            
           GetComponent<MeshRenderer>().enabled=false;
           GetComponent<Collider>().enabled = false;
           
            GameObject impactGo = Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(impactGo, 2f);
            source.PlayOneShot(explodeblock);
            ScoreCounter.scoreAmount += 1;
            gc.collectable--;
            
            
        }
    }

}
