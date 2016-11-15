using UnityEngine;
using System.Collections;

public class PlayerSplashMove : MonoBehaviour {

    //This scripts controls the player only on the splash screen
    public float Speed;

    //time which we destroy the stoat (when splash screen ends)
    public float DestroyTime;

    Rigidbody2D myRigidbody;
	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();
        //When game starts, immediately starts moving the player forward.
        myRigidbody.AddForce(Vector2.right * Speed);
        StartCoroutine("DestroyAfterTime");
	}

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(DestroyTime);
        Destroy(gameObject);

    }
}
