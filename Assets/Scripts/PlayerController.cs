using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float horizontalRange = 19.0f;
	public float speed;
    public float gravityModifier;
    private bool onGround = true;
    public float jumpForce;
    public float jumpForceDown;

    public GameObject endGameMenu;
    public GameObject explosion;

    private Rigidbody2D rigidbody;
    private Animator animator;

    private bool isDead = false;

    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    public AudioClip ouchSound;
	[HideInInspector]
    public AudioSource audioSource;
    
    public static int health = 3;

	// Start is called before the first frame update
	void Start() {

		rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        Physics2D.gravity *= gravityModifier;   // If needed to change gravity
    }

    // Update is called once per frame
    void Update() {

	    if (!SpawnManager.isGameOver) {

		    // Movements
		    float modifierAir = onGround ? 1 : 0.8f; // Reduce mobility in air
		    if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -horizontalRange) {
			    transform.Translate(speed * Time.deltaTime * Vector3.left * modifierAir);
		    } else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < horizontalRange) {
			    transform.Translate(speed * Time.deltaTime * Vector3.right * modifierAir);
		    }

		    if (Input.GetKeyDown(KeyCode.UpArrow) && onGround) {
				audioSource.PlayOneShot(jumpSound);
			    rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			    onGround = false;
		    }

			// If in air can go down faster
		    if (Input.GetKey(KeyCode.DownArrow) && !onGround) {
				rigidbody.AddForce(Vector2.down * jumpForceDown, ForceMode2D.Impulse);
		    }

	    } else {

			// Set dead anim
			if (!isDead) {

				RuntimeAnimatorController deadAnimation = Resources.Load<RuntimeAnimatorController>("Animations/Monkey sprite dead_0");

				if (deadAnimation == null)
					Debug.Log("Dead Animation not found");
				else {
					animator.runtimeAnimatorController = deadAnimation;
				}

				isDead = true;
			}

	    }
    }

    public void ActivateExplosion() {
	    Instantiate(explosion, transform.position, explosion.transform.rotation);
    }

	private void OnCollisionEnter2D(Collision2D collision) {
		
		if (collision.gameObject.CompareTag("Ground"))
			onGround = true;
		
		if(collision.gameObject.CompareTag("Banana")) {

			if (health > 0)
				health--;

			Destroy(collision.gameObject);
			audioSource.PlayOneShot(ouchSound);

			if (health == 0) {
				if (!SpawnManager.isGameOver)
					audioSource.PlayOneShot(gameOverSound);
				SpawnManager.isGameOver = true;
				endGameMenu.SetActive(true);

			}

		}

	}


}
