using UnityEngine;

public class Chain : MonoBehaviour
{

    public static bool isFired; //global variable for the arrow

    public float speed = 1f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        isFired = false;
    }

    //firing the arrow
    void Update()
    {

      if(Input.GetButtonDown("Jump")){
        isFired = true;
      }

      //if we shooting the arrow then it goes all the way up, otherwise it stays close to the player
      if(isFired){

        transform.localScale += Vector3.up * Time.deltaTime * speed;

      }else {

        transform.position = player.position;
        transform.localScale = new Vector3 (1f, 0f, 1f);

      }
    }
}
