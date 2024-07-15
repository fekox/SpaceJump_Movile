using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private GameObject platformCollider;

    private float aspect_1 = 4.0f / 3.0f;
    private float aspect_2 = 16.0f / 9.0f;
    private float aspect_3 = 20.0f / 9.0f;

    private float currentAspect = (float)Screen.width / (float)Screen.height;
    private float aspectRatioTolerance = 0.01f;

    void Start()
    {
        if (Mathf.Abs(currentAspect - aspect_1) < aspectRatioTolerance)
        {
            platforms[0].transform.position = new Vector3(-6f, -5f, 0f);
            platforms[2].transform.position = new Vector3(6f, -5f, 0f);

            platformCollider.transform.position = new Vector3(-12f, -4f, 0f);
        }

        if (Mathf.Abs(currentAspect - aspect_2) < aspectRatioTolerance)
        {
            platforms[0].transform.position = new Vector3(-8f, -5f, 0f);
            platforms[2].transform.position = new Vector3(8f, -5f, 0f);

            platformCollider.transform.position = new Vector3(-15.25f, -4f, 0f);
        }

        if (Mathf.Abs(currentAspect - aspect_3) < aspectRatioTolerance)
        {
            platforms[0].transform.position = new Vector3(-9.3f, -5f, 0f);
            platforms[2].transform.position = new Vector3(9.3f, -5f, 0f);

            platformCollider.transform.position = new Vector3(-15.25f, -4f, 0f);
        }
    }
}
