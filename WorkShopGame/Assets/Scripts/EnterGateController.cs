using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGateController : MonoBehaviour {
	public GameObject CanvasObj;
	public GameObject GateObj;
	// public  Component BarControlCompo;
	public float PercentageR;
	public float PercentageG;
	public float PercentageY;
	public float PercentageP;
	void Start () {
		CanvasObj = GameObject.FindGameObjectWithTag ("MyCanvas"); //we have to find gameobj in start(),stop dragging
		GateObj = GameObject.FindGameObjectWithTag ("MyGate"); //we have to find gameobj in start(),stop dragging
	}
	void Update () {
		if (entered) {
			switch (this.gameObject.name) {
				case "Germ_R":
					if (Input.GetKeyDown (KeyCode.UpArrow) ||
						Input.GetKeyDown (KeyCode.RightShift)) {
						checkGrade ("R");
					}
					break;

				case "Germ_Y":
					if (Input.GetKeyDown (KeyCode.DownArrow) ||
						Input.GetKeyDown (KeyCode.RightShift)) {
						checkGrade ("Y");
					}
					break;

				case "Germ_G":
					if (Input.GetKeyDown (KeyCode.LeftArrow) ||
						Input.GetKeyDown (KeyCode.RightShift)) {
						checkGrade ("G");
					}
					break;

				case "Germ_P":
					if (Input.GetKeyDown (KeyCode.RightArrow) ||
						Input.GetKeyDown (KeyCode.RightShift)) {
						checkGrade ("P");
					}
					break;
			}
		}

	}

	float myDistanceE = 5.0f;
	float myDistanceG = 10.0f;
	int i = 0;
	private int checkLevel (Vector2 a, Vector2 b) {
		if (Mathf.Abs (Vector2.Distance (a, b)) <= myDistanceG) {
			if (Mathf.Abs (Vector2.Distance (a, b)) <= myDistanceE) {
				return 11;
			} else {
				return 1;
			}
		}
		return 0;
	}

	bool entered = false;
	void OnTriggerEnter2D (Collider2D other) {
		entered = true;
	}
	void OnTriggerExit2D (Collider2D other) {
		entered = false;
	}

	void checkGrade (string myColor) {
		int myGrade = checkLevel (this.gameObject.transform.position, GateObj.transform.position);
		if (myGrade != 0) {
			germSuccess ();
			if (myGrade == 11) {
				Debug.Log ("excellent" + myGrade);
				switch (myColor) {
					case "R":
						CanvasObj.GetComponent<ProgressBarController> ().PercentageR += 0.1f;
						break;
					case "G":
						CanvasObj.GetComponent<ProgressBarController> ().PercentageG += 0.1f;
						break;
					case "Y":
						CanvasObj.GetComponent<ProgressBarController> ().PercentageY += 0.1f;
						break;
					case "P":
						CanvasObj.GetComponent<ProgressBarController> ().PercentageP += 0.1f;
						break;
					default:
						break;
				}
			} else if (myGrade == 1) {
				Debug.Log ("good" + myGrade);
				switch (myColor) {
					case "R":
						CanvasObj.GetComponent<ProgressBarController> ().PercentageR += 0.05f;
						break;
					case "G":
						CanvasObj.GetComponent<ProgressBarController> ().PercentageG += 0.05f;
						break;
					case "Y":
						CanvasObj.GetComponent<ProgressBarController> ().PercentageY += 0.05f;
						break;
					case "P":
						CanvasObj.GetComponent<ProgressBarController> ().PercentageP += 0.05f;
						break;
					default:
						break;
				}
			}
		} else {
			Debug.Log ("bad" + myGrade);
			germFailed ();
		}
	}
	void germFailed () {
		this.gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
	}
	void germSuccess () {
		this.gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
	}
	// private void OnGUI () {
	// 	Debug.DrawLine (this.transform.position, GateObj.transform.position, Color.red);
	// }

}