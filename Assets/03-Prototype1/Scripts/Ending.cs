using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Text winText;
    
    void OnCollsionEnter (Collision coll) 
    {
        GameObject collidedWith = coll.gameObject;
       if (collidedWith.tag == "player")
        {
           gameObject.SetActive(false);
           //WinText.gameObject.SetActive(true);
        }
    }
}
