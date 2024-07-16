using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private GameObject platformCollider;

    private float fourThirds = 4.0f / 3.0f;
    private float sixteenNinths = 16.0f / 9.0f;
    private float eighteenNinths = 18.0f / 9.0f;
    private float nineteenNinths = 19.0f / 9.0f;
    private float twentyNinths = 20.0f / 9.0f;
    private float twentyOneNinths = 21.0f / 9.0f;
    private float twentyTwoNinths = 22.0f / 9.0f;
    private float twentyThreeNinths = 23.0f / 9.0f;

    private float currentAspect = (float)Screen.width / (float)Screen.height;
    private float aspectRatioTolerance = 0.01f;

    public void CheckCameraResolution() 
    {
        if (Mathf.Abs(currentAspect - fourThirds) < aspectRatioTolerance)
        {
            platforms[0].transform.position = new Vector3(-6f, -5f, 0f);
            platforms[2].transform.position = new Vector3(6f, -5f, 0f);

            platformCollider.transform.position = new Vector3(-12f, -4f, 0f);
        }

        if (Mathf.Abs(currentAspect - sixteenNinths) < aspectRatioTolerance)
        {
            platforms[0].transform.position = new Vector3(-8f, -5f, 0f);
            platforms[2].transform.position = new Vector3(8f, -5f, 0f);

            platformCollider.transform.position = new Vector3(-15.25f, -4f, 0f);
        }

        if (Mathf.Abs(currentAspect - eighteenNinths) < aspectRatioTolerance)
        {
            platforms[0].transform.position = new Vector3(-9.3f, -5f, 0f);
            platforms[2].transform.position = new Vector3(9.3f, -5f, 0f);

            platformCollider.transform.position = new Vector3(-15.25f, -4f, 0f);
        }

        if (Mathf.Abs(currentAspect - nineteenNinths) < aspectRatioTolerance)
        {
            platforms[0].transform.position = new Vector3(-9.3f, -5f, 0f);
            platforms[2].transform.position = new Vector3(9.3f, -5f, 0f);

            platformCollider.transform.position = new Vector3(-16.25f, -4f, 0f);
        }

        if (Mathf.Abs(currentAspect - twentyNinths) < aspectRatioTolerance)
        {
            platforms[0].transform.position = new Vector3(-9.3f, -5f, 0f);
            platforms[2].transform.position = new Vector3(9.3f, -5f, 0f);

            platformCollider.transform.position = new Vector3(-16.25f, -4f, 0f);
        }

        if (Mathf.Abs(currentAspect - twentyOneNinths) < aspectRatioTolerance)
        {
            platforms[0].transform.position = new Vector3(-9.3f, -5f, 0f);
            platforms[2].transform.position = new Vector3(9.3f, -5f, 0f);

            platformCollider.transform.position = new Vector3(-16.25f, -4f, 0f);
        }

        if (Mathf.Abs(currentAspect - twentyTwoNinths) < aspectRatioTolerance)
        {
            platforms[0].transform.position = new Vector3(-9.3f, -5f, 0f);
            platforms[2].transform.position = new Vector3(9.3f, -5f, 0f);

            platformCollider.transform.position = new Vector3(-16.25f, -4f, 0f);
        }

        if (Mathf.Abs(currentAspect - twentyThreeNinths) < aspectRatioTolerance)
        {
            platforms[0].transform.position = new Vector3(-9.3f, -5f, 0f);
            platforms[2].transform.position = new Vector3(9.3f, -5f, 0f);

            platformCollider.transform.position = new Vector3(-16.25f, -4f, 0f);
        }
    }
}
