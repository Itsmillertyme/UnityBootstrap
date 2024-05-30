using UnityEngine;

public class GemController : MonoBehaviour {

    //**Component References**
    [SerializeField] AudioSource sfxSource;
    [SerializeField] GameManager gameManager;

    //**Variables**
    [SerializeField] float rotationalSpeed = 1f;
    [SerializeField] float bobRange = .4f;
    [SerializeField] float bobSpeed = 0.002f;
    bool goingUp = true;
    float newY;
    float initY;
    const int GEM_VALUE = 5;


    //**Unity Methods**    
    private void Awake() {
        //Initilization
        initY = transform.position.y;

        //set random initial position
        //float offset = Random.Range(-(bobRange / 2), bobRange / 2);
        //transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);

    }
    //
    private void Update() {

        //Spin
        transform.Rotate(0f, rotationalSpeed * Time.deltaTime, 0f);

        ////Bob
        ////Test if going up
        //if (goingUp) {
        //    //Set new Y positions
        //    newY = transform.position.y + bobSpeed;
        //    //Wrap
        //    if (newY >= initY + (bobRange / 2)) {
        //        newY = initY + (bobRange / 2);
        //        //Flag
        //        goingUp = !goingUp;
        //    }
        //}
        //else {
        //    //Set new Y positions
        //    newY = transform.position.y - bobSpeed;
        //    //Wrap
        //    if (newY <= initY - (bobRange / 2)) {
        //        newY = initY - (bobRange / 2);
        //        //Flag
        //        goingUp = !goingUp;
        //    }
        //}
        ////Update position with new vector
        //transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    //
    private void OnTriggerEnter(Collider other) {
        //Test for player collision
        if (other.gameObject.tag == "Player") {
            //play pickup sound
            sfxSource.Play();

            //increase score
            gameManager.IncrementScore(GEM_VALUE);

            //Hide the item
            transform.localScale = Vector3.zero;
            transform.position = new Vector3(0, 100, 0);

            //delete item after sound clip
            Destroy(this.gameObject, sfxSource.clip.length);
        }
    }

}
