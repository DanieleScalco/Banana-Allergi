using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float horizontalRange;
	public float speed;
    public float gravityModifier;
    private bool onGround = true;
    public float jumpForce;
    public float jumpForceDown;
    private float modifierAir;

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
		    modifierAir = onGround ? 1 : 0.8f; // Reduce mobility in air
		    if (Input.GetKey(KeyCode.LeftArrow)) {
			    MoveLeft();
		    } else if (Input.GetKey(KeyCode.RightArrow)) {
				MoveRight();
		    }

			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				Jump();
			}

			// If in air can go down faster
		    if (Input.GetKey(KeyCode.DownArrow)) {
			    ForceDown();
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

	public void MoveLeft() {
		if (transform.position.x > -horizontalRange)
			transform.Translate(modifierAir * speed * Time.deltaTime * Vector3.left);
	}

	public void MoveRight() {
		if (transform.position.x < horizontalRange)
			transform.Translate(modifierAir * speed * Time.deltaTime * Vector3.right);
	}

	public void Jump() {
		if (onGround) {
			audioSource.PlayOneShot(jumpSound);
			rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			onGround = false;
		}
	}

	public void ForceDown() {
		if (!onGround)
			rigidbody.AddForce(Vector2.down * jumpForceDown, ForceMode2D.Impulse);
	}

}
