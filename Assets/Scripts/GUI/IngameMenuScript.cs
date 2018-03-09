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

    public void BFS()
    {
        RefreshGrid();
        RunBFS(false);
    }

    public void BFSfast()
    {
        RefreshGrid();
        RunBFS(true);
    }

    private void RunBFS(bool IsFast)
    {
        DepthFirstAlgorithm depthFirstAlgorithm;

        if (IsFast)
        {
            depthFirstAlgorithm = new DepthFirstAlgorithm(true);
        }
        else
        {
            depthFirstAlgorithm = new DepthFirstAlgorithm();
        }

        depthFirstAlgorithm.CreateGrid();
        depthFirstAlgorithm.Search();

        if (depthFirstAlgorithm.results.Count > 0)
        {
            depthFirstAlgorithm.ShowPath();
            ingamePopup.SetActive(false);
        }
        else
        {
            BroadcastPopUp();
        }
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

    private void RefreshGrid()
    {
        for (int i = 0; i < MapProperties.height; i++)
        {
            for (int j = 0; j < MapProperties.width; j++)
            {
                if (MapGenerator.gridArray[i][j].name == "f")
                {
                    MapGenerator.gridArray[i][j].GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
    }

    IEnumerator Broadcast()
    {
        warningPopup.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        warningPopup.SetActive(false);
    }
}
