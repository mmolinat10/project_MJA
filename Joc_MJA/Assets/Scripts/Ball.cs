using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    public float speed;
    public string typeBall;
    public GameObject ball2;
    private float posBallX;
    public GameObject mainCam;
    private Game mainCamGameS;
    public GameObject pala;
    private bool reset;
    private bool firstShoot;

    // Use this for initialization
    void Start()
    {
        mainCamGameS = mainCam.GetComponent<Game>();

        posBallX = this.GetComponent<Transform>().position.x;

        Physics.IgnoreCollision(this.GetComponent<Collider>(), ball2.GetComponent<Collider>());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && reset)
        {
            transform.parent = null;
            GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            reset = false;

        }
        if (Input.GetKeyDown(KeyCode.Space) && !firstShoot)
        {
            transform.parent = null;
            GetComponent<Rigidbody>().velocity = Vector3.left * -speed;
            firstShoot = true;
        }
    }

    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "pala")
        {
            // Calculate hit Factor
            float y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector3 dir = new Vector3(1, y, 0).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;
        }

        if (col.gameObject.name == "pala2")
        {
            // Calculate hit Factor
            float y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector3 dir = new Vector3(-1, y, 0).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;



        }

        if (col.gameObject.name == "paretT")
        {
            // Calculate hit Factor
            float y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            //Vector3 dir = new Vector3(1, -GetComponent<Rigidbody>().velocity.y, 0).normalized;

            Vector3 dir = GetComponent<Rigidbody>().velocity;
            if (GetComponent<Rigidbody>().velocity.x < 0f)
            {
                dir = new Vector3(-1, -1, 0).normalized;
            }
            else if (GetComponent<Rigidbody>().velocity.x > 0)
            {
                dir = new Vector3(1, -1, 0).normalized;
            }


            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;
        }

        if (col.gameObject.name == "paretD")
        {
            // Calculate hit Factor
            float y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            //Vector3 dir = new Vector3(1, -GetComponent<Rigidbody>().velocity.y, 0).normalized;

            Vector3 dir = GetComponent<Rigidbody>().velocity;
            if (GetComponent<Rigidbody>().velocity.x < 0f)
            {
                dir = new Vector3(-1, 1, 0).normalized;
            }
            else if (GetComponent<Rigidbody>().velocity.x > 0)
            {
                dir = new Vector3(1, 1, 0).normalized;
            }

            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;
        }

        if (col.gameObject.tag == "normalBricks")
        {
            // Calculate hit Factor
            float y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            Destroy(col.gameObject);
            // Calculate direction, make length=1 via .normalized
            //Vector3 dir = new Vector3(1, -GetComponent<Rigidbody>().velocity.y, 0).normalized;

            Vector3 dir = GetComponent<Rigidbody>().velocity;
            if (GetComponent<Rigidbody>().velocity.x < 0f)
            {
                dir = new Vector3(1, 1, 0).normalized;
            }
            else if (GetComponent<Rigidbody>().velocity.x > 0)
            {
                dir = new Vector3(-1, 1, 0).normalized;
            }

            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;

        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "paretL")
        {
            
            mainCamGameS.pointsPj2 += 1;

            mainCamGameS.puntuacionPj2.GetComponent<Text>().text = mainCamGameS.pointsPj2.ToString();

            gameObject.SetActive(false);
            transform.parent = pala.transform;

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Transform>().position = new Vector3(posBallX, pala.transform.position.y, pala.transform.position.z);
            reset = true;
      
            gameObject.SetActive(true);
            

        }

        if (col.gameObject.name == "paretR")
        {
            
            mainCamGameS.pointsPj1 += 2;
            
            mainCamGameS.puntuacionPj1.GetComponent<Text>().text = mainCamGameS.pointsPj1.ToString();
            gameObject.SetActive(false);
            transform.parent = pala.transform;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Transform>().position = new Vector3(posBallX, pala.transform.position.y, pala.transform.position.z);

            reset = true;
           
            gameObject.SetActive(true);

        }
    }

    /*public void resetPos()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Transform>().position = new Vector3(posBallX, pala.transform.position.y, pala.transform.position.z);
        ball2.GetComponent<Ball2>().resetPos();
        

    }*/
}



