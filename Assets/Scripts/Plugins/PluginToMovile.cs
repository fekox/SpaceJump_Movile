using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

public class PluginToMovile : MonoBehaviour
{
#if UNITY_ANDROID
    private const string packageName = "com.example.santosloggerplugin";
    private const string className = ".SantosLogger";

    private List<GameObject> logsList = new List<GameObject>();
    private AndroidJavaClass _pluginClass;
    public AndroidJavaObject _pluginInstance { get; private set; }
    private AndroidJavaObject _unityActivity;

    public TextMeshProUGUI plugin;
    public GameObject textPrefab;
    public Transform textParentTransform;

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

    private void SendLogToAndroid(string logsString, string stackTrace, LogType type)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            switch (type)
            {
                case LogType.Error:
                    _pluginInstance.Call("SendLog", 2, logsString);
                    break;

                case LogType.Warning:
                    _pluginInstance.Call("SendLog", 1, logsString);
                    break;

                case LogType.Log:
                    _pluginInstance.Call("SendLog", 0, logsString);
                    break;

                case LogType.Exception:
                    _pluginInstance.Call("SendLog", 3, logsString);
                    break;
            }
        }
    }

    public void ReadAllSaveLogs()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            string logsFile = _pluginInstance.Call<string>("ReadFile");

            Debug.Log("LogFile:" + logsFile);

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
