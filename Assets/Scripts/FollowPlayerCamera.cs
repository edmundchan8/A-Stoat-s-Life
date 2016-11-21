using UnityEngine;
using System.Collections;

public class FollowPlayerCamera : MonoBehaviour {

	[Header ("Constant Settings")]
	[SerializeField]
	Vector2 VELOCITY;
	[SerializeField]
	float SMOOTH_TIME_X;
	[SerializeField]
	float SMOOTH_TIME_Y;
	[SerializeField]
	GameObject PLAYER;

	[Header ("Other variables")]
	[SerializeField]
	float mPosX;
	[SerializeField]
	float mPosY;


	void Start () 
	{
		PLAYER = GameObject.Find ("Player");
	}

	void FixedUpdate() 
	{
		mPosX = Mathf.SmoothDamp (transform.position.x, PLAYER.transform.position.x, ref VELOCITY.x, SMOOTH_TIME_X);
		mPosY = Mathf.SmoothDamp (transform.position.y, PLAYER.transform.position.y, ref VELOCITY.y, SMOOTH_TIME_Y);
	}

	void LateUpdate () 
	{
		transform.position = new Vector3 (mPosX, mPosY, transform.position.z);
	}

}
