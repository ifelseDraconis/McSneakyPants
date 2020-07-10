using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public GameObject thisPatsy;
    public Transform thisDamnTF;
    public Rigidbody2D thisRigid;

    // Start is called before the first frame update
    void Start()
    {
        thisRigid = thisPatsy.GetComponent<Rigidbody2D>();
        thisDamnTF = thisPatsy.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
