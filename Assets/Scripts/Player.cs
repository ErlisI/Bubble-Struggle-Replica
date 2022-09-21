using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public static bool GG = false; //a global variable for checking when the game is lost *helpful to change the score*

    //public references
    public float speed = 3f;
    public Rigidbody2D rb;

    private float mov = 0f;

    //getting the coordinates to move horizontally
    void Update() {
        mov = Input.GetAxis("Horizontal") * speed;
    }

    //moving the position of the player horizontally
    void FixedUpdate() {
      rb.MovePosition(rb.position + new Vector2 (mov * Time.fixedDeltaTime, 0f));
    }

    void OnCollisionEnter2D(Collision2D coll) {

      if(coll.collider.tag == "Ball"){
        GG = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
    }
}
