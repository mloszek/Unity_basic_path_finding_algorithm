using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    public GameObject field;
    public Camera m_camera;

    private float distanceBetweenFields = 1.1f;

    void Start()
    {
        if (!MapProperties.isLoaded)
        {
            ClearMapGenerator.CreateMap(field);
        }
        else
        {
            LoadedMapGenerator.CreateMap(field);
        }

        SetCamera();
    }

    void SetCamera()
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
