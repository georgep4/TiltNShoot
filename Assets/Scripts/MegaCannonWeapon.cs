using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaCannonWeapon : MonoBehaviour
{
    public Button fireButton;
    public Transform MegaCannonFirepoint01;
    public Transform MegaCannonFirepoint02;
    public Transform MegaCannonFirepoint03;
    public GameObject bulletPrefab;

    void Start()
    {
        //add an onclick event to your UI button
        fireButton.onClick.AddListener(() => Shoot());
    }

    // Update is called once per frame
   // void Update()
  //  {
   //     if(Input.GetButtonDown("Fire1"))
   //     {
   //         Shoot();
    //    }

   // }

    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, MegaCannonFirepoint01.position, MegaCannonFirepoint01.rotation);
        Instantiate(bulletPrefab, MegaCannonFirepoint02.position, MegaCannonFirepoint02.rotation);
        Instantiate(bulletPrefab, MegaCannonFirepoint03.position, MegaCannonFirepoint03.rotation);
    }

}
