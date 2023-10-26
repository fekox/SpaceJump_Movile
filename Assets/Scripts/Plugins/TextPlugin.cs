using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextPlugin : MonoBehaviour
{
    [SerializeField] private const string packageName = "com.example.santosloggerplugin";
    
    [SerializeField] private const string className = ".SantosLogger";

#if UNITY_ANDROID
    private AndroidJavaClass _pluginClass;
    private AndroidJavaObject _pluginInstance;

    public TextMeshProUGUI plugin;

    void Start()
    {
        if(Application.platform == RuntimePlatform.Android) 
        {
            _pluginClass = new AndroidJavaClass(packageName + className);
            _pluginInstance = _pluginClass.CallStatic<AndroidJavaObject>("getInstance");
        }
    }

    public void RunPlugin()
    {
        Debug.Log("RunPlugin()");

        if (Application.platform == RuntimePlatform.Android)
        {
            plugin.text = _pluginInstance.Call<string>("getLogtag", new AndroidPluginCallback());
        }
    }
#endif
}
