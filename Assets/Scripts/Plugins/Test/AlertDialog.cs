using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class AlertDialog : MonoBehaviour
{
#if UNITY_ANDROID

    private const string packageName = "com.example.santosloggerplugin";

    private const string className = ".SantosLogger";

    AndroidJavaClass unityClass;
    AndroidJavaObject unityActivity;
    AndroidJavaObject pluginInstance;
#endif
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
        pluginInstance.CallStatic("SetUnityActivity", unityActivity);
    }
    void CreateAlert()
    {
        Debug.Log("CreateAlert()");

        pluginInstance.Call("CreateAlert", new AndroidPluginCallback());
    }

    public void ShowAlert()
    {
        Debug.Log("ShowAlert()");

        pluginInstance.Call("ShowAlert");
    }
}

class AndroidPluginCallback : AndroidJavaProxy 
{
    public AndroidPluginCallback() : base("com.example.santosloggerplugin.AlertCallback") { }

    public void onPositive(string message) 
    {
        Debug.Log("Clicked from Unity - " + message);
    }

    public void onNegative(string message) 
    {
        Debug.Log("Clicked from Unity - " + message);
    }

    public void onRunPlugin(string message) 
    {
        Debug.Log("Get from Unity - " + message);
    }
}
