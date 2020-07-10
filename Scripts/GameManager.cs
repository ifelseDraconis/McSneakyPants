using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Vector3 spawnLocation;
    public float playerMovementSpeed;
    public bool canMovePlayer;

    public float fieldOfView;
    public float maxSightDistance;
    public float killDistance;

    public GameObject gameHearts1;
    public GameObject gameHearts2;
    public GameObject gameHearts3;

    public GameObject startButton;
    public GameObject gameOverScreen;
    public GameObject playerCharacter;

    private bool hasKey;
    private int lifeCount;

    // this keeps there from being more than one instance of game manager
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        canMovePlayer = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        lifeCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeCount < 3)
        {
            if (lifeCount <= 0)
            {
                gameHearts1.GetComponent<SpriteRenderer>().enabled = false;
                gameHearts2.GetComponent<SpriteRenderer>().enabled = false;
                gameHearts3.GetComponent<SpriteRenderer>().enabled = false;
                // code for a game over
                gameOverScreen.SetActive(true);
                canMovePlayer = false;
            } 
            else
            {
                if (lifeCount >= 3)
                {
                    gameHearts1.GetComponent<SpriteRenderer>().enabled = true;
                    gameHearts2.GetComponent<SpriteRenderer>().enabled = true;
                    gameHearts3.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    if (lifeCount == 2)
                    {
                        gameHearts1.GetComponent<SpriteRenderer>().enabled = true;
                        gameHearts2.GetComponent<SpriteRenderer>().enabled = true;
                        gameHearts3.GetComponent<SpriteRenderer>().enabled = false;
                    }
                    else
                    {
                        gameHearts1.GetComponent<SpriteRenderer>().enabled = true;
                        gameHearts2.GetComponent<SpriteRenderer>().enabled = false;
                        gameHearts3.GetComponent<SpriteRenderer>().enabled = false;
                    }                        

                }
            }
        }
    }

    public void getKey()
    {
        hasKey = true;
    }

    public void hitInFace()
    {
        lifeCount--;
    }

    public void resetGame()
    {
        hasKey = false;
        lifeCount = 3;
        startButton.SetActive(true);
        canMovePlayer = false;
        playerCharacter.GetComponent<PlayerController>().youGotMe();
    }

    public bool canEndGame()
    {
        if (hasKey)
        {
            canMovePlayer = false;
            return true;            
        }
        else
        {
            return false;
        }        
    }

    public void letsBegin()
    {
        startButton.SetActive(false);
        canMovePlayer = true;
    }
}
