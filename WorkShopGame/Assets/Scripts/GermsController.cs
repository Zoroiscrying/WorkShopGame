using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GermsController : MonoBehaviour {
	// public Germ[] Germs;
	public List<Germ> Germs = new List<Germ> ();
	public Germ[] GermsOneBeat;

	public Sprite GermSpr_R;
	public Sprite GermSpr_G;
	public Sprite GermSpr_Y;
	public Sprite GermSpr_P;
	Sprite[] mySprites;

	public Transform GermsTF;

	//randomYArrayNum is related to randomYArray!
	int randomYArrayNum = 4;
	float[] randomYArray = { 26.5f, 30.5f, 34, 37.5f }; //相机y范围26-38 /4 
	int germMaxNum = 2; //4 line 

	float myTimer = 0;

	void Start () {
		mySprites = new Sprite[4];
		mySprites[0] = GermSpr_R;
		mySprites[1] = GermSpr_G;
		mySprites[2] = GermSpr_Y;
		mySprites[3] = GermSpr_P;

	}
	// void Update () {
	// }　

	//50 times per second
	private void FixedUpdate () {

		myTimer += Time.deltaTime;
		if (myTimer > 5) {
			germMaxNum = 3;
			Debug.Log ("mid");
			//mid
		}
		if (myTimer > 10) {
			//high
			germMaxNum = 4;
			Debug.Log ("high");
		}
		

		for (int i = 0; i < Germs.Count; i++) {
			if (Germs[i] != null) { Germs[i].GermUpdate (); }
		}
		// //FOR TEST
		// if (Input.GetKeyDown (KeyCode.Space)) {
		// 	GeneGermsPerBeat ();
		// 	Debug.Log ("您按下了SPACE");
		// }
		if (Music.IsJustChangedBeat ()) {
			//new some germs in sence when music beat it!
			GeneGermsPerBeat ();
		}

	}　

	private void GeneGermsPerBeat () {
		int numOfGerms = Mathf.FloorToInt (Random.Range (0, germMaxNum));
		int[] randomYArrayUsed = new int[4] { 9, 9, 9, 9 }; //randomYArrayNum
		int[] randomSprNumUsed = new int[4] { 9, 9, 9, 9 }; //numOfGerms
		GermsOneBeat = new Germ[numOfGerms];
		float timePerBeat = (float) Music.MusicTimeUnit * Music.UnitPerBeat;
		float germVelocity = 58.0f / timePerBeat * 0.005f; //gate's position.s /time ,if change!!

		for (int i = 0; i < numOfGerms; i++) {
			int nowRandomNum = GetRandomNum (randomYArrayUsed, randomYArrayNum); //no overlap position!
			int nowRandomSprNum = GetRandomNum (randomSprNumUsed, germMaxNum); //no some color sprite in a line

			randomYArrayUsed[i] = nowRandomNum;
			randomSprNumUsed[i] = nowRandomSprNum;

			int GermNumInList = Germs.Count;

			GermsOneBeat[i] = new Germ (0, randomYArray[nowRandomNum], germVelocity, mySprites[nowRandomSprNum], GermNumInList); //x,y,vx
			Germs.Add (GermsOneBeat[i]);
			GermsOneBeat[i].MyObj.transform.SetParent (GermsTF);
		}
	}
	private int GetRandomNum (int[] arrUsed, int totalNum) {　　　　　　　
		int n = Random.Range (0, totalNum);
		while ((ArrayContains (arrUsed, n))) { //if the num has been used ,then abondon the num ,randomly generate another one
			n = Random.Range (0, totalNum);
		}
		return n;　　
	}
	private bool ArrayContains (int[] array, float value) { //whether array contains value 
		for (int i = 0; i < array.Length; i++) {
			if (array[i] == value) return true;
		}
		return false;
	}
}
public class Germ {
	public Vector2 Pos;
	public Vector2 V; //velocity
	public GameObject MyObj;
	public Germ (float x, float y, float vx, Sprite spr, int num) {
		Pos.x = x;
		Pos.y = y;
		V = new Vector2 (vx, 0);

		MyObj = new GameObject ();
		MyObj.name = spr.name;
		MyObj.AddComponent<SpriteRenderer> ();
		MyObj.AddComponent<BoxCollider2D> ();
		MyObj.GetComponent<BoxCollider2D> ().isTrigger = true;
		MyObj.GetComponent<BoxCollider2D> ().size = new Vector2 (1, 1); //??????不初始化碰撞体，太小？？？？？？
		MyObj.AddComponent<EnterGateController> ();
		MyObj.GetComponent<EnterGateController> ().myNum = num;
		MyObj.transform.localScale = new Vector2 (2, 2);
		MyObj.transform.position = new Vector3 (Pos.x, Pos.y, 10);
		// MyObj.GetComponent<Rigidbody2D> ().isKinematic = true;
		SpriteRenderer mySprRender = MyObj.GetComponent<SpriteRenderer> ();
		mySprRender.sprite = spr;

	}
	public void GermUpdate () { //move germ
		if (Pos.x > 1920)
			return;
		Pos.x += V.x;
		if (MyObj != null) {
			MyObj.transform.position = Pos;
		}
	}

}