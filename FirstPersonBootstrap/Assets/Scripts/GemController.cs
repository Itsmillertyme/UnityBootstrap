using UnityEngine;

public class GemController : MonoBehaviour {

    //**Component References**
    [SerializeField] AudioSource sfxSource;
    [SerializeField] GameManager gameManager;

    //**Variables**
    [SerializeField] float rotationalSpeed = 1f;
    const int GEM_VALUE = 5;


    //**Unity Methods**        
    private void Update() {

        //Spin
        transform.Rotate(0f, rotationalSpeed * Time.deltaTime, 0f);
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
