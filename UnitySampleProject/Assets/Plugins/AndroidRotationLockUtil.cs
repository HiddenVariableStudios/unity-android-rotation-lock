/******************************************
 * AndroidRotationLockUtil.cs
 *
 * Clark Kromenaker
 *
 * Accessor for the rotation lock setting
 * in Android.
 *****************************************/
using UnityEngine;
using System.Collections;

public class AndroidRotationLockUtil 
{
	/***************************************
	 * PUBLIC METHODS
	 **************************************/
	public static bool AllowAutorotation()
	{
		bool doAutorotation = false;
#if !UNITY_EDITOR
		using(AndroidJavaClass andClass = new AndroidJavaClass("com.unityutils.RotationLockUtil"))
		{
			int allowAutorotation = andClass.CallStatic<int>("GetAutorotateSetting", GetUnityActivity());
			if(allowAutorotation == 0)
			{
				doAutorotation = false;
			}
			else
			{
				doAutorotation = true;
			}
		}
#endif
		return doAutorotation;
	}

	/***************************************
	 * PRIVATE VARIABLES
	 **************************************/
#if UNITY_ANDROID
	private static AndroidJavaClass unity = null; 

	/***************************************
	 * PRIVATE METHODS
	 **************************************/

	private static AndroidJavaObject GetUnityActivity()
	{
		if(unity == null)
		{
			unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		}
		return unity.GetStatic<AndroidJavaObject>("currentActivity");
	}
#endif
}
