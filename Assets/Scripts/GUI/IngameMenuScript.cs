using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngameMenuScript : MonoBehaviour
{
    public GameObject ingamePopup;
    public GameObject infoPopup;

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

        var watch = System.Diagnostics.Stopwatch.StartNew();

        RunBFS(false);

        watch.Stop();
        Debug.Log(watch.ElapsedMilliseconds);      
    }

    public void BFSfast()
    {
        RefreshGrid();

        var watch = System.Diagnostics.Stopwatch.StartNew();

        RunBFS(true);

        watch.Stop();
        Debug.Log(watch.ElapsedMilliseconds);
    }

    public void DFS()
    {
        RefreshGrid();

        var watch = System.Diagnostics.Stopwatch.StartNew();

        DepthFirstAlgorithm depthFirstAlgorithm = new DepthFirstAlgorithm(MapProperties.height, MapProperties.width, MapGenerator.gridArray);
        depthFirstAlgorithm.CreateGrid();
        depthFirstAlgorithm.Search();

        if (depthFirstAlgorithm.results.Count > 0)
        {
            ingamePopup.SetActive(false);
            depthFirstAlgorithm.ShowPath();
        }
        else
        {
            depthFirstAlgorithm.ShowPath();
            BroadcastInfoPopUp("No available path");
        }

        watch.Stop();
        Debug.Log(watch.ElapsedMilliseconds);
    }

    private void RunBFS(bool IsFast)
    {
        BreadthFirstAlgorithm breadthFirstAlgorithm;

        if (IsFast)
        {
            breadthFirstAlgorithm = new BreadthFirstAlgorithm(MapProperties.height, MapProperties.width, MapGenerator.gridArray, true);
        }
        else
        {
            breadthFirstAlgorithm = new BreadthFirstAlgorithm(MapProperties.height, MapProperties.width, MapGenerator.gridArray, false);
        }

        breadthFirstAlgorithm.CreateGrid();
        breadthFirstAlgorithm.Search();

        if (breadthFirstAlgorithm.results.Count > 0)
        {
            ingamePopup.SetActive(false);
            breadthFirstAlgorithm.ShowPath();
        }
        else
        {
            breadthFirstAlgorithm.ShowPath();
            BroadcastInfoPopUp("No available path");
        }
    }

    public void SaveGame()
    {
        SaveLoadScript.Save();
        BroadcastInfoPopUp("Successfully saved");
    }

    public void GoToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void BroadcastInfoPopUp(string info)
    {
        StartCoroutine(Broadcast(info));
    }

    private void RefreshGrid()
    {
        for (int i = 0; i < MapProperties.height; i++)
        {
            for (int j = 0; j < MapProperties.width; j++)
            {
                if (MapGenerator.gridArray[i][j].tag == "field")
                {
                    MapGenerator.gridArray[i][j].GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
    }

    IEnumerator Broadcast(string info)
    {
        infoPopup.SetActive(true);
        infoPopup.GetComponentInChildren<Text>().text = info;
        yield return new WaitForSeconds(1.5f);
        infoPopup.SetActive(false);
    }
}
