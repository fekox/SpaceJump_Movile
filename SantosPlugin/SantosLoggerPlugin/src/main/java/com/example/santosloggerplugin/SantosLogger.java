package com.example.santosloggerplugin;

public class SantosLogger
{
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
}
