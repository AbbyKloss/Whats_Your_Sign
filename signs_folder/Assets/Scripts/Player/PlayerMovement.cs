using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private GameObject textbox;
	[SerializeField] private Animator animator;

	private Rigidbody2D m_Rigidbody2D;
	public bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// private void Update() {
	// 	animator.SetFloat("Speed", m_Rigidbody2D.velocity.magnitude);
	// }


	public void Move(float horizMov, float vertiMov) { // significantly simpler than in game 2
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(horizMov * 10f, vertiMov * 10f);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
		animator.SetFloat("Speed", m_Rigidbody2D.velocity.magnitude);   

        // If the input is moving the player right and the player is facing left...
        if (horizMov > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizMov < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
		
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		theScale.x = theScale.x;
		textbox.transform.localScale = theScale;
	}
}
	