using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateFile : MonoBehaviour
{
    [SerializeField] private const string packageName = "com.example.santosloggerplugin";

    [SerializeField] private const string className = ".SantosLogger";

#if UNITY_ANDROID
    AndroidJavaClass unityClass;
    AndroidJavaObject unityActivity;
    AndroidJavaObject pluginInstance;

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
        pluginInstance.CallStatic("setUnityActivity", unityActivity);
    }

    public void createFile()
    {
        Debug.Log("createFile()");

        pluginInstance.Call("SaveLogsToFile");
    }
#endif
}
