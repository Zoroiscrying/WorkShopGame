using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class instruction : MonoBehaviour
{
	public Scene_Manage _sceneManage;
	
	// Use this for initialization
	void Start () {
//		Invoke("Restart",3.0f);
//		Destroy(this.gameObject,3.0f);
//		_sceneManage.Pause();
//		this.gameObject.SetActive(this.gameObject);
		
	}

	void Restart()
	{
		_sceneManage.Resume();
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
