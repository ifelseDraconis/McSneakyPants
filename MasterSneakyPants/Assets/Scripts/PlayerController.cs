using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : Controller
{
    public Pawn playerPawn;
    public GameManager instance;
    public Transform thisPlayer;

    private float playerMovementSpeed;
    public GameObject myNoise;
    private kickCan crunchCrunch;
    private bool madeNoise;
    // Start is called before the first frame update
    void Start()
    {
        //playerPawn.thisPatsy = GetComponent<GameObject>();
        //playerPawn.thisDamnTF = playerPawn.thisPatsy.GetComponent<Transform>();
        //playerPawn.thisRigid = playerPawn.thisPatsy.GetComponent<Rigidbody2D>();

        playerMovementSpeed = GameManager.instance.playerMovementSpeed;
        myNoise = GameObject.FindWithTag("PlayerNoise");
        crunchCrunch = myNoise.GetComponent<kickCan>();
        madeNoise = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.canMovePlayer)
        {
            if (Input.GetKey("w") | Input.GetKey("up"))
            {
                thisPlayer.localPosition = thisPlayer.localPosition + new Vector3(0, playerMovementSpeed, 0);
                madeNoise = true;
            }
            if (Input.GetKey("a") | Input.GetKey("left"))
            {
                thisPlayer.localPosition = thisPlayer.localPosition - new Vector3(playerMovementSpeed, 0, 0);
                madeNoise = true;
            }
            if (Input.GetKey("d") | Input.GetKey("right"))
            {
                thisPlayer.localPosition = thisPlayer.localPosition + new Vector3(playerMovementSpeed, 0, 0);
                madeNoise = true;
            }
            if (Input.GetKey("s") | Input.GetKey("down"))
            {
                thisPlayer.localPosition = thisPlayer.localPosition - new Vector3(0, playerMovementSpeed, 0);
                madeNoise = true;
            }
        }

        if (madeNoise)
        {
            crunchCrunch.tookAStep();
        }
    }

    public void youGotMe()
    {
        thisPlayer.localPosition = GameManager.instance.spawnLocation;
    }

    public void arrghMyFace()
    {
        GameManager.instance.hitInFace();
        youGotMe();
    }
}
