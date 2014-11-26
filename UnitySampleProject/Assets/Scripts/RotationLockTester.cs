/******************************************
 * RotationLockTester.cs
 *
 * Clark Kromenaker
 *
 * Shows how one could use the rotation
 * lock setting to adjust app rotation
 * on the fly.
 *****************************************/
using UnityEngine;
using System.Collections;

public class RotationLockTester : MonoBehaviour 
{
	/***************************************
	 * INSPECTOR VARIABLES/PROPERTIES
	 **************************************/
	 
	/***************************************
	 * UNITY EVENT METHODS
	 **************************************/
	private void Awake()
	{
		InitLandscapeSupport();
	}

	private void OnApplicationPause(bool pause)
	{
		if(!pause)
		{
			InitLandscapeSupport();
		}
	}
	
	/***************************************
	 * PUBLIC METHODS
	 **************************************/
	
	/***************************************
	 * PRIVATE VARIABLES/PROPERTIES
	 **************************************/
	 
	/***************************************
	 * PRIVATE METHODS
	 **************************************/
	private void InitLandscapeSupport()
	{
		bool allowAutorotate = false;

#if UNITY_ANDROID
		// Check for Android lock flag.
		allowAutorotate = AndroidRotationLockUtil.AllowAutorotation();
#endif
		
		Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = allowAutorotate;
		Screen.autorotateToLandscapeLeft = allowAutorotate;
		Screen.autorotateToLandscapeRight = allowAutorotate;
	}
}
