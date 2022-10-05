using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public Text countText;
    public Text winText;

    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    int m_Count;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Count = 0;
        setCountText();
        winText.text = "";
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
            m_Count++;
            setCountText();
        }
    }

    void OnCollisionEnter (Collision coll) {
        if (coll.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + m_Count.ToString();
        if (m_Count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}