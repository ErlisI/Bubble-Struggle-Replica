using UnityEngine;
using UnityEngine.UI;

public class ChainCollision : MonoBehaviour
{

    //public references to the texts
    public Text currScore;
    public Text highScore0;

    //seeting the highscore to 0 at first
    void Start() {
      highScore0.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void OnTriggerEnter2D(Collider2D coll) {

      Chain.isFired = false; //disabling the arrow so it goes away from the screen

      //when detecting collision with the "Ball" we split the ball to two and also update the score
      if(coll.tag == "Ball"){
        coll.GetComponent<Ball>().splitBall();
        updateScore();
      }
    }

    //updating the score
    public void updateScore() {

      currScore.text = Ball.score.ToString();

      //setting a high score
      if(Ball.score > PlayerPrefs.GetInt("HighScore", 0)){
        PlayerPrefs.SetInt("HighScore", Ball.score);
        highScore0.text = Ball.score.ToString();
      }
    }
}
