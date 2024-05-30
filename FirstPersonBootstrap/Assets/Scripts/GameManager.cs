using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //**Component References**
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TimerScript timer;

    //**Variables**
    int score;

    //**Unity Methods** 
    private void Awake() {

        //Initilization
        score = 0;

        //Begin monitoring timer
        StartCoroutine(MonitorTimer());
    }
    //
    private void Update() {
        //Update score text
        scoreText.text = "Score: " + score;
    }

    //**Utility Methods**
    //Increases score by a given amount
    public void IncrementScore(int amount) {
        score += amount;
    }
    //
    //Decreases score by a given amount
    public void DecrementScore(int amount) {
        score -= amount;

        //Wrap
        if (score < 0) score = 0;
    }

    //This is a very hacky way of dealing with this issue but I didn't wish to spend a lot of time on parsing the timer from a float and trying to get a remainder with an int. 
    IEnumerator MonitorTimer() {
        int count = 1;
        while (timer.CurrentTimer() < 5000f) {
            if (timer.CurrentTimer() >= 10 * count) {
                count++;
                DecrementScore(1);
                //yield return new WaitForSeconds(2);
            }
            yield return null;
        }
    }

}
