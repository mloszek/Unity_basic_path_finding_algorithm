using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenuScript : MonoBehaviour
{
    public GameObject ingamePopup;
    public GameObject warningPopup;

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
        AstarHandler astar = new AstarHandler(MapProperties.height, MapProperties.width);
        astar.RunAlgorithm();
        astar.ShowResultOnMap();
        if (astar.GetResultLength() == 0)
        {
            BroadcastPopUp();
        }
        else
        {
            ingamePopup.SetActive(false);
        }        
    }        

    public void Algorithm_2()
    {
        //TODO
    }

    public void SaveGame()
    {
        SaveLoadScript.Save();
    }

    public void GoToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void BroadcastPopUp()
    {
        StartCoroutine(Broadcast());
    }

    IEnumerator Broadcast()
    {
        warningPopup.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        warningPopup.SetActive(false);
    }
}
