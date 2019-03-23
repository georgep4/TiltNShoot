using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteGameManager : MonoBehaviour
{
    private static CompleteGameManager instance;
    public static CompleteGameManager Instance { get { return instance; } }

    public int currentSkinIndex = 0;
    public int currency = 0;
    public int skinAvailability = 1;


    private void Awake()
    {
      instance = this;
      DontDestroyOnLoad(gameObject);

      if (PlayerPrefs.HasKey("CurrentSkin"))
      {
        //we have played before
        currentSkinIndex = PlayerPrefs.GetInt("CurrentSkin");
        currency = PlayerPrefs.GetInt("Currency");
        skinAvailability = PlayerPrefs.GetInt("SkinAvailability");
      }
      else
      {
            Save();
      }


    }

    public void Save()
    {
        PlayerPrefs.SetInt("CurrentSkin", currentSkinIndex);
        PlayerPrefs.SetInt("Currency", currency);
        PlayerPrefs.SetInt("SkinAvailability", skinAvailability);
    }



}
