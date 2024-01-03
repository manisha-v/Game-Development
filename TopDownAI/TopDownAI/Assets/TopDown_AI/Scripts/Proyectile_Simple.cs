using UnityEngine;
using System.Collections;

public class Proyectile_Simple : MonoBehaviour {
    public enum CollisionTarget {PLAYER,ENEMIES }
    public CollisionTarget collisionTarget;
	public float lifeTime=3.0f;
	public float speed=1.5f;

	bool hitTest=true;
	bool moving;
	void Start () {

		moving = true;
		Destroy (gameObject, lifeTime);
	}


	void Update () {

		if(moving)
		transform.Translate(transform.forward*speed,Space.World);

	

	}
	void OnCollisionEnter(Collision collision){
		if (collisionTarget== CollisionTarget.PLAYER  && collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<PlayerBehavior>().DamagePlayer();
            
        }
        else if (collisionTarget == CollisionTarget.ENEMIES && collision.gameObject.tag == "Enemy") {
			collision.gameObject.GetComponent<NPC_Enemy>().Damage();            
        }
        else if(collision.gameObject.tag == "Finish"){ //This is to detect if the proyectile collides with the world, i used this tag because it is standard in Unity (To prevent asset importing issues)
            DestroyProyectile();
        }
        


    }
	void DestroyProyectile(){
	
		/*hitTest=false;
		gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		gameObject.GetComponent<Collider> ().enabled = false;
		moving = false;*/
		Destroy (gameObject);	
	}

}

