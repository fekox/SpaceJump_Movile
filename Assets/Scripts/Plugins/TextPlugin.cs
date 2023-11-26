using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

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
        if(Application.platform == RuntimePlatform.Android) 
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
        }
    }

    private void SendLogToAndroid(string logsString, string stackTrace, LogType type)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            switch (type)
            {
                case LogType.Error:
                    _pluginInstance.Call("SendPerTypeOfLog", logsString, 2);
                    break;
                case LogType.Warning:
                    _pluginInstance.Call("SendPerTypeOfLog", logsString, 1);
                    break;
                case LogType.Log:
                    _pluginInstance.Call("SendPerTypeOfLog", logsString, 0);
                    break;
            }
        }
    }

    public void ReadAllSaveLogs() 
    {
        string logsFile = _pluginInstance.Call<string>("ReadFile");
        string[] fileLine = logsFile.Split(new [] {"\n", "\r\n"}, System.StringSplitOptions.None);

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
