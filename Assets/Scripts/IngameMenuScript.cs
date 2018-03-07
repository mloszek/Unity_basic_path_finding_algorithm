using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenuScript : MonoBehaviour
{
    public GameObject ingamePopup;

    public void OpenStartPopup()
    {
        ingamePopup.SetActive(true);
    }

    public void ClosePopup()
    {
        ingamePopup.SetActive(false);
    }

    public void ResetMap()
    {
        MapProperties.isLoaded = false;
        SceneManager.LoadScene("GameScene");
    }

    public void Algorithm_1()
    {
        //TODO
    }

    public void Algorithm_2()
    {
        //TODO
    }

    public void SaveGame()
    {
        SaveLoadScript.Save();
        Debug.Log("game saved!");
    }

    public void GoToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }


}
