package com.unityutils;

import android.app.Activity;
import android.provider.Settings;
import android.util.Log;

public class RotationLockUtil
{
	public static int GetAutorotateSetting(Activity activity)
	{
		int setting = 0;
		try
		{
			setting = Settings.System.getInt(activity.getContentResolver(), Settings.System.ACCELEROMETER_ROTATION);
		}
		catch(Exception e)
		{
			Log.i("RotationLockUtil", "Couldn't retrieve auto rotation setting: " + e.getMessage());
		}
		return setting;
	}
}
