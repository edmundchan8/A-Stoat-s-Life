using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    //This script controls player movement
	[Header ("Constant Settings")]
	[SerializeField]
	float PLAYER_SPEED;
    Rigidbody2D m_PlayerRigidbody;
    Transform m_PlayerChildGameObject;
	//jump values
	[SerializeField]
	float JUMP_POWER;
	//bool variables to check if touching ground
	[SerializeField]
	bool TOUCHING_GROUND;
	[SerializeField]
	public bool m_PlayingIsMove;

    void Start()
    {
        m_PlayerRigidbody = GetComponent<Rigidbody2D>();
        m_PlayerChildGameObject = gameObject.transform.GetChild(0);
    }

    void Update()
    {
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
			m_PlayingIsMove = true;
            if (m_PlayerChildGameObject.localScale.x != 1)
            {
                Vector3 m_ScaleHolder;
                float m_XScaleValue = 1f;
                m_ScaleHolder = m_PlayerChildGameObject.localScale;
                m_ScaleHolder.x = m_XScaleValue;
                m_PlayerChildGameObject.localScale = m_ScaleHolder;
            }
            transform.Translate(Vector2.right * PLAYER_SPEED * Time.deltaTime);
        }

		if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
			m_PlayingIsMove = true;
            if (m_PlayerChildGameObject.localScale.x != -1)
            {
                Vector3 m_ScaleHolder;
                float m_XScaleValue = -1f;
                m_ScaleHolder = m_PlayerChildGameObject.localScale;
                m_ScaleHolder.x = m_XScaleValue;
                m_PlayerChildGameObject.localScale = m_ScaleHolder;
            }
            transform.Translate(Vector2.left * PLAYER_SPEED * Time.deltaTime);
        }

		//Player Jumps
		if (Input.GetKeyDown (KeyCode.Space)) {
			m_PlayingIsMove = true;
			//Check player touching ground
			//check player velocity is not greater than -0.1

			if (TOUCHING_GROUND && checkPlayerVelocity ()) {
				print ("Player can jump");
				m_PlayerRigidbody.AddForce (Vector2.up * JUMP_POWER * Time.deltaTime);
				TOUCHING_GROUND = false;
			}
		} else
			m_PlayingIsMove = false;
	}

	public void OnCollisionEnter2D(Collision2D myCol) 
	{
		print (myCol);
		if (myCol.gameObject.GetComponent<Collider2D>()) 
		{
				TOUCHING_GROUND = true;
		} else 	TOUCHING_GROUND = false;
	}

	public bool checkPlayerVelocity ()
	{
		if (m_PlayerRigidbody.velocity.y >= -0.1) 
		{
			return true;
		} 
		else return false;
	}

}
