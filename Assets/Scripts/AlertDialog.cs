using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AlertDialog : MonoBehaviour
{
    private const string packageName = "com.example.santosloggerplugin";

    private const string className = ".SantosLogger";

#if UNITY_ANDROID

    AndroidJavaClass unityClass;
    AndroidJavaObject unityActivity;
    AndroidJavaObject pluginInstance;

    void Start()
    {
        InitializePlugin(packageName + className);
        CreateAlert();
    }

    void InitializePlugin(string pluginName) 
    {
        unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        pluginInstance = new AndroidJavaObject(pluginName);

        if(pluginInstance == null) 
        {
            Debug.Log("Plugin Instance Null");
            return;
        }
        pluginInstance.CallStatic("setUnityActivity", unityActivity);
    }
    void CreateAlert()
    {
        Debug.Log("CreateAlert()");

        pluginInstance.Call("CreateAlert");
    }

    public void ShowAlert()
    {
        Debug.Log("ShowAlert()");

        pluginInstance.Call("ShowAlert");
    }
#endif
}
