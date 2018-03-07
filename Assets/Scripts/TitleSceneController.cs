using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public GameObject panel;
    public Text widthAmount;
    public Text heightAmount;
    public Text noMapWarning;

    private int desiredMapWidth = 10;
    private int desiredMapHeight = 10;

    void Start()
    {
        widthAmount.text = desiredMapWidth.ToString();
        heightAmount.text = desiredMapHeight.ToString();
        MapProperties.width = (int) desiredMapWidth;
        MapProperties.height = (int) desiredMapHeight;
        noMapWarning.text = "";
    }

    public void OpenStartPopup()
    {
        panel.SetActive(true);
    }

    public void ClosePopup()
    {
        panel.SetActive(false);
    }
    
    public void BeginTheGame()
    {
        MapProperties.fields = null;
        MapProperties.isLoaded = false;
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMap()
    {
        if (File.Exists(Application.persistentDataPath + "\\save.crp"))
        {
            MapProperties.fields = SaveLoadScript.Load();
            MapProperties.isLoaded = true;
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            StartCoroutine(ShowText("NO MAP FOUND"));
        }
    }

    public void ShutDown()
    {
        Application.Quit();
    }

    public void SetWidth(float value)
    {
        widthAmount.text = value.ToString();
        desiredMapWidth = (int) value;
        MapProperties.width = (int) value;
    }

    public void SetHeight(float value)
    {
        heightAmount.text = value.ToString();
        desiredMapHeight = (int) value;
        MapProperties.height = (int) value;
    }

    IEnumerator ShowText(string givenSentence)
    {
        noMapWarning.text = givenSentence;
        yield return new WaitForSeconds(3.0f);
        noMapWarning.text = "";
    }
}
