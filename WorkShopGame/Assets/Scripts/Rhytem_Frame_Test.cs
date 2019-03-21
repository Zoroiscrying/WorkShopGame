using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhytem_Frame_Test : MonoBehaviour
{

	public GameObject prefab;
	private int nums = 0;
	private float x = 0;
	private float y = 0;
	private float z = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		if (Music.IsJustChangedBeat())
//		{
//			Debug.Log("JustChangedBar");
//			Instantiate(prefab, this.transform.position + new Vector3(x,y,z), Quaternion.identity);
//			nums++;
//			x+=0.05f;
//		}

		//Debug.Log(Music.MusicalTimeBar);
	}
}
