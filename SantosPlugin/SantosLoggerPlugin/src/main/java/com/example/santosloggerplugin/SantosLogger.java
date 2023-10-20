package com.example.santosloggerplugin;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;

public class SantosLogger
{
    private static Activity unityActivity;
    AlertDialog.Builder builder;

    static final String LOGTAG = "SantosLog";

    static SantosLogger _instance = null;



    public static SantosLogger getInstance()
    {
        if (_instance == null)
        {
            _instance = new SantosLogger();
        }

        return _instance;
    }

    public String getLogtag()
    {
        return LOGTAG;
    }

    public static void setUnityActivity(Activity activity)
    {
        unityActivity = activity;
    }

    public void CreateAlert()
    {
        builder = new AlertDialog.Builder(unityActivity);
        builder.setMessage("Sell your soul?");
        builder.setCancelable(true);
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener()
        {
            @Override
            public void onClick(DialogInterface dialogInterface, int i)
            {
                Log.v(LOGTAG, "Clicked from plugin - Yes");
                dialogInterface.cancel();
            }
        });

        builder.setNegativeButton("No", new DialogInterface.OnClickListener()
        {
            @Override
            public void onClick(DialogInterface dialogInterface, int i)
            {
                Log.v(LOGTAG, "Clicked from plugin - No");
                dialogInterface.cancel();
            }
        });
    }

    public void ShowAlert()
    {
        AlertDialog alert = builder.create();
        builder.show();
    }
}
