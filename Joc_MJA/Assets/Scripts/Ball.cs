using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    public float speed;
    public string typeBall;
    public GameObject ball, ball2;
    private Vector3 posBall, posBall2;
    public GameObject puntuacionPj1, puntuacionPj2;
    public GameObject notificationPj1, notificationPj2;
    private int pointsPj1 = 0, pointsPj2 = 0;
    public GameObject mainCam;
    private Game mainCamGameS;


    // Use this for initialization
    void Start()
    {
        mainCamGameS = mainCam.GetComponent<Game>();
        Time.timeScale = 1;
        posBall = ball.GetComponent<Transform>().position;
        posBall2 = ball2.GetComponent<Transform>().position;
        Physics.IgnoreCollision(ball.GetComponent<Collider>(), ball2.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !mainCamGameS.initGame)
        {
            // Initial Velocity
            ball.GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            ball2.GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            mainCamGameS.initGame = true;
        }

        if (pointsPj1 >= 10)
        {
            notificationPj1.GetComponent<Text>().text = "Player 1 wins";
            notificationPj2.GetComponent<Text>().text = "Player 2 loses";
            notificationPj1.SetActive(true);
            notificationPj2.SetActive(true);
            mainCamGameS.endGame = true;
            ball.SetActive(false);
            ball2.SetActive(false);
            Time.timeScale = 0;
        }
        if (pointsPj2 >= 10)
        {
            notificationPj1.GetComponent<Text>().text = "Player 1 loses";
            notificationPj2.GetComponent<Text>().text = "Player 2 wins";
            notificationPj1.SetActive(true);
            notificationPj2.SetActive(true);
            mainCamGameS.endGame = true;
            ball.SetActive(false);
            ball2.SetActive(false);
            Time.timeScale = 0;
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
            else if(GetComponent<Rigidbody>().velocity.x > 0)
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
            if (this.gameObject.tag == "ball")
            {
                pointsPj2 = pointsPj2 + 1;
                puntuacionPj2.GetComponent<Text>().text = pointsPj2.ToString();
                
                ball.SetActive(false);
                ball.GetComponent<Transform>().position = posBall;
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball.SetActive(true);
                GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            }

            if (this.gameObject.tag == "ball2")
            {
                pointsPj2 = pointsPj2 + 1;
                puntuacionPj2.GetComponent<Text>().text = pointsPj2.ToString();

                ball2.SetActive(false);
                ball2.GetComponent<Transform>().position = posBall2;
                ball2.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball2.SetActive(true);
                GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            }
        }

        if (col.gameObject.name == "paretR")
        {
            if (this.gameObject.tag == "ball")
            {
                pointsPj1 = pointsPj1 + 1;
                puntuacionPj1.GetComponent<Text>().text = pointsPj1.ToString();
                ball.SetActive(false);
                ball.GetComponent<Transform>().position = posBall;
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball.SetActive(true);
                GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            }

            if (this.gameObject.tag == "ball2")
            {
                pointsPj1 = pointsPj1 + 1;
                puntuacionPj1.GetComponent<Text>().text = pointsPj1.ToString();
                ball2.SetActive(false);
                ball2.GetComponent<Transform>().position = posBall2;
                ball2.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball2.SetActive(true);
                GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            }
        }
    }
}
