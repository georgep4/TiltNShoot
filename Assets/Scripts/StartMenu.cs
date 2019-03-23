using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelData
{
    public LevelData(string levelName)
    {
       string data = PlayerPrefs.GetString(levelName);
        if (data == "")
            return;

        string[] allData = data.Split('&');
        BestTime = float.Parse(allData[0]);
        SilverTime = float.Parse(allData[1]);
        GoldTime = float.Parse(allData[2]);

    }

    public float BestTime { set; get; }
    public float SilverTime { set; get; }
    public float GoldTime { set; get; }
}


public class StartMenu : MonoBehaviour
{
    private const float CAMERA_TRANSITION_SPEED = 3.0f;

    public Sprite[] borders;
    public GameObject levelButtonPrefab;
    public GameObject levelButtonContainer;
    public GameObject shopButtonPrefab;
    public GameObject shopButtonContainer;
    public TextMeshProUGUI currencyText;


    public Material bulletballMaterial;

    private bool nextLevelLocked = false;


    private int[] costs = { 0, 150, 150, 150,
                          300, 300, 300, 300,
                          500, 500, 500, 500,
                          1000, 1250, 1500, 2000 };

    // private Transform cameraTransform;
    //private Transform cameraDesiredLookAt;

    private void Start()
    {
        ChangeBulletBallSkin (CompleteGameManager.Instance.currentSkinIndex);
        currencyText.text = "Currency:" + CompleteGameManager.Instance.currency.ToString();
        //cameraTransform = Camera.main.transform;
        
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");

        foreach(Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(levelButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(levelButtonContainer.transform,false);
            LevelData level = new LevelData(thumbnail.name);

            string minutes = ((int) level.BestTime /60).ToString("00");
            string seconds = (level.BestTime%60).ToString("00.00");

            GameObject bottomPanel = container.transform.GetChild(0).GetChild(0).gameObject;

            bottomPanel.GetComponent<Text> ().text = (level.BestTime !=0.0f)
                ? minutes + ":" + seconds
                : "Not Completed";

            container.transform.GetChild(1).GetComponent<Image>().enabled = nextLevelLocked;
            container.GetComponent<Button>().interactable = !nextLevelLocked;

           if (level.BestTime == 0.0f)
           {
               nextLevelLocked = true;
           }
           else if(level.BestTime < level.GoldTime)
           {
                // Put the gold border
                bottomPanel.GetComponentInParent<Image>().sprite = borders[2];
           }
            else if (level.BestTime < level.SilverTime)
            {
                // Put the silver border
                bottomPanel.GetComponentInParent<Image>().sprite = borders[1];
            }
            else 
            {
                // Put the bronze border
                bottomPanel.GetComponentInParent<Image>().sprite = borders[0];
            }


            string sceneName = thumbnail.name;
           container.GetComponent<Button> ().onClick.AddListener (() => LoadLevel(sceneName));
        }

        int textureIndex = 0;
        Sprite[] textures = Resources.LoadAll<Sprite>("Shop");
        foreach (Sprite texture in textures)
        {
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(shopButtonContainer.transform, false);

            int index = textureIndex;
            container.GetComponent<Button>().onClick.AddListener(() => ChangeBulletBallSkin(index));
            container.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = costs[index].ToString();
            if ((CompleteGameManager.Instance.skinAvailability & 1 << index) == 1 << index)
            {
            container.transform.GetChild(0).gameObject.SetActive(false);
            }
            textureIndex++;

        }


    }

    private void Update()
    {
     //   if(cameraDesiredLookAt != null)
       // {
       //     cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, CAMERA_TRANSITION_SPEED * Time.deltaTime);
          
      //  }
    }

    private void LoadLevel(string sceneName)
     {
         SceneManager.LoadScene(sceneName);
     }

   // public void LookAtMenu(Transform menuTransform)
   // {
   //     cameraDesiredLookAt = menuTransform;
   // }

    private void ChangeBulletBallSkin(int index)
    {

        if ((CompleteGameManager.Instance.skinAvailability & 1 << index) == 1 << index)
        {
            float x = (index % 4) * 0.25f;
            float y = ((int)index / 4) * 0.25f;

            if (y == 0.0f)
                y = 0.75f;
            else if (y == 0.25f)
                y = 0.5f;
            else if (y == 0.50f)
                y = 0.25f;
            else if (y == 0.75f)
                y = 0.0f;

            bulletballMaterial.SetTextureOffset("_MainTex", new Vector2(x, y));
            CompleteGameManager.Instance.currentSkinIndex = index;
            CompleteGameManager.Instance.Save();
        }
        else
        {
            // You do not have the skin, do you want to buy it?
            int cost = costs[index];

            if (CompleteGameManager.Instance.currency >= cost)
            {
                CompleteGameManager.Instance.currency -= cost;
                CompleteGameManager.Instance.skinAvailability += 1 << index;
                CompleteGameManager.Instance.Save();
                shopButtonContainer.transform.GetChild(index).GetChild(0).gameObject.SetActive(false);
                currencyText.text = "Currency:" + CompleteGameManager.Instance.currency.ToString();
                ChangeBulletBallSkin (index);
            }

        }
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu");
    }
    
}
