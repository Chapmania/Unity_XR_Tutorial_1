using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MainScript : MonoBehaviour
{

	private GameObject platform;
	private GameObject tracker;
	private GameObject leftSensor;
	private GameObject rightSensor;
	private GameObject leftController;
	private GameObject rightController;

	private bool debugLog = false;

	// Start is called before the first frame update
	void Start()
	{
		platform = GameObject.Find("Platform");
		tracker = GameObject.Find("Tracker");
		leftSensor = GameObject.Find("Left Sensor");
		rightSensor = GameObject.Find("Right Sensor");
		leftController = GameObject.Find("Left Controller");
		rightController = GameObject.Find("Right Controller");
	}

	// Update is called once per frame
	void Update()
	{
		if (debugLog)
			LogHierarchy(platform.transform, 0);
		//LogHierarchy(transform, 0);
	}

	static void LogHierarchy(Transform t, int level)
	{
		String indent = "";
		indent = indent.PadLeft(level * 4, ' ');

		Debug.Log(indent + t.gameObject.name + " LCS: " + t.localPosition + " WCS: " + t.position);
		
		Debug.Log(indent + t.gameObject.name + " LCS: " + t.localPosition + " EulerAngles: " + t.localEulerAngles + " Quaternion: "+ Quaternion.Euler(t.localEulerAngles));
		Debug.Log(indent + t.gameObject.name + " WCS: " + t.position + " EulerAngles: " + t.eulerAngles + " Quaternion: " + Quaternion.Euler(t.eulerAngles));


		for (int i = 0; i < t.childCount; i++)
			LogHierarchy(t.GetChild(i), level + 1);
	}
}
