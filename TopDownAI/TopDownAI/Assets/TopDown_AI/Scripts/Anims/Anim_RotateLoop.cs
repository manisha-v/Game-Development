using UnityEngine;
using System.Collections;

public class Anim_RotateLoop : MonoBehaviour {
	public float time=1.0f;
	public Vector3 angles=new Vector3();
	public iTween.EaseType easetype=iTween.EaseType.easeInOutSine;
	void Start () {
		iTween.RotateTo(gameObject,iTween.Hash("rotation",angles,"time",time,"looptype", iTween.LoopType.pingPong,"easetype",easetype));	


	}
	void Update () {
		
	}
}
