using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public GameObject[] dungeonSquare;
    public GameObject[] nearSquare;
   public int ta;
    public bool sameX;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        dungeonSquare = GameObject.FindGameObjectsWithTag("DungeonSquare");
        
    }

    // Update is called once per frame
    void Update()
    {
        dungeonSquare = GameObject.FindGameObjectsWithTag("DungeonSquare");
       
        MovePlayer();
      
    }

   void MovePlayer()
    {
        for (int i=0;i<dungeonSquare.Length;i++)
        {
            if ((transform.position.x-dungeonSquare[i].transform.position.x==1|| transform.position.x - dungeonSquare[i].transform.position.x == 0|| transform.position.x + dungeonSquare[i].transform.position.x == -1||transform.position.x-dungeonSquare[i].transform.position.x==-1) &&(transform.position.y-dungeonSquare[i].transform.position.y==1|| transform.position.y - dungeonSquare[i].transform.position.y == 0 || transform.position.y + dungeonSquare[i].transform.position.y == -1 || transform.position.y - dungeonSquare[i].transform.position.y == -1))
            {
                nearSquare[i] = dungeonSquare[i];
            }

            else
            {
                nearSquare[i] = null;
            }
          
        }

        if (Input.GetKeyDown("w"))
        {
            sameX = false;
            for (int i=0;i<dungeonSquare.Length;i++) {

                if (nearSquare[i] && transform.position.y - dungeonSquare[i].transform.position.y == -1 && transform.position.x == dungeonSquare[i].transform.position.x)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                    sameX = true;
                    break;
                }
               
                   
               
               
            }

            for (int i = 0; i < dungeonSquare.Length; i++)
            {
                if (nearSquare[i] && transform.position.y - dungeonSquare[i].transform.position.y == -1 && transform.position.x - dungeonSquare[i].transform.position.x == -1&&sameX==false)
                {
                    transform.position = new Vector2(transform.position.x + 1, transform.position.y + 1);
                    break;
                }

                else if (nearSquare[i] && transform.position.y - dungeonSquare[i].transform.position.y == -1 && transform.position.x - dungeonSquare[i].transform.position.x == 1&&sameX == false)
                {
                    transform.position = new Vector2(transform.position.x - 1, transform.position.y + 1);
                    break;
                }
            }
            
           
        }

        if (Input.GetKeyDown("s"))
        {
            sameX = false;
            for (int i = 0; i < dungeonSquare.Length; i++)
            {

                if (nearSquare[i] && transform.position.y - dungeonSquare[i].transform.position.y == 1 && transform.position.x == dungeonSquare[i].transform.position.x)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                    sameX = true;
                    break;
                }




            }

            for (int i = 0; i < dungeonSquare.Length; i++)
            {
                if (nearSquare[i] && transform.position.y - dungeonSquare[i].transform.position.y == 1 && transform.position.x - dungeonSquare[i].transform.position.x == -1 && sameX == false)
                {
                    transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
                    break;
                }

                else if (nearSquare[i] && transform.position.y - dungeonSquare[i].transform.position.y == 1 && transform.position.x - dungeonSquare[i].transform.position.x == 1 && sameX == false)
                {
                    transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
                    break;
                }
            }

        }

        if (Input.GetKeyDown("d"))
        {
            for (int i = 0; i < dungeonSquare.Length; i++)
            {

                if (nearSquare[i] && transform.position.x - dungeonSquare[i].transform.position.x == -1 && transform.position.y == dungeonSquare[i].transform.position.y)
                {
                    transform.position = dungeonSquare[i].transform.position;
                }
            }
        }

        if (Input.GetKeyDown("a"))
        {
            for (int i = 0; i < dungeonSquare.Length; i++)
            {

                if (nearSquare[i] && transform.position.x - dungeonSquare[i].transform.position.x == 1 && transform.position.y == dungeonSquare[i].transform.position.y)
                {
                    transform.position = dungeonSquare[i].transform.position;
                }
            }
        }

       


    }
   
  
 
}
