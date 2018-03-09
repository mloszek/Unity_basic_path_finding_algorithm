using System;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    public GameObject field;

    private GameObject m_camera;
    private ClearMapGenerator clearMap;
    private LoadedMapGenerator loadedMap;
    private float distanceBetweenFields = 1.1f;

    void Start()
    {
        m_camera = GameObject.FindGameObjectWithTag("MainCamera");
        clearMap = ScriptableObject.CreateInstance<ClearMapGenerator>();
        loadedMap = ScriptableObject.CreateInstance<LoadedMapGenerator>();

        GenerateMap();
        SetCamera(m_camera.GetComponent<Camera>());
    }

    void GenerateMap()
    {
        if (!MapProperties.isLoaded)
        {
            clearMap.CreateMap(field);
        }
        else
        {
            SaveLoadScript.Load();
            loadedMap.CreateMap(field);
        }
    }

    void SetCamera(Camera m_camera)
    {
        m_camera.transform.position = new Vector3((MapProperties.width - 1) * distanceBetweenFields / 2, 1,
            (MapProperties.height - 1) * distanceBetweenFields / 2);

        if (MapProperties.width > MapProperties.height)
        {
            m_camera.orthographicSize = MapProperties.width * distanceBetweenFields / 2;
        }
        else
        {
            m_camera.orthographicSize = MapProperties.height * distanceBetweenFields / 2;
        }
    }
}
