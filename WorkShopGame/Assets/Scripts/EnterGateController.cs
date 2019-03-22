using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGateController : MonoBehaviour {
	public GameObject CanvasObj;
	public GameObject GateObj;
	public GameObject GermsObj;

	public GameObject BoomEffect_Good;
	public GameObject BoomEffect_Excellent;
	
	public int myNum;

	private bool pressedBefore = false;
	// public  Component BarControlCompo;

	public float GateSideRightX = 67.0f; //判断的是否死亡的临界值，右。确保这个值一定要在collider内！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！
	public float GateSideLeftX = 51.0f; //确保这个值一定要在collider内！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！
	void Start () {
		CanvasObj = GameObject.FindGameObjectWithTag ("MyCanvas"); //we have to find gameobj in start(),stop dragging
		GateObj = GameObject.FindGameObjectWithTag ("MyGate"); //we have to find gameobj in start(),stop dragging
		GermsObj = GameObject.FindGameObjectWithTag ("MyGerms");
	}
	void Update () {
		// if (this.gameObject.transform.position.x < GateSideLeftX && (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow))) {
		// 	//惩罚	
		// 	//寻找最近的一个快速冲过去
		// }\
		if (entered) {
			Debug.Log ("this happened");
			if (arrowPressed == true) return; //avoid cheating(press the button rapidly or sth)
			switch (this.gameObject.name) {
				case "Germ_R":
					if (Input.GetKeyDown (KeyCode.UpArrow) ||
						Input.GetKeyDown (KeyCode.RightShift)) {
						arrowPressed = true;
						checkGrade ("R", false);
					} else if (this.gameObject.transform.position.x >= GateSideRightX) { //确保GateSideX这个值一定要在collider内！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！
						arrowPressed = true;
						checkGrade ("R", true);
					}
					break;

				case "Germ_Y":
					if (Input.GetKeyDown (KeyCode.DownArrow) ||
						Input.GetKeyDown (KeyCode.RightShift)) {
						arrowPressed = true;
						checkGrade ("Y", false);
					} else if (this.gameObject.transform.position.x >= GateSideRightX) {
						arrowPressed = true;
						checkGrade ("Y", true);
					}
					break;

				case "Germ_G":
					if (Input.GetKeyDown (KeyCode.LeftArrow) ||
						Input.GetKeyDown (KeyCode.RightShift)) {
						arrowPressed = true;
						checkGrade ("G", false);
					} else if (this.gameObject.transform.position.x >= GateSideRightX) {
						arrowPressed = true;
						checkGrade ("G", true);
					}
					break;

				case "Germ_P":
					if (Input.GetKeyDown (KeyCode.RightArrow) ||
						Input.GetKeyDown (KeyCode.RightShift)) {
						arrowPressed = true;
						checkGrade ("P", false);
					} else if (this.gameObject.transform.position.x >= GateSideRightX) {
						arrowPressed = true;
						checkGrade ("P", true);
					}
					break;
			}
		}
	}
	float myDistanceE = 3.0f;
	float myDistanceG = 5.0f;
	int i = 0;
	private int checkLevel (Vector2 a, Vector2 b) {
		if (Mathf.Abs (a.x - b.x) <= myDistanceG) {
			if (Mathf.Abs (a.x - b.x) <= myDistanceE) {
				return 11;
			} else {
				return 1;
			}
		} else {
			Debug.Log ("this happened");
			pressedBefore = true;
			return 0;
		}
	}

	bool entered = false;
	bool arrowPressed = false;
	void OnTriggerEnter2D (Collider2D other) { //注意触发事件不是每帧更新的！！
		entered = true;
	}
	void OnTriggerExit2D (Collider2D other) {
		entered = false;
	}

	void checkGrade (string myColor, bool notPress) {
		int myGrade;
		if (notPress == true) {
			myGrade = 0;
		} else {
			myGrade = checkLevel (this.gameObject.transform.position, GateObj.transform.position);

		}

		if (myGrade != 0) {
			if (myGrade == 11) {
				PlaySuccess (false);
				Debug.Log ("excellent" + myGrade);
			} else if (myGrade == 1) {
				PlaySuccess (true);
				Debug.Log ("good" + myGrade);
			}
		} else {
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
			Debug.Log ("bad" + myGrade);
			PlayFailed ();
		}
	}

	void PlayFailed () { //没能抵挡细菌入侵，细菌继续向前
		this.gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
		germRePosition ();
		// GermsObj.GetComponent<GermsController> ().Germs.RemoveAt(0);

	}
	void PlaySuccess () {
		this.gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
		Destroy (this.gameObject);
	}
	
	void PlaySuccess (bool isGood) {
		if (isGood)
		{
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
			var obj = Instantiate(BoomEffect_Good, this.transform.position, Quaternion.identity);
			Destroy(obj,1.0f);
			Destroy (this.gameObject);			
		}
		else
		{
			Debug.Log("Excellent Boom");
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
			var obj = Instantiate(BoomEffect_Excellent, this.transform.position, Quaternion.identity);
			Destroy(obj,1.0f);
			Destroy (this.gameObject);	
		}

	}
	
	void germRePosition () {
		if (pressedBefore)
		{
			this.gameObject.transform.position=new Vector2(69.8f,8.8f);
			GermsObj.GetComponent<GermsController>().Germs[myNum].Pos = new Vector2(69.8f,8.8f);
		}
	
		GermsObj.GetComponent<GermsController>().Germs[myNum].V=new Vector2(0,-0.5f);
		
	}
	// private void OnGUI () {
	// 	Debug.DrawLine (this.transform.position, GateObj.transform.position, Color.red);
	// }

}