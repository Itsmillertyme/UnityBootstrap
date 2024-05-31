using UnityEngine;

public class PlatformTriggerScript : MonoBehaviour {
    private bool isPlayerInsideZone = false;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayerInsideZone = true;

            /*
             * CODE ADDED: Added code to trigger if landing on end platform and to play sound
             */
            //Test if at end platform
            if (gameObject.name.CompareTo("End Platform") == 0) {
                //Play sounds
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayerInsideZone = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayerInsideZone = false;
        }
    }

    public bool PlayerInsideZone() {
        return isPlayerInsideZone;
    }
}
