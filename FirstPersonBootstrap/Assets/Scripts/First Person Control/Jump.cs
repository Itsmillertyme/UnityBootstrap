using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Jump : MonoBehaviour {
    public float jumpStrength = 5;
    public KeyCode jumpKey = KeyCode.Space;

    private Rigidbody rb;
    /*
     * CODE CHANGE: Exposed isGrounded to inpector
     * 
     * Exposed for debugging as grounding was not working properly after crouch/reseting
     * 
     * Original Code: private bool isGrounded = true;
     */
    [SerializeField] bool isGrounded = true;

    /*
     * CODE ADDED: Component reference to audio source on player. Not set in Inspector, initialized in Start()
     */
    AudioSource jumpSound;

    void Start() {
        rb = GetComponent<Rigidbody>();
        jumpSound = GetComponent<AudioSource>();
    }

    void Update() {
        /*
         * CODE ADDED: Call for ground check every tick
         */
        GroundCheck();

        if (Input.GetKeyDown(jumpKey) && isGrounded) {
            rb.AddForce(rb.transform.up * jumpStrength, ForceMode.Impulse);
            jumpSound.Play();
        }
    }

    /*
     * CODE REMOVED: Revamped ground checking
     */
    //private void OnCollisionEnter(Collision collision) {
    //    if (collision.gameObject.CompareTag("Ground")) {
    //        isGrounded = true;
    //    }
    //}

    //private void OnCollisionExit(Collision collision) {
    //    if (collision.gameObject.CompareTag("Ground")) {
    //        isGrounded = false;
    //    }
    //}

    /*
     * CODE ADDED: New method for checking player grounding using raycasts
     */
    void GroundCheck() {
        //Set up helpers
        RaycastHit hit;
        float rayLength = 1.05f;

        //Test if Raycast hits a collider
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength)) {
            //Test if collider is not trigger
            if (!hit.collider.isTrigger) {
                //Flag
                isGrounded = true;
                return;
            }

        }
        isGrounded = false;
    }
}
