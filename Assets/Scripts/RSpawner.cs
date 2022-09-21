using UnityEngine;

public class RSpawner : MonoBehaviour
{

    public GameObject B05Spawner;

    void Start() {
      spawnBall(); //spawning the biggest ball at a random place
    }

    void Update() {

      if(Ball.ballCount == 0){
        for(int i = 0; i < Random.Range(1, 4); i++){
          spawnBall();
          Ball.ballCount++;
        }
      }

    }

    //spawning the big ball at random places
    void spawnBall() {
      Vector2 pos = new Vector2 (Random.Range (-5f, 5f), Random.Range (0f, 3f));
      transform.position = pos;
      Instantiate(B05Spawner, transform.position, transform.rotation);
    }
}
