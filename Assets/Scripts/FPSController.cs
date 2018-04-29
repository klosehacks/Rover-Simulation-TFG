using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour {

	float _deltaTime = 0.0f;

	void Update () 
	{
		_deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
	}

	void OnGUI()
	{
		float msec = _deltaTime * 1000f;
		float fps = 1f / _deltaTime;
		string text = string.Format ("{0:0.0} ms ({1:0.} fps)", msec, fps);
		gameObject.GetComponent<Text> ().text = text;	
	}
}