using UnityEngine;

public class SlowPlatform : MonoBehaviour {
    //**Variables**
    GameObject player;
    float playerWalkSpeed;
    float playerRunSpeed;
    bool isPlayerInZone;

    //**Unity Methods**   
    private void Awake() {

        //Initialize
        player = GameObject.FindGameObjectWithTag("Player");
        playerWalkSpeed = player.GetComponent<Move>().walkSpeed;
        playerRunSpeed = player.GetComponent<Move>().runSpeed;
        isPlayerInZone = false;

    }
    //
    private void Update() {

        //Test if player is on platform
        if (isPlayerInZone && player.GetComponent<Jump>().isGrounded) {
            //Set player speeds
            player.GetComponent<Move>().walkSpeed = 3;
            player.GetComponent<Move>().runSpeed = 3;
        }
        else {
            //Reset player speeds
            player.GetComponent<Move>().walkSpeed = playerWalkSpeed;
            player.GetComponent<Move>().runSpeed = playerRunSpeed;
        }
    }
    //
    private void OnTriggerEnter(Collider other) {
        //Test if triggering object is player
        if (other.gameObject.CompareTag("Player")) {
            //Flag
            isPlayerInZone = true;
        }

    }
    //
    private void OnTriggerExit(Collider other) {
        //Test if triggering object is player
        if (other.gameObject.CompareTag("Player")) {
            //Flag
            isPlayerInZone = false;
        }

    }
}
