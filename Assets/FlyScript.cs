using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flyForce;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Animator animator;
    public GameObject floatingText;
    public bool gameIsRunning;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && Time.timeScale == 1)
        {
            myRigidbody.velocity = Vector2.up * flyForce;
            if(logic.score > 0)
            {
                logic.reduceScore();
            }
            else
            {
                logic.timeout();
            }
            
            FindObjectOfType<AudioManager>().Play("Jet2");
        }

        if (myRigidbody.velocity.y > 0)
        {
            animator.SetBool("FlyButtonPressed", true);
        }
        else
        {
            animator.SetBool("FlyButtonPressed", false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && birdIsAlive)
        {
            if(Time.timeScale == 1)
            {
                logic.escMenuOpen();
            }
            else if (logic.escMenuScreen.activeSelf)
            {
               logic.escMenuClose();
            }
        }
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            FindObjectOfType<AudioManager>().Play("Collect1");
            showTimerCollect();
        }
    }

    void showTimerCollect()
    {
        Instantiate(floatingText, transform.position, Quaternion.identity, transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().Play("Death");
        animator.SetBool("PlayerHit", true);
        logic.gameOver();
        birdIsAlive = false;
    }
}
