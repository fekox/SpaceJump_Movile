package com.example.santosloggerplugin;

public interface AlertCallback
{
    public void onPositive(String message);
    public void onNegative(String message);
    public void onRunPlugin(String message);
    public void onError(String message);
}
