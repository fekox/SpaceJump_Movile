using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TimerManager", menuName = "New Timers")]
public class NewTimer : ScriptableObject
{
    public bool startTimer;
    private bool m_startTimer = false;

    private void OnEnable()
    {
        startTimer = m_startTimer;
    }
}