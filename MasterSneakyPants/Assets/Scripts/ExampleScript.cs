using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public GameManager instance;
    public bool hasKey;

    public void clickBait()
    {
        GameManager.instance.letsBegin();
    }
    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
