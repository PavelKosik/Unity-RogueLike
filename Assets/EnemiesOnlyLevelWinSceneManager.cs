using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemiesOnlyLevelWinSceneManager : MonoBehaviour
{
    public GameObject[] enemy;
    public int a;
    public bool[] isDead;
    public DungeonCreator dungeonCreator;
    // Start is called before the first frame update
    void Start()
    {
        dungeonCreator = FindObjectOfType<DungeonCreator>();
        FindEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        ChechIfPlayerWon();
        
    }

    void ChechIfPlayerWon()
    {

        for (int i=0;i<enemy.Length;i++) {

            if (enemy[i].activeInHierarchy == false)
            {
                isDead[i] = true;
               
            }
            
        }

        for (int j = 0; j < enemy.Length; j++)
        {
            if (isDead[j])
            {
                continue;
            }

            else
            {
                break;
            }

            
        }

        
       
      

      /*  if (isDead[0]&& isDead[1] && isDead[2] && isDead[3])
        {
            if (Input.GetKeyDown("e"))
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("DungeonSquareScene"));
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("EnemiesOnlyLevel"));
                dungeonCreator.finishedRoom = true;
                dungeonCreator.coinText.gameObject.SetActive(true);
            }
        }*/
    }

    void FindEnemies()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
