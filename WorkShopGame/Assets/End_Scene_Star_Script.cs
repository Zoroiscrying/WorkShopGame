using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Scene_Star_Script : MonoBehaviour
{

	private GameObject _starGameObject;
	private GermsController _progressBarController;
	
	// Use this for initialization
	void Start ()
	{
		_starGameObject = GameObject.Find("Germs");
		if (_starGameObject != null)
		{
			_progressBarController = _starGameObject.GetComponent<GermsController>();
		}
	}

	void EndSceneCollect(GermsController bar)
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
