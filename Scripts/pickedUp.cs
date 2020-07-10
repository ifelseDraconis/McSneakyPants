using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickedUp : MonoBehaviour
{
    public GameManager instance;
    public GameObject thisKeyRing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            GameManager.instance.getKey();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            UnityEngine.Debug.Log("I touched the key.");
        }
    }
}
