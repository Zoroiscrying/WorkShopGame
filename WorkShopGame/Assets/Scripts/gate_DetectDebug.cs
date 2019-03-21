using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate_DetectDebug : MonoBehaviour {

	// Use this for initialization
	public float e_distance = 1.2f;
	public float g_distance = 3.0f;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.DrawLine(this.transform.position - new Vector3(g_distance,0,0),this.transform.position + new Vector3(g_distance,0,0),
			Color.red,Time.deltaTime);
		Debug.DrawLine(this.transform.position - new Vector3(e_distance,2,0),this.transform.position + new Vector3(e_distance,-2,0),
			Color.black,Time.deltaTime);
	}
	private void OnGUI() {
	//	Debug.DrawLine(this.transform.position - new Vector3(g_distance,0,0),this.transform.position + new Vector3(g_distance,0,0),
	//	Color.red,100.0f);
	}

}
