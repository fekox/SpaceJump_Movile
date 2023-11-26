using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

public class PluginToMovile : MonoBehaviour
{
#if UNITY_ANDROID
    private const string packageName = "com.example.santosloggerplugin";
    private const string className = ".SantosLogger";
    private AndroidJavaClass _pluginClass;
    public AndroidJavaObject _pluginInstance { get; private set; }
    private AndroidJavaObject _unityActivity;

    private const string permission = "android.permission.WRITE_EXTERNAL_STORAGE";
#endif

    public static PluginToMovile Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _pluginInstance = new AndroidJavaObject(packageName + className);
            _pluginClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _unityActivity = _pluginClass.GetStatic<AndroidJavaObject>("currentActivity");
            _pluginInstance.CallStatic("SetUnityActivity", _unityActivity);

            Application.logMessageReceived += SendLogToAndroid;
            if (Permission.HasUserAuthorizedPermission(permission))
            {
                Debug.Log("Permission is already granted.");
            }
            else
            {
                Permission.RequestUserPermission(permission);
            }

            _pluginInstance.Call("CreateAlert", new AndroidPluginCallback());
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
                case LogType.Assert:
                    _pluginInstance.Call("SendPerTypeOfLog", logsString);
                    break;
                case LogType.Warning:
                    _pluginInstance.Call("SendPerTypeOfLog", logsString, 1);
                    break;
                case LogType.Log:
                    _pluginInstance.Call("SendPerTypeOfLog", logsString, 0);
                    break;
                case LogType.Exception:
                    _pluginInstance.Call("SendPerTypeOfLog", logsString, 3);
                    break;
            }
        }
    }

    private void OnDestroy()
    {
        Application.logMessageReceived -= SendLogToAndroid;
    }
}
