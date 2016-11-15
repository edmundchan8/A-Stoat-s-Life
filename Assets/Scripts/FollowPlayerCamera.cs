using UnityEngine;
using System.Collections;

public class FollowPlayerCamera : MonoBehaviour {

	[Header ("Constant Settings")]
	[SerializeField]
	Vector3 OFFSET;
	Vector3 PLAYER_POSITION;

	[Header ("Assessor")]
	GameObject m_Player;
	Transform m_PlayerBody;
	Vector3 m_PlayerScale;

	[Header ("Other variables")]
	Vector3 m_OffsetHolder;
	[SerializeField]
	int m_OffsetLeftVariable; //this should be 1
	[SerializeField]
	int m_OffsetRightVariable; // this should be -1

	void Start () 
	{
		//find the player gameobject and assign it to m_Player
		m_Player = GameObject.Find ("Player");
		//set the vector3 position of the player to PLAYER_POSITION;
		PLAYER_POSITION = m_Player.transform.position; 
		OFFSET = transform.position - PLAYER_POSITION;
	}

	void Update() 
	{
		//here. we will run code every frame to check and keep a track of the player's body scale
		m_PlayerBody = m_Player.transform.GetChild(0);
		m_PlayerScale = m_PlayerBody.localScale;

		//next, we'll what an if statement to check if the m_PlayerScale.x value is -1 (means player facing left)
		//of is m_PlayerScale.x is 1 (means player facing right)
		//if we also want to move the camera position to be so tha the player is not in the centre of the screen
		if (m_PlayerScale.x > 0) 
		{
			m_OffsetHolder = OFFSET;
			m_OffsetHolder.x = m_OffsetLeftVariable;
			OFFSET = m_OffsetHolder;
		}

		else if (m_PlayerScale.x < 0) 
		{
			m_OffsetHolder = OFFSET;
			m_OffsetHolder.x = m_OffsetRightVariable;
			OFFSET = m_OffsetHolder;
		}
	}

	void LateUpdate () 
	{
		//once all physics movements have occurred
		//set the camera's position to be the player position plus the offset.
		transform.position = m_Player.transform.position + OFFSET;
	}

}
