using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    public float speed = 20f;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    Rigidbody m_Rigidbody;
    Vector3 m_Movement;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        
        winText.enabled = false;

        
    {
        GameObject scoreGo = GameObject.Find("CountText");
        scoreGT = scoreGo.GetComponent<Text>();

        count = int.Parse(scoreGT.text);
        //count += 1;
        scoreGT.text = count.ToString();
    }
    }

    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);

        m_Rigidbody.AddForce(m_Movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1 ;
             scoreGT.text = count.ToString();
            //SetCountText();
        }

        if (other.gameObject.CompareTag("end"))
        {
            winText.enabled = true;
        }

    
    }


    

    void OnCollsionEnter (Collision coll) 
    {
        GameObject collidedWith = coll.gameObject;
       if (collidedWith.tag == "obstacle")
        {
            SceneManager.LoadScene("Main-Prototype 1"); 
        }
        
    }

    //void SetCountText()
    //{
       //countText.text = "Count:" + count.ToString;
   // }
}
    