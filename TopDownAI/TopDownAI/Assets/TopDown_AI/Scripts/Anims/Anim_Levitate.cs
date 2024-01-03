using UnityEngine;
using System.Collections;

public class Anim_Levitate : MonoBehaviour {
	public Vector2 time;
	public Vector2 direction;
	public iTween.EaseType easetype=iTween.EaseType.easeInOutSine;
	public bool isLocal=false;

	// Use this for initialization
	void Start () {
		Vector3 targetPosition=transform.position;
		targetPosition.x+=direction.x;
		targetPosition.y+=direction.y;
		//iTween.MoveTo(gameObject,iTween.Hash("x",targetPosition.x,"time",time.x,"looptype", iTween.LoopType.pingPong,"easetype",easetype,"islocal",isLocal));
		iTween.MoveTo(gameObject,iTween.Hash("x",targetPosition.y,"time",time.y,"looptype", iTween.LoopType.pingPong,"easetype",easetype,"islocal",isLocal));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
