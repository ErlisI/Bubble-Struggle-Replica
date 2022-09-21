using UnityEngine;

public class Ball : MonoBehaviour
{

    public static int ballCount = 1; //counting the balls in the game
    public static int score = 0; //the score of the game

    //public references
    public Vector2 startForce;
    public GameObject nextBall;
    public Rigidbody2D rb;
    public string ballColor;

    //adding force to the ball
    void Start() {
      rb.AddForce(startForce, ForceMode2D.Impulse);
    }

    public void splitBall() {

      if(nextBall != null){

        //splits the ball into 2
        GameObject ball01 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
        GameObject ball02 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

        //adds a force to the newly created balls
        ball01.GetComponent<Ball>().startForce = new Vector2 (2f, 4f);
        ball02.GetComponent<Ball>().startForce = new Vector2 (-2f, 4f);

        ballCount += 2; //increasing count
      }

      //reseting the score to 0 when we die
      if(Player.GG){
        score = 0;
        Player.GG = false;
      }

      //adding score based on the color we hit
      switch (ballColor) {
        case "Red": score += 1;
          break;
        case "Yellow": score += 2;
          break;
        case "Blue": score += 4;
          break;
        case "Purple": score += 8;
          break;
        case "White": score += 10;
          break;
      }

      //destroyes the original ball and lowers the ball count
      Destroy(gameObject);
      ballCount--;
    }
}
