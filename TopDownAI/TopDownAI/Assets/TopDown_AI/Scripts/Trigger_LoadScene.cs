using UnityEngine;
using System.Collections;

public class Trigger_LoadScene : MonoBehaviour {
	public string sceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider user){
		if (user.tag == "Player") {
			Application.LoadLevel(sceneName);
		}
	}
}
