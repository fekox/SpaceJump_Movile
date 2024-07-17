using System;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Diagnostics;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TextPlugin : MonoBehaviour
{
    private const string packageName = "com.example.santosloggerplugin";
    private const string className = ".SantosLogger";
    private List<GameObject> logsList = new List<GameObject>();
    public TextMeshProUGUI plugin;
    public GameObject textPrefab;
    public Transform textParentTransform;

#if UNITY_ANDROID
    private AndroidJavaClass _pluginClass;
    private AndroidJavaObject _pluginInstance;
#endif

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _pluginClass = new AndroidJavaClass(packageName + className);
            _pluginInstance = _pluginClass.CallStatic<AndroidJavaObject>("GetInstance");

            RunPlugin();
        }
    }

    public void RunPlugin()
    {
        Debug.Log("RunPlugin()");

        if (Application.platform == RuntimePlatform.Android)
        {
            plugin.text = _pluginInstance.Call<string>("GetLogtag", new AndroidPluginCallback());

            Application.logMessageReceived += SendLogToAndroid;
        }
    }

    public void ReadAllSaveLogs()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            string logsFile = _pluginInstance.Call<string>("ReadFile");
            string[] fileLine = logsFile.Split(new[] { "\n", "\r\n" }, System.StringSplitOptions.None);

            if (logsList.Capacity > 0)
            {
                foreach (GameObject logs in logsList)
                {
                    Destroy(logs);
                }
            }

            logsList.Clear();

            foreach (string logLines in fileLine)
            {
                GameObject text = Instantiate(textPrefab, textParentTransform);
                TextMeshProUGUI textUGUI = text.GetComponent<TextMeshProUGUI>();
                textUGUI.text = logLines;
                logsList.Add(text);
            }
        }
    }

    private void SendLogToAndroid(string logString, string stackTrace, LogType type)
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            switch (type)
            {
                case LogType.Error:
                    _pluginInstance.Call("SendLog", 2, logString);
                    break;

                case LogType.Warning:
                    _pluginInstance.Call("SendLog", 1, logString);
                    break;

                case LogType.Log:
                    _pluginInstance.Call("SendLog", 0, logString);
                    break;

                case LogType.Exception:
                    _pluginInstance.Call("SendLog", 3, logString);
                    break;
            }
        }
    }

    public void TestLog()
    {
        Debug.Log("UnityLog: TestLog");
    }

    public void DeleteAllLogs()
    {
        Debug.Log("ShowAlert()");

        if (Application.platform == RuntimePlatform.Android)
        {
            _pluginInstance.Call("ShowAlert");
        }
    }

    private void OnDestroy()
    {
        Application.logMessageReceived -= SendLogToAndroid;
    }
}
