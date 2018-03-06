using System.Collections;
using System.Collections.Generic;
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
        DimensionHolder.width = (int) desiredMapWidth;
        DimensionHolder.height = (int)desiredMapHeight;
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

    public void LoadMap()
    {
        //TODO
        if (true)
        {
            noMapWarning.text = "NO MAP FOUND";
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
        DimensionHolder.width = (int) value;
    }

    public void SetHeight(float value)
    {
        heightAmount.text = value.ToString();
        desiredMapHeight = (int) value;
        DimensionHolder.height = (int) value;
    }

    public void BeginTheGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
