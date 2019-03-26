using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusWeaponCoroutine : MonoBehaviour
{

    [SerializeField] public GameObject BonusWeapon;
    [SerializeField] public GameObject BonusWeaponButton;
    [SerializeField] private int timer;
    public GameObject WeaponButton;
    public GameObject Weapon;

    public AudioSource source;
    public AudioClip NewWeapon;
    public AudioClip BacktoBasicWeapon;

    public CircularTimer bonusweapontimer;

    private void Start()
    {
        BonusWeapon.SetActive(false);
        BonusWeaponButton.SetActive(false);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletBall"))
        {

            // Destroy(gameObject);
            source.PlayOneShot(NewWeapon);
            BonusWeapon.SetActive(true);
            BonusWeaponButton.SetActive(true);
            WeaponButton.SetActive(false);
            Weapon.SetActive(false);
            bonusweapontimer.StartTimer();
            StartCoroutine(ShowObject());
        }
    }

    IEnumerator ShowObject()
    {
        yield return new WaitForSeconds(timer);
        source.PlayOneShot(BacktoBasicWeapon);
        BonusWeapon.SetActive(false);
        BonusWeaponButton.SetActive(false);
        WeaponButton.SetActive(true);
        Weapon.SetActive(true);
        Destroy(gameObject);

    }




}
