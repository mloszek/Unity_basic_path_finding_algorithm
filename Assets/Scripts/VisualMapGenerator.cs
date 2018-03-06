using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualMapGenerator : MonoBehaviour
{
    public GameObject field;
    public Camera m_camera;

    private float distanceBetweenFields = 1.2f;

    void Start()
    {
        GenerateMap();
        SetCamera();
    }

    void GenerateMap()
    {
        var width = DimensionHolder.width;
        var height = DimensionHolder.height;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Instantiate(field, new Vector3(j * distanceBetweenFields, 0, i * distanceBetweenFields), gameObject.transform.rotation);
            }
        }
    }

    void SetCamera()
    {
        m_camera.transform.position = new Vector3((DimensionHolder.width - 1) * distanceBetweenFields / 2, 1, 
            (DimensionHolder.height - 1) * distanceBetweenFields / 2);

        if (DimensionHolder.width > DimensionHolder.height)
        {
            m_camera.orthographicSize = DimensionHolder.width * distanceBetweenFields / 2;
        }
        else
        {
            m_camera.orthographicSize = DimensionHolder.height * distanceBetweenFields / 2;
        }
    }
}
