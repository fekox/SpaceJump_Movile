package com.example.santosloggerplugin;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Environment;
import android.util.Log;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class SantosLogger
{
    List<String> logList = new ArrayList<String>();
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

    public String getLogtag(AlertCallback alertCallback)
    {
        logList.add("SantosLog Get from plugin");
        Log.v(LOGTAG, "Get from plugin");

        alertCallback.onRunPlugin(LOGTAG);
        return LOGTAG;
    }

    public static void setUnityActivity(Activity activity)
    {
        unityActivity = activity;
    }

    public void CreateAlert(AlertCallback alertCallback)
    {
        builder = new AlertDialog.Builder(unityActivity);
        builder.setMessage("Sell your soul?");
        builder.setCancelable(true);
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener()
        {
            @Override
            public void onClick(DialogInterface dialogInterface, int i)
            {
                logList.add("Clicked from plugin - Yes");
                Log.v(LOGTAG, "Clicked from plugin - Yes");
                alertCallback.onPositive("Clicked Yes");
                dialogInterface.cancel();
            }
        });

        builder.setNegativeButton("No", new DialogInterface.OnClickListener()
        {
            @Override
            public void onClick(DialogInterface dialogInterface, int i)
            {
                logList.add("Clicked from plugin - No");
                Log.v(LOGTAG, "Clicked from plugin - No");
                alertCallback.onNegative("Clicked No");
                dialogInterface.cancel();
            }
        });
    }

    public void ShowAlert()
    {
        AlertDialog alert = builder.create();
        builder.show();
    }

    private void SaveLogsToFile()
    {
        File logFile = new File(Environment.getExternalStorageDirectory(), "Logs_File.txt");

        try
        {
            BufferedWriter writer = new BufferedWriter(new FileWriter(logFile, true));

            for (String log : logList)
            {
                writer.write(log);
                writer.newLine();
            }

            writer.close();

        } catch (IOException e)
        {
            e.printStackTrace();
        }
    }
}
