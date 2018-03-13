using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public bool player1;
    public float speed;
    private Rigidbody RB;
    public  float heightPala;
    public GameObject ball, ball2;
    public GameObject mainCam;
    private Game mainCamGameS;

    // Use this for initialization
    void Start() {
        RB = this.GetComponent<Rigidbody>();
        mainCamGameS = mainCam.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mainCamGameS.endGame)
        { 
            if (player1) { movementPlayer1(); }
            if (!player1) { movementPlayer2(); }
            checkPositions();
        }
       

    }

    public void movementPlayer1()
    {
        if (Input.GetKey(KeyCode.W))
        {
            RB.transform.position = new Vector3(RB.transform.position.x, RB.transform.position.y + speed, RB.transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            RB.transform.position = new Vector3(RB.transform.position.x, RB.transform.position.y - speed, RB.transform.position.z);
        }
    }

    public void movementPlayer2()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RB.transform.position = new Vector3(RB.transform.position.x, RB.transform.position.y + speed, RB.transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            RB.transform.position = new Vector3(RB.transform.position.x, RB.transform.position.y - speed, RB.transform.position.z);
        }

    }

    public void checkPositions()
    {
        if(RB.transform.position.y > heightPala)
        {
            RB.transform.position = new Vector3(RB.transform.position.x, heightPala, RB.transform.position.z);
        }

        if (RB.transform.position.y < -heightPala)
        {
            RB.transform.position = new Vector3(RB.transform.position.x, -heightPala, RB.transform.position.z);
        }
    }
}