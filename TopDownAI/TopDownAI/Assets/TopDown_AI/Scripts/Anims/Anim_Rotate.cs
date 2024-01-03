using UnityEngine;
using System.Collections;

public class Anim_Rotate : MonoBehaviour {
	public float rotateLoopTime=1.0f;
	public bool rotateLeft=true;
	public iTween.EaseType easetype=iTween.EaseType.linear;
	public float addValue=360;
	// Use this for initialization

	void OnEnable(){
		DoAction ();
	}
	void DoAction(){
		if(rotateLeft)
			iTween.RotateAdd(gameObject,iTween.Hash("z",addValue,"time",rotateLoopTime,"easetype",easetype,"oncomplete","DoAction"));//,"looptype",iTween.LoopType.loop,
		else
			iTween.RotateAdd(gameObject,iTween.Hash("z",-addValue,"time",rotateLoopTime,"easetype",easetype,"oncomplete","DoAction"));//,"looptype",iTween.LoopType.loop
	}

	void OnDisable () {
		iTween.Stop (gameObject);
	}

}
