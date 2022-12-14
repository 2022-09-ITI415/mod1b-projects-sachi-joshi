using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
  [Header("Set in Inspector")]
  // Prefab for instantiating apples
  public GameObject applePrefab;

  // Speed at which the AppleTree moves
  public float speed = 1f;

  // Distance where the AppleTree turns around
  public float leftAndRightEdge = 10f;

  // Chance that the AppleTree will change directions
  public float chanceToChangeDirections = 0.1f;

  // Rate at which Apples will be instantiated
  public float secondsBetweenAppleDrops = 1f;

  void Start() {
    // Dropping apples every second
    Invoke("DropApple", 2f);
  }

  void DropApple() {
    GameObject apple = Instantiate<GameObject>(applePrefab);
    apple.transform.position = transform.position;
    Invoke("DropApple", secondsBetweenAppleDrops);
  }

  void Update() {
    if (Random.value < chanceToChangeDirections) {
     speed *= -1;
     }
    Vector3 pos = transform.position;
    pos.x += speed * Time.deltaTime;
    transform.position = pos;
    // Changing Direction
    if (pos.x < -leftAndRightEdge) {  //a
      speed = Mathf.Abs(speed); // Move right  //b
    }
    else if ( pos.x > leftAndRightEdge )
    { //c
      speed = -Mathf.Abs(speed); // Move left //d
    } else if (Random.value < chanceToChangeDirections )
    {
      speed *= -1; // change direction
    }
  
  }


}



