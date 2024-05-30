using UnityEngine;

public class PlayerReset : MonoBehaviour {
    public Transform spawnPoint;

    /*
     * CODE ADDED: Component reference to AudioSource
     */
    [SerializeField] AudioSource resetSFX;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            resetSFX.Play();
            ResetPlayer(other.gameObject);
        }
        else {
            other.gameObject.SetActive(false);
        }
    }

    public void ResetPlayer(GameObject other) {
        other.transform.position = spawnPoint.position;
    }
}
