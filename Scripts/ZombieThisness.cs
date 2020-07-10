using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;

public class ZombieThisness : AIController
{
    [SerializeField]
    public Pawn thisZombie;

    public GameManager instance;

    private float fieldOfView;
    private float maxSightDistance;
    public GameObject thatPlayerPrick;
    public Transform thatPricksLocation;
    public GameObject theNextWaypoint;
    public Transform nextWaypointLocation;

    private enum zombieState {patrol = 20, attack, peddleback, heardPlayer};
    private enum movingIn { down, up, left, right};

    private zombieState currentState;
    private movingIn directionMoving;
    private bool canSeePlayer;
    private float movementSpeed;

    private float xDiff, yDiff;

    // Start is called before the first frame update
    void Start()
    {
        // loads up the game object reference for the player, so that the zombie can see and reference
        // the player's game object
        if (thatPlayerPrick == null)
        {
            thatPlayerPrick = GameObject.FindWithTag("Player");
        }
        thatPricksLocation = thatPlayerPrick.GetComponent<Transform>();
        currentState = zombieState.patrol;
        fieldOfView = GameManager.instance.fieldOfView;
        maxSightDistance = GameManager.instance.maxSightDistance;
        movementSpeed = GameManager.instance.playerMovementSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        // reloads the player game object at the start of each update loop if necessary, to prevent null reference error
        if (thatPlayerPrick == null | thatPricksLocation == null)
        {
            thatPlayerPrick = GameObject.FindWithTag("Player");
            thatPricksLocation = thatPlayerPrick.GetComponent<Transform>();
        }

        // Do the current state assignment
        switch(currentState)
        {
            case zombieState.patrol:
                moveToNext();
                break;

            case zombieState.attack:
                moveToPlayer();
                break;

            case zombieState.peddleback:
                moveToPreviousWaypoint();
                break;

            case zombieState.heardPlayer:
                scootTowardsPlayer();
                break;

        }

        if (canSeePlayer)
        {
            currentState = zombieState.attack;
        }
        
    }

    // moves to the next way point on the waypoint set
    void moveToNext()
    {        
            xDiff = nextWaypointLocation.localPosition.x - GetComponent<Transform>().localPosition.x;        
            yDiff = nextWaypointLocation.localPosition.y - GetComponent<Transform>().localPosition.y;
       
        // determines which is the larger difference in value
        if (xDiff >= yDiff | -xDiff <= -yDiff)
        {
            if (xDiff <= 0)
            {
                moveLeft();
            }
            else
            {
                moveRight();
            }
        }
        else
        {
            if (yDiff <= 0)
            {
                moveDown();
            }
            else
            {
                moveUp();
            }
        }

        // checking for player
        canSeePlayer = lookingWhereYourGoing();
    }

    // moves towards the player in one direction or the other
    void moveToPlayer()
    {
        xDiff = thatPricksLocation.localPosition.x - GetComponent<Transform>().localPosition.x;
        yDiff = thatPricksLocation.localPosition.y - GetComponent<Transform>().localPosition.y;

        // determines which is the larger difference in value
        if (xDiff >= yDiff | -xDiff <= -yDiff)
        {
            if (xDiff <= 0)
            {
                moveLeft();
            }
            else
            {
                moveRight();
            }
        }
        else
        {
            if (yDiff <= 0)
            {
                moveDown();
            }
            else
            {
                moveUp();
            }
        }
        // checking for player
        canSeePlayer = lookingWhereYourGoing();

    }

    // moves back towards the previous waypoint
    void moveToPreviousWaypoint()
    {
        // taking a last look for the player
        canSeePlayer = lookingWhereYourGoing();

        xDiff = nextWaypointLocation.localPosition.x - GetComponent<Transform>().localPosition.x;
        yDiff = nextWaypointLocation.localPosition.y - GetComponent<Transform>().localPosition.y;

        // determines which is the larger difference in value
        if (xDiff >= yDiff | -xDiff <= -yDiff)
        {
            if (xDiff <= 0)
            {
                moveLeft();
            }
            else
            {
                moveRight();
            }
        }
        else
        {
            if (yDiff <= 0)
            {
                moveDown();
            }
            else
            {
                moveUp();
            }
        }
        
        // lost sight of and can't hear player, move back towards last patrol point
    }

    // moves towards the player when it hears the player
    void scootTowardsPlayer()
    {
        xDiff = thatPricksLocation.localPosition.x - GetComponent<Transform>().localPosition.x;
        yDiff = thatPricksLocation.localPosition.y - GetComponent<Transform>().localPosition.y;

        // determines which is the larger difference in value
        if (xDiff <= yDiff | -xDiff >= -yDiff)
        {
            if (yDiff <= 0)
            {
                moveDown();
            }
            else
            {
                moveUp();
            }
            
        }
        else
        {
            if (xDiff <= 0)
            {
                moveLeft();
            }
            else
            {
                moveRight();
            }
        }
        // looking for the player
        canSeePlayer = lookingWhereYourGoing();

        if (canSeePlayer == false)
        {
            currentState = zombieState.peddleback;
        }
    }

    bool lookingWhereYourGoing()
    {
        // this script will cover the raycasting in the direction that the zombie is moving and vision checking in the
        // direction that the zombie is moving
        Vector3 agentToTargetVector = thatPricksLocation.position - GetComponent<Transform>().position;

        float angleToTarget;
        switch (directionMoving) {
            case movingIn.right:
                angleToTarget = Vector3.Angle(agentToTargetVector, Vector2.right);
                break;

            case movingIn.up:
                angleToTarget = Vector3.Angle(agentToTargetVector, Vector2.up);
                break;

            case movingIn.left:
                angleToTarget = Vector3.Angle(agentToTargetVector, -Vector2.right);
                break;

            case movingIn.down:
                angleToTarget = Vector3.Angle(agentToTargetVector, -Vector2.up);
                break;
        }

        // raycast logic

        return false;
    }

    void moveUp()
    {

        directionMoving = movingIn.up;
        // code to move up
        thisZombie.thisDamnTF.localPosition = thisZombie.thisDamnTF.localPosition + new Vector3(0, movementSpeed, 0);
    }

    void moveRight()
    {

        directionMoving = movingIn.right;
        // code to move right
        thisZombie.thisDamnTF.localPosition = thisZombie.thisDamnTF.localPosition + new Vector3(movementSpeed, 0, 0);
    }

    void moveLeft()
    {

        directionMoving = movingIn.left;
        // code to move left
        thisZombie.thisDamnTF.localPosition = thisZombie.thisDamnTF.localPosition - new Vector3(movementSpeed, 0, 0);
    }

    void moveDown()
    {

        directionMoving = movingIn.down;
        // code to move down
        thisZombie.thisDamnTF.localPosition = thisZombie.thisDamnTF.localPosition - new Vector3(0, movementSpeed, 0);
    }
}
