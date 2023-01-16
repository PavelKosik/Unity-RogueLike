using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealthInScene : MonoBehaviour
{
    public float hp;
    public GameObject healthImage;
    public float maxHp;
    public DungeonCreator dungeonCreator;
    public BoxCollider2D playerBoxCollider;
    public Text playerHealthText;
    public float startHP;
    public Image backHealthImage;
    public Animator anim;
    public InScenePlayerMovement inScenePlayerMovement;
    public float takeDamageAnimTime;  
    public BaseSceneCoinTextScript baseSceneCoinTextScript;
    // Start is called before the first frame update
    void Start()
    {
        baseSceneCoinTextScript = FindObjectOfType<BaseSceneCoinTextScript>();
        dungeonCreator = FindObjectOfType<DungeonCreator>();
       hp = dungeonCreator.playerHP;
        maxHp = dungeonCreator.maxHp;
        backHealthImage.transform.localScale= new Vector3(maxHp / startHP, 1.0f, 1.0f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene()==SceneManager.GetSceneByBuildIndex(2)) {
            CheckIfPlayerDied();
            // anim.SetBool("TookDamage", false);
        }
    }

     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.tag=="Enemy"&&collision.gameObject.GetComponent<EnemyMovement>().blocked==false&&playerBoxCollider.IsTouching(collision))
         {
            anim.SetBool("TookDamage", true);
            hp -= 10.0f;
            takeDamageAnimTime = 0.0f;
         }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<EnemyMovement>().blocked == false)
        {

            hp -= 10.0f;
        }

       
    }

    void CheckIfPlayerDied()
    {
        takeDamageAnimTime += Time.deltaTime;
        healthImage.transform.localScale = new Vector3((hp/maxHp)*(maxHp/startHP),1.0f,1.0f);
        playerHealthText.text = hp.ToString();
        if (hp<=0.0f)
        {
            anim.SetBool("Dying", true);
            inScenePlayerMovement.enabled = false;
            baseSceneCoinTextScript.numberOfGold -= dungeonCreator.numberOfGold;
            SceneManager.LoadScene("DeathScene",LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(4));
            //gameObject.SetActive(false);
        }

        if (takeDamageAnimTime>=0.2f)
        {
            anim.SetBool("TookDamage",false);
        }

    }
}
