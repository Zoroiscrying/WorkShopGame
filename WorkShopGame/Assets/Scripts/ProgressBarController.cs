using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour {

	// private bool isInit = false;
	public MyProgressBar MyProgressBarR;
	public MyProgressBar MyProgressBarG;
	public MyProgressBar MyProgressBarB;
	public MyProgressBar MyProgressBarP;
	public Image ProgressBarR;
	public Image ProgressBarG;
	public Image ProgressBarY;
	public Image ProgressBarP;
	public float PercentageR = 0;
	public void Awake () {
		MyProgressBarR=new MyProgressBar(ProgressBarR.transform,ProgressBarR);

	}
	void Update () {
		PercentageR=MyProgressBarR.BarUpdate(PercentageR);

	}
}
public class MyProgressBar {
	private Image progressBar;
	public MyProgressBar (Transform tf, Image pBar) {
		progressBar = pBar;
		progressBar = tf.GetComponent<Image> ();
		progressBar.type = Image.Type.Filled;
		progressBar.fillMethod = Image.FillMethod.Horizontal;
		progressBar.fillOrigin = 0;
	}
	public float BarUpdate (float myPercentage) {
		if (myPercentage >= 1.0f) return 1.0f;
		myPercentage += .01f;
		SetProgressValue (myPercentage);
		return myPercentage;
	}
	public void SetProgressValue (float value) {
		progressBar.fillAmount = value;
	}
}