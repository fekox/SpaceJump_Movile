using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

public class CreateFile : MonoBehaviour
{
#if UNITY_ANDROID
    private const string packageName = "com.example.santosloggerplugin";

    private const string className = ".SantosLogger";

    AndroidJavaClass unityClass;
    AndroidJavaObject unityActivity;
    AndroidJavaObject pluginInstance;
#endif

    private void Start()
    {
        InitializePlugin(packageName + className);
    }

    void InitializePlugin(string pluginName)
    {
        unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        pluginInstance = new AndroidJavaObject(pluginName);

        if (pluginInstance == null)
        {
            Debug.Log("Plugin Instance Null");
            return;
        }
        pluginInstance.CallStatic("SetUnityActivity", unityActivity);
    }

    public void CreateLogsFile()
    {
        Debug.Log("CreateFile()");

        pluginInstance.Call("SaveLogsToFile");
    }
}
