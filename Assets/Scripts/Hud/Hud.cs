using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Hud : MonoBehaviour
{
    [Header("Setup")]
    public int platformCounter = 0;

    [Header("References")]
    public TextMeshProUGUI score;

    private void Start()
    {
        ShowScore();
    }

    private void Update()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        score.text = platformCounter.ToString();
    }
}
