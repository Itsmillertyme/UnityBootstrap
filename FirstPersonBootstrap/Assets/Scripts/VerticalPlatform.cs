using System.Collections;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour {

    //**Variables**
    [SerializeField] float heightChange = 10f;
    [SerializeField] float platformSpeed = .01f;
    [SerializeField] int platformPauseTime = 3;
    float initialY;
    bool isAtTop;
    Coroutine platformMovingUp;
    Coroutine platformMovingDown;

    //**Unity Methods**   
    private void Awake() {

        //Initialize
        initialY = transform.position.y;
        isAtTop = false;
    }
    //
    private void Update() {

        //Test if Coroutine is running
        if (platformMovingUp == null & platformMovingDown == null) {
            //Test platform location
            if (isAtTop) {
                //Send down
                platformMovingDown = StartCoroutine(GoToBottom());
            }
            else {
                //Send up
                platformMovingUp = StartCoroutine(GoToTop());
            }
        }
    }

    //**Coroutines**
    //Sends the platform to the top
    IEnumerator GoToTop() {

        //Loop until platform at top
        while (transform.position.y < initialY + heightChange) {
            //Raise platform
            transform.position = new Vector3(transform.position.x, transform.position.y + platformSpeed, transform.position.z);

            yield return new WaitForFixedUpdate();
        }

        //Clamp
        transform.position = new Vector3(transform.position.x, initialY + heightChange, transform.position.z);

        //Flag
        isAtTop = true;

        //Pause at top
        yield return new WaitForSeconds(platformPauseTime);

        //Clear coroutine object
        platformMovingUp = null;
    }
    //
    //Sends the platform to the tbottom
    IEnumerator GoToBottom() {

        //Loop until platform at bottom
        while (transform.position.y > initialY) {
            //Raise platform
            transform.position = new Vector3(transform.position.x, transform.position.y - platformSpeed, transform.position.z);

            yield return new WaitForFixedUpdate();
        }

        //Clamp
        transform.position = new Vector3(transform.position.x, initialY, transform.position.z);

        //Flag
        isAtTop = false;

        //Pause at bottom
        yield return new WaitForSeconds(platformPauseTime);

        //Clear coroutine object
        platformMovingDown = null;
    }
}
