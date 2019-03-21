using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate_DetectDebug : MonoBehaviour {

	// Use this for initialization
	public float e_distance = 5.0f;
	public float g_distance = 10.0f;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(this.transform.position - new Vector3(g_distance,0,0),this.transform.position + new Vector3(g_distance,0,0),
		Color.red,100.0f);
	}
	private void OnGUI() {
		Debug.DrawLine(this.transform.position - new Vector3(g_distance,0,0),this.transform.position + new Vector3(g_distance,0,0),
		Color.red,100.0f);
	}

}
