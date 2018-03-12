using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public string typeBall;
    public GameObject ball, ball2;

    // Use this for initialization
    void Start()
    {
         Physics.IgnoreCollision(ball.GetComponent<Collider>(), ball2.GetComponent<Collider>());
        // Initial Velocity
        GetComponent<Rigidbody>().velocity = Vector3.left * speed;
    }

    // Update is called once per frame
    void Update()
    {

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
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?
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

        // Hit the right Racket?
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

        if (col.gameObject.name == "paretL")
        {
            // Calculate hit Factor
            float y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            //Vector3 dir = new Vector3(1, -GetComponent<Rigidbody>().velocity.y, 0).normalized;

            Vector3 dir = GetComponent<Rigidbody>().velocity;
            if (GetComponent<Rigidbody>().velocity.y < 0f)
            {
                dir = new Vector3(1, -1, 0).normalized;
            }
            else if (GetComponent<Rigidbody>().velocity.y > 0)
            {
                dir = new Vector3(1, 1, 0).normalized;
            }

            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;
        }

        if (col.gameObject.name == "paretR")
        {
            // Calculate hit Factor
            float y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            //Vector3 dir = new Vector3(1, -GetComponent<Rigidbody>().velocity.y, 0).normalized;

            Vector3 dir = GetComponent<Rigidbody>().velocity;
            if (GetComponent<Rigidbody>().velocity.y < 0f)
            {
                dir = new Vector3(-1, -1, 0).normalized;
            }
            else if (GetComponent<Rigidbody>().velocity.y > 0)
            {
                dir = new Vector3(-1, 1, 0).normalized;
            }

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
}
