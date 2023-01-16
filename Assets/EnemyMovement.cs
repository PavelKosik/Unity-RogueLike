using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public bool playerIsNear;
    public GameObject player;
    public bool sawPlayer;
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 directionEnemyIsHeading;
    public float attackJumpSpeed;
    public float timeToJump;
    public bool canJump;
    public Ray ray;
    public bool attacking;
    public RaycastHit2D hit;
    public bool blocked;
    public float blockedSpeed;
    public float timeStunnedAfterBlock;
    public float timeStunnedAfterBlockCounter;
    // Start is called before the first frame update
    void Start()
    {
        
        rb.velocity = new Vector2(Random.Range(-1, 1) * moveSpeed * Time.deltaTime, Random.Range(-1, 1) * moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        IsPlayerNear();
        Move();
    }

  void IsPlayerNear()
    {
        if (sawPlayer==false) {
            if ((transform.position.x - player.transform.position.x <= 6.0f && player.transform.position.x - transform.position.x <= 6.0f) && (transform.position.y - player.transform.position.y <= 6.0f && player.transform.position.y - transform.position.y <= 6.0f))
            {
                playerIsNear = true;
            }

            else
            {
                playerIsNear = false;
            }

        }
    }

    void Move()
    {
        timeStunnedAfterBlockCounter += Time.deltaTime;
        timeToJump += Time.deltaTime;
        if (playerIsNear&&sawPlayer==false)
        {
            sawPlayer = true;
        }


        if (sawPlayer&&blocked==false) {

            ray.direction = player.transform.position-transform.position;
            ray.origin = transform.position;
            Debug.DrawRay(transform.position, ray.direction);
            if (attacking == false)
            {
                rb.velocity = ray.direction * moveSpeed * Time.deltaTime;

                directionEnemyIsHeading = ray.direction;
            }
           



            if (hit.distance<0.5f)
            {
                Attack();
            }

            if (attacking &&timeToJump>1.0f)
            {
                attacking = false;
            }

        }

        if (blocked)
        {
            if (timeStunnedAfterBlockCounter>=timeStunnedAfterBlock)
            {
                blocked = false;
            }
        }    

            
        

       
       
    }

    void Attack()
    {

        if (timeToJump>=0.0f) {
            if (playerIsNear) {
              
                rb.velocity = directionEnemyIsHeading * attackJumpSpeed*Time.deltaTime;
                canJump = true;
                attacking = true;
              
               
            }
        }

        if (timeToJump>1.0f)
        {
            attacking = false;
            timeToJump = 0.0f;
        }

        
               
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="PlayerShield")
        {
            //gameObject.SetActive(false);
            rb.velocity = -ray.direction*blockedSpeed*Time.deltaTime;
            blocked = true;
            timeStunnedAfterBlockCounter = 0.0f;
        }
    }
}
