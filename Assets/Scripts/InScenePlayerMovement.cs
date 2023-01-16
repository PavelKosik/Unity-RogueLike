using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InScenePlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;   
    public bool moving;
    public bool attacking;
    public float attackAnimTime;
    public Animator anim;
    public bool canAttack;
    public Vector2 directionPlayerIsHeading;
    public float dashSpeed;
    public bool canDash;
    public float timeToDash;
    public BoxCollider2D weaponBoxCollider;
    public DungeonCreator dungeonCreate;
    public PlayerHealthInScene playerHPInScene;
    public Ray currentRay;
    public List<Ray> ray = new List<Ray>();
    public GameObject[] enemies;
    public bool defending;
    public float defendingTime;
    public BoxCollider2D shieldCollider;
    public float directionPlayerCanSee;
    public GameObject wayToEnemy;
    public GameObject inst;
    public bool[] wayToEnemySpawned;
    public Image dashEnergyImage;
    public int a;
    // Start is called before the first frame update
    void Start()
    {
        canDash = true;
        canAttack = true;
       
       // SceneManager.SetActiveScene(SceneManager.GetSceneByName("EnemiesOnlyLevel"));
        
        dungeonCreate = FindObjectOfType<DungeonCreator>();
        a = dungeonCreate.numberOfRoomToLoad ;
        if (dungeonCreate.numberOfRoomToLoad == 0)
        {

            SceneManager.SetActiveScene(SceneManager.GetSceneByName("EnemiesOnlyLevel"));
        }

        if (dungeonCreate.numberOfRoomToLoad == 1)
        {

            SceneManager.SetActiveScene(SceneManager.GetSceneByName("ChestOnlyLevel"));
        }

        if (dungeonCreate.numberOfRoomToLoad == 2)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("ChestAndEnemiesLevel"));
        }
        FindEnemiesInScene();
    }

    // Update is called once per frame
    void Update()
    {
        dungeonCreate.playerHP = playerHPInScene.hp;
        if (timeToDash<=2.0f) {
            dashEnergyImage.transform.localScale = new Vector3(timeToDash/2.0f, dashEnergyImage.transform.localScale.y, dashEnergyImage.transform.localScale.z);
        }
        ShowWayToEnemies();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        AnimationHandler();
        ShowWayToEnemies();
    }

    void MovePlayer()
    {
        moving = false;
      //  weaponBoxCollider.gameObject.SetActive(false);
        attackAnimTime += 0.03f;
        timeToDash += 0.05f;
        if (Input.GetAxisRaw("Horizontal")>0.5f)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            rb.velocity = new Vector2(moveSpeed*Time.deltaTime,rb.velocity.y);
            moving = true;
            directionPlayerIsHeading = new Vector2(1.0f,directionPlayerIsHeading.y);
        }

       

        if (Input.GetAxisRaw("Horizontal") < -0.5f )
        {
            transform.rotation = Quaternion.Euler(0.0f,180.0f, 0.0f);
            rb.velocity = new Vector2(-moveSpeed * Time.deltaTime, rb.velocity.y);
            moving = true;
            directionPlayerIsHeading = new Vector2(-1.0f, directionPlayerIsHeading.y);
        }

        if (Input.GetAxisRaw("Horizontal") == 0.0f)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            directionPlayerIsHeading = new Vector2(0.0f, directionPlayerIsHeading.y);

        }

        if (Input.GetAxisRaw("Vertical") > 0.5f )
        {
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed * Time.deltaTime);
            moving = true;
            directionPlayerIsHeading = new Vector2(directionPlayerIsHeading.x,1.0f);
         
        }

        if (Input.GetAxisRaw("Vertical") < -0.5f )
        {
            rb.velocity = new Vector2(rb.velocity.x,-moveSpeed * Time.deltaTime);
            moving = true;
            directionPlayerIsHeading = new Vector2(directionPlayerIsHeading.x, -1.0f);

        }

        if (Input.GetAxisRaw("Vertical") == 0.0f)
        {
            rb.velocity = new Vector2(rb.velocity.x,0.0f);
            directionPlayerIsHeading = new Vector2(directionPlayerIsHeading.x, 0.0f);
        }

        if (Input.GetMouseButtonDown(0)&&canAttack&&defending==false)
        {
            attackAnimTime = 0.0f;
            attacking = true;
            weaponBoxCollider.gameObject.SetActive(true);
        }
        
       
        if (attackAnimTime<1.0f&&attackAnimTime>0.5f)
        {
            weaponBoxCollider.gameObject.SetActive(false);
            canAttack = false;
           
        }

        if (attackAnimTime>1.0f)
        {
            attacking = false;
            //weaponBoxCollider.gameObject.SetActive(false);
            canAttack = true;
        }


        if (Input.GetMouseButton(1)&&attacking==false)
        {
            defending = true;
            defendingTime += Time.deltaTime;
            shieldCollider.enabled = true;
        }

        else
        {
            defending = false;
            defendingTime = 0.0f;
            shieldCollider.enabled = false;
            //defendingTime -= Time.deltaTime;
        }
        if (Input.GetKeyDown("space")&&canDash)
        {
            timeToDash = 0.0f;
           transform.position = new Vector2(transform.position.x+directionPlayerIsHeading.x*dashSpeed*Time.deltaTime, transform.position.y + directionPlayerIsHeading.y*dashSpeed*Time.deltaTime);
            moving = true;

        }

        if (timeToDash<2.0f&&timeToDash>0.1f)
        {
            canDash = false;
        }

        if (timeToDash>=2.0f)
        {
            canDash = true;
        }

        if (moving == false)
        {
            rb.velocity = new Vector2(0.0f,0.0f);
        }

     

       
    }

    void AnimationHandler()
    {
        anim.SetBool("Moving", moving);
        anim.SetBool("Attacking", attacking);
        anim.SetBool("Defending", defending);
        anim.SetFloat("DefendingTime", defendingTime);
    }

    void FindEnemiesInScene()
    {
       
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
    }

    void ShowWayToEnemies()
    {
        for (int i=0;i<enemies.Length;i++)
        {

            currentRay.origin = transform.position;
            currentRay.direction = enemies[i].transform.position - transform.position;
            ray.Add(currentRay);
            Debug.DrawRay(ray[i].origin,ray[i].direction*10.0f);


            /*if (enemies[i].transform.position.x-transform.position.x>directionPlayerCanSee&&wayToEnemySpawned[i]==false&&enemies[i].activeSelf==true)
            {
                wayToEnemySpawned[i] = true;
               // Debug.Log("LMAO");
               inst= Instantiate(wayToEnemy);
                inst.transform.position = new Vector2(transform.position.x+2.0f,transform.position.y);
                inst.transform.rotation = Quaternion.Euler(currentRay.direction);
                inst.transform.localScale = currentRay.direction * 10.0f ;
                
                break;
            }

            else
            {
                wayToEnemySpawned[i] = false;
                inst.SetActive(false);
            }*/

        }
        

        ray.Clear();
       
      
   
    }
}
   
