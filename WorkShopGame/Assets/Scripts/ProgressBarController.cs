using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour {

	// private bool isInit = false;
	public MyProgressBar MyProgressBarR;
	public MyProgressBar MyProgressBarG;
	public MyProgressBar MyProgressBarY;
	public MyProgressBar MyProgressBarP;
	public Image ProgressBarR;
	public Image ProgressBarG;
	public Image ProgressBarY;
	public Image ProgressBarP;
	public float PercentageR = 0;
	public float PercentageG = 0;
	public float PercentageY = 0;
	public float PercentageP = 0;
	public void Awake () {
		MyProgressBarR = new MyProgressBar (ProgressBarR.transform, ProgressBarR, 0.8f);
		MyProgressBarG = new MyProgressBar (ProgressBarG.transform, ProgressBarG, 0.9f);
		MyProgressBarY = new MyProgressBar (ProgressBarY.transform, ProgressBarY, 0.7f);
		MyProgressBarP = new MyProgressBar (ProgressBarP.transform, ProgressBarP, 1.0f);
	}
	void FixedUpdate () {
		// PercentageR=MyProgressBarR.BarUpdate(PercentageR);
		MyProgressBarR.SetProgressValue (PercentageR);
		MyProgressBarG.SetProgressValue (PercentageG);
		MyProgressBarY.SetProgressValue (PercentageY);
		MyProgressBarP.SetProgressValue (PercentageP);
	}
}
public class MyProgressBar {
	private Image progressBar;
	float percentLimted;
	public MyProgressBar (Transform tf, Image pBar, float limted) {
		percentLimted = limted;
		progressBar = pBar;
		progressBar = tf.GetComponent<Image> ();
		progressBar.type = Image.Type.Filled;
		progressBar.fillMethod = Image.FillMethod.Horizontal;
		progressBar.fillOrigin = 0;
	}
	public void SetProgressValue (float value) {
		if (value >= percentLimted) {
			// Debug.Log ("达到限制啦！");  需要设计的素材，体现达到了限制
			return;
		}
		progressBar.fillAmount = value;
	}
}