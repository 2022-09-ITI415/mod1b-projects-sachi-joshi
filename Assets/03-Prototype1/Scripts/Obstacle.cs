using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public GameObject player;
    float maxX = 4.5f;
    bool toRight;
    bool toLeft;
    public float speed;
    void Start()
    {
        toRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3 (speed, 0, 0);
        if (transform.position.x >= maxX) {
            toLeft = true;
            toRight = false;
        }
        if (transform.position.x <= -maxX) {
            toLeft = false;
            toRight = true;
        }
        if (toRight) {
            transform.position += move * Time.deltaTime;
        }
        else if (toLeft) {
            transform.position -= move * Time.deltaTime;
        }
    }


    void OnCollisionEnter (Collision coll) {
        if (coll.gameObject.tag == "player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
