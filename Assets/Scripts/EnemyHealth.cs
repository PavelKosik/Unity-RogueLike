using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hp;
    public GameObject player;
    public bool playerIsNear;
    public GameObject coinPrefab;
    public int numberOfCoins;
    public GameObject[] coin;
    // Start is called before the first frame update
    void Start()
    {
        numberOfCoins = Random.Range(1,15);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfEnemyDead();
    }

   void CheckIfEnemyDead()
    {
       

            if (hp<=0.0f)
            {

            

            gameObject.SetActive(false);

            for (int i = 0; i < numberOfCoins; i++)
            {
                coin[i] = Instantiate(coinPrefab);
                if (i==0) {
                    coin[i].transform.position = new Vector2(transform.position.x,transform.position.y);
                }

                else
                {
                    coin[i].transform.position = new Vector2(coin[i-1].transform.position.x+Random.Range(-0.1f,0.1f),coin[i-1].transform.position.y+Random.Range(-0.1f,0.1f));
                }
            }

        }
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="PlayerWeapon"&&player.GetComponent<InScenePlayerMovement>().attacking)
        {
            hp -= 10.0f;
        }
    }
}
