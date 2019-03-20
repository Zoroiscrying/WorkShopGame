using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGateController : MonoBehaviour {
	 float myDistance =10.0f;
	private string checkLevel(Vector2 a,Vector2 b){
		if(Vector2.Distance(a,b)<=myDistance){
			return "great";
		}
		return "bad";
		
	}
	  void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("whywhy");
		// 碰撞到新增触发器，将新增一套新的物体
		switch (other.name) {
			case "Germ_01":
				Debug.Log ("trigger Germ_01");
				break;

			case "Germ_02":
				Debug.Log ("trigger Germ_02");
				break;

			case "Germ_03":
				Debug.Log ("trigger Germ_03");
				break;

			case "Germ_04":
				Debug.Log ("trigger Germ_04");
				break;
		}
	}	
}