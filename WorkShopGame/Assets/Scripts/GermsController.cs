using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GermsController : MonoBehaviour {
	// public Germ[] Germs;
	public List<Germ> Germs = new List<Germ> ();
	public Germ[] GermsOneBeat;

	public Sprite GermSpr_01;
	public Sprite GermSpr_02;
	public Sprite GermSpr_03;
	public Sprite GermSpr_04;
	Sprite[] mySprites;

	public Transform GermsTF;

	//randomYArrayNum is related to randomYArray!
	int randomYArrayNum = 4;
	float[] randomYArray = { 26.5f, 30.5f, 34, 37.5f }; //相机y范围26-38 /4 
	float[] randomYArrayUsed = new float[4]; 
	//
	int germMaxNum = 4; //4 line 
	void Start () {
		mySprites = new Sprite[4];
		mySprites[0] = GermSpr_01;
		mySprites[1] = GermSpr_02;
		mySprites[2] = GermSpr_03;
		mySprites[3] = GermSpr_04;
	}
	void Update () {
		for (int i = 0; i < Germs.Count; i++) {
			if (Germs[i] != null) { Germs[i].GermUpdate (); }
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("您按下了空格键");
		}
		if(Music.IsJustChangedBeat()){		
			//new some germs in sence when music beat it!
			GeneGermsPerBeat ();
		}
	}　　
	private void GeneGermsPerBeat () {
		int numOfGerms = Mathf.FloorToInt (Random.Range (0, germMaxNum));
		GermsOneBeat = new Germ[numOfGerms];
		for (int i = 0; i < numOfGerms; i++) {
			float nowRandomNum = GetRandomNum (randomYArray, randomYArrayUsed);
			randomYArrayUsed[i] = nowRandomNum;
			GermsOneBeat[i] = new Germ (0, nowRandomNum, 1.1f, GetRandomSpr (randomYArray)); //x,y,vx
			Germs.Add (GermsOneBeat[i]);
			GermsOneBeat[i].MyObj.transform.SetParent (GermsTF);

		}
	}
	private float GetRandomNum (float[] arr, float[] arrUsed) {　　　　　　　
		int n = Random.Range (0, randomYArrayNum);
		while (ArrayContains (arrUsed, arr[n])) { //if the position has been used ,then abondon the position ,randomly generate another one
			n = Random.Range (0, randomYArrayNum);
		}
		return arr[n];　　
	}
	private Sprite GetRandomSpr (float[] arr) {　　　　　　　
		int n = Random.Range (0, 4); //num of germs
		return mySprites[n];
	}
	private bool ArrayContains (float[] array, float value) { //whether array contains value 
		for (int i = 0; i < array.Length; i++) {
			if (array[i] == value) return true;
		}
		return false;
	}
}
public class Germ {
	public Vector2 Pos;
	public Vector2 V;//velocity
	public GameObject MyObj;
	public Germ (float x, float y, float vx, Sprite spr) {
		Pos.x = x;
		Pos.y = y;
		V = new Vector2 (vx, 0);

		MyObj = new GameObject ();
		MyObj.name = spr.name;
		MyObj.AddComponent<SpriteRenderer> ();
		MyObj.AddComponent<BoxCollider2D> ();
		MyObj.GetComponent<BoxCollider2D>().isTrigger=true;
		MyObj.AddComponent<EnterGateController>();
		MyObj.AddComponent<Rigidbody2D> ();
		MyObj.GetComponent<Rigidbody2D>().isKinematic=true;
		SpriteRenderer mySprRender = MyObj.GetComponent<SpriteRenderer> ();
		mySprRender.sprite = spr;

	}
	public void GermUpdate () { //move germ
		if (Pos.x > 1920)
			return;
		Pos.x += V.x;
		MyObj.transform.position = Pos;
	}

}