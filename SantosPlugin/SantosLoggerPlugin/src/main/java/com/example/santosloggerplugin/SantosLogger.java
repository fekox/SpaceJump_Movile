package com.example.santosloggerplugin;

import android.Manifest;
import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.os.Environment;
import android.util.Log;

import java.io.BufferedWriter;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.List;
import java.io.File;
import java.io.FileWriter;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;
import android.content.pm.PackageManager;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.motion.widget.Debug;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

public class SantosLogger
{
    List<String> logList = new ArrayList<String>();
    private static Activity unityActivity;
    AlertDialog.Builder builder;

    static final String LOGTAG = "SantosLog";

    enum TypeOfLog
    {
        DebugLog,
        WarningLog,
        ErrorLog,

        Exeption
    };

    static SantosLogger _instance = null;

    public static SantosLogger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SantosLogger();
        }

        return _instance;
    }

    public String GetLogtag(AlertCallback alertCallback)
    {
        logList.add("SantosLog Get from plugin");
        Log.v(LOGTAG, "Get from plugin");

        alertCallback.onRunPlugin(LOGTAG);
        return "Plugin name: " + LOGTAG;
    }

    public void AddLogInList(String logText)
    {
        logList.add(logText);
        Log.v(LOGTAG, logText);

        SaveLogsInToFile();
    }

    public void SendLog(int logType, String logText)
    {
        String typeOfLogText = "Empty:";
        TypeOfLog typeOfLog = TypeOfLog.values()[logType];

        switch (typeOfLog)
        {
            case DebugLog:
                Log.v("Log from Unity: ", logText);
                typeOfLogText = "DebugLog";
            break;

            case WarningLog:
                Log.w("Log from Unity: ", logText);
                typeOfLogText = "WarningLog";
            break;

            case ErrorLog:
                Log.e("Log from Unity: ", logText);
                typeOfLogText = "ErrorLog";
            break;

            case Exeption:
                Log.d("Log from Unity: ", logText);
                typeOfLogText = "ErrorLog";
            break;

            default:
                typeOfLogText = "Empty";
            break;
        }

        logList.add(typeOfLogText + logText);
        SaveLogsInToFile();
    }

    public static void SetUnityActivity(Activity activity)
    {
        unityActivity = activity;
    }

    public void CreateAlert(AlertCallback alertCallback)
    {
        builder = new AlertDialog.Builder(unityActivity);
        builder.setMessage("Are you sure you want to delete all saved logs?");
        builder.setCancelable(true);
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener()
        {
            @Override
            public void onClick(DialogInterface dialogInterface, int i)
            {

                logList.add("Clicked from plugin - Yes");
                Log.v(LOGTAG, "Clicked from plugin - Yes");
                alertCallback.onPositive("Clicked Yes");
                DeleteLogsFile();
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

    private void SaveLogsInToFile()
    {
        Context contex = unityActivity.getApplicationContext();
        try
        {
            DeleteLogsFile();
            File logsFile = new File(contex.getExternalFilesDir(null), "Santos_Logs_File.txt");
            FileWriter fileWriter = new FileWriter(logsFile, true);
            for (String log : logList)
            {
                fileWriter.append(log).append("\n");
            }
            Log.v("File_Created", contex.getExternalFilesDir(null).toString());
            fileWriter.close();
        } catch (IOException e)
        {
            Log.e("File_Created", "Error: Failed to create the file");
            Toast.makeText(unityActivity.getApplicationContext(), "Error: Failed to create the file", Toast.LENGTH_SHORT).show();
        }
    }

    private void DeleteLogsFile()
    {
        Context contex = unityActivity.getApplicationContext();
        File logsFile = new File(contex.getExternalFilesDir(null), "Santos_Logs_File.txt");

        if (logsFile.exists())
        {
            if (logsFile.delete())
            {
                Log.v("Delete_Logs_File", "Complete: Delete Santos_Logs_File.txt");
            }

            else
            {
                Log.e("Delete_Logs_File", "Error: Failed to delete Santos_Logs_File.txt");
            }
        }

        else
        {
            Log.e("Delete_Logs_File", "Error: No file created");
        }
    }

    public String ReadFile()
    {
        Context context = unityActivity.getApplicationContext();
        File logsFile = new File(context.getExternalFilesDir(null), "Santos_Logs_File.txt");
        Log.v("Read_File", context.getExternalFilesDir(null).toString());
        byte[] content = new byte[(int)logsFile.length()];

        if (logsFile.exists())
        {
            try
            {
                FileInputStream inputStream = new FileInputStream(logsFile);
                inputStream.read(content);
                return new String(content);
            }

            catch (IOException e)
            {
                Log.e("Read_File", "Error: Cant read the file");
                return "Error: Cant read the file";
            }
        }

        else
        {
            Log.e("Read_File", "Error: File not found");
            return "Error: File not found";
        }
    }
}
