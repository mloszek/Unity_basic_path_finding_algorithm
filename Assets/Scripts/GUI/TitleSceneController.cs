using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public GameObject panel;
    public Text widthAmount;
    public Text heightAmount;
    public Text difficultyLevel;
    public Text noMapWarning;

    private int desiredMapWidth = 10;
    private int desiredMapHeight = 10;
    private int desiredDifficulty = 6;

    void Start()
    {
        widthAmount.text = desiredMapWidth.ToString();
        heightAmount.text = desiredMapHeight.ToString();
        difficultyLevel.text = "Easy";
        MapProperties.width = (int) desiredMapWidth;
        MapProperties.height = (int) desiredMapHeight;
        MapProperties.difficulty = (int) desiredDifficulty;
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
        MapProperties.isLoaded = false;
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMap()
    {
        if (File.Exists(Application.persistentDataPath + "\\save.crp"))
        {
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

    public void SetDifficulty(float value)
    {
        var currentDifficulty = 8 - value;

        switch ((int) currentDifficulty)
        {
            case 6:
                difficultyLevel.text = "Easy";
                break;
            case 5:
                difficultyLevel.text = "Medium";
                break;
            case 4:
                difficultyLevel.text = "Hard";
                break;
            case 3:
                difficultyLevel.text = "Violently";
                break;
            case 2:
                difficultyLevel.text = "Melting";
                break;
        }

        desiredDifficulty = (int) currentDifficulty;
        MapProperties.difficulty = (int) currentDifficulty;
    }

    IEnumerator ShowText(string givenSentence)
    {
        noMapWarning.text = givenSentence;
        yield return new WaitForSeconds(3.0f);
        noMapWarning.text = "";
    }
}
