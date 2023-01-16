using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DungeonCreator : MonoBehaviour
{
    public int minNumberOfSquares;
    public int maxNumberOfSquares;
    public int numberOfSquares;
    public GameObject[] dungeonSquare;
    public GameObject dungeonSquarePrefab;
    public Vector2[] lastSquarePosition;
    public GameObject[] destroyedSquare;
    public int numberOfDestroyedSquares;
    public Vector2[] possiblePositions;
    public int numberOfPossiblePositions;
    public bool[] isBlocked;
    public Vector2[] createdSquarePosition;
    public int[] placeX;
    public int[] placeY;
    public GameObject player;
    public int playerStartPositionUpDown;   
    public Vector2 expectedPlayerPosition;
    public Vector2 playerStartPosition;
    public bool[] roomIsClear;
    public string[] sceneToLoad;
    public int[] roomToCreate;
    public GameObject start;
    public float playerHP;
    public Image healthImage;
    public float maxHp;
    public float numberOfGold;
    public Text coinText;    
    public bool finishedRoom;
    public BaseSceneGetUIDownScript baseSceneGetUIDownScript;
    public Player playerPlayerScript;
    public Text playerHealthText;
    public float startHP;
    public Image playerHealthBackgroundImage;
    public int numberOfRoomToLoad;
    // Start is called before the first frame update
    
    void Start()
    {
       healthImage.transform.localScale = new Vector3(maxHp / startHP, 1.0f, 1.0f);
        playerHealthBackgroundImage.transform.localScale= new Vector3(maxHp / startHP, 1.0f, 1.0f); 
        playerPlayerScript = FindObjectOfType<Player>();
        playerPlayerScript.load = false;
        maxHp = playerPlayerScript.health;
        playerHP = maxHp;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        numberOfSquares = Random.Range(minNumberOfSquares, maxNumberOfSquares);
        dungeonSquare[0] = dungeonSquarePrefab;
        dungeonSquare[0].name = "DungeonSquare 0";
        
        possiblePositions[0] = new Vector2(0, 0);
        possiblePositions[1] = new Vector2(0, 1);
        possiblePositions[2] = new Vector2(0, 2);
   
        possiblePositions[3] = new Vector2(0, -1);
        possiblePositions[4] = new Vector2(0, -2);
    
        possiblePositions[5] = new Vector2(1, 0);
        possiblePositions[6] = new Vector2(1, 1);
        possiblePositions[7] = new Vector2(1, 2);
   
        possiblePositions[8] = new Vector2(1, -1);
        possiblePositions[9] = new Vector2(1, -2);
      
        possiblePositions[10] = new Vector2(2, 0);
        possiblePositions[11] = new Vector2(2, 1);
        possiblePositions[12] = new Vector2(2, 2);
    
        possiblePositions[13] = new Vector2(2, -1);
        possiblePositions[14] = new Vector2(2, -2);
             
        possiblePositions[15] = new Vector2(-1, 0);
        possiblePositions[16] = new Vector2(-1, 1);
        possiblePositions[17] = new Vector2(-1, 2);
       
        possiblePositions[18] = new Vector2(-1, -1);
        possiblePositions[19] = new Vector2(-1, -2);
    
        possiblePositions[20] = new Vector2(-2, 0);
        possiblePositions[21] = new Vector2(-2, 1);
        possiblePositions[22] = new Vector2(-2, 2);
      
        possiblePositions[23] = new Vector2(-2, -1);
        possiblePositions[24] = new Vector2(-2, -2);
     
      
     
        isBlocked[0] = true;
        CreateDungeonSquares();
        CheckPossiblePositions();
        DestroyNearSquares();       
        RecreateDestroyedSquares();
        PlacePlayer();
        CheckIfRoomIsClearStart();
        SetupDungeonRooms();
    }

    // Update is called once per frame
    void Update()
    {
        
        TeleportToUnclearRooms();
        ReturnToBase();
        HP_Gold_Tracker();
       
    }

    void CreateDungeonSquares()
    {
        for (int i=1;i<numberOfSquares;i++)
        {
            dungeonSquare[i] = Instantiate(dungeonSquarePrefab);
            dungeonSquare[i].name = "DungeonSquare " + i.ToString();
            if (i==1)
            {
                placeX[i] = Random.Range(-1,2);
                placeY[i] = Random.Range(-1, 2);
                dungeonSquare[i].transform.position=new Vector2(placeX[i],placeY[i]);
                lastSquarePosition[i] = dungeonSquare[i].transform.position;
           
               
            }

            else
            {
                placeX[i] = Random.Range(-1, 2);
                placeY[i] = Random.Range(-1, 2);
                dungeonSquare[i].transform.position = new Vector2(lastSquarePosition[i-1].x+placeX[i],lastSquarePosition[i-1].y+ placeY[i]);
                lastSquarePosition[i] = dungeonSquare[i].transform.position;
              ;
            }

            
        }
    }

  
    void DestroyNearSquares()
    {
        for (int i=0;i<numberOfSquares;i++)
        {
            for (int k=0;k<i;k++)
            {

                if (dungeonSquare[i].transform.position==dungeonSquare[k].transform.position)
                {
                    dungeonSquare[i].SetActive(false);
                    destroyedSquare[i] = dungeonSquare[i];
                }
            }
                
        }
     
    }


    void RecreateDestroyedSquares()
    {
        for (int i=0;i<numberOfSquares;i++)
        {
            if (destroyedSquare[i]!=null)
            {
                numberOfDestroyedSquares += 1;
            }
        }

       
            for (int k=0;k<numberOfSquares; k++)
            {
                if (destroyedSquare[k]!=null)
                {
                
                createdSquarePosition[k] = new Vector2(dungeonSquare[k].transform.position.x,dungeonSquare[k].transform.position.y);

                for (int l=0;l<=numberOfPossiblePositions;l++) {
                                                 
                        if (isBlocked[l] == false&&((possiblePositions[l].x-createdSquarePosition[k].x  == 1 || createdSquarePosition[k].x - possiblePositions[l].x == 1)  && (possiblePositions[l].y- createdSquarePosition[k].y == 1|| createdSquarePosition[k].y - possiblePositions[l].y == 1)))
                        {
                        dungeonSquare[k] = Instantiate(dungeonSquarePrefab);
                        dungeonSquare[k].transform.position = new Vector2(possiblePositions[l].x, possiblePositions[l].y);
                            isBlocked[l] = true;
                        break;
                        }

                    else if (isBlocked[l]==false&&((possiblePositions[l].x - createdSquarePosition[k].x == 1|| createdSquarePosition[k].x - possiblePositions[l].x == 1) &&(possiblePositions[l].y - createdSquarePosition[k].y == 0)))
                    {
                        dungeonSquare[k] = Instantiate(dungeonSquarePrefab);
                        dungeonSquare[k].transform.position = new Vector2(possiblePositions[l].x, possiblePositions[l].y);
                        isBlocked[l] = true;
                        break;
                    }
                        
                    else if (isBlocked[l] == false && ((possiblePositions[l].y - createdSquarePosition[k].y == 1|| createdSquarePosition[k].y- possiblePositions[l].y == 1) && (possiblePositions[l].x - createdSquarePosition[k].x == 0)))
                    {
                        dungeonSquare[k] = Instantiate(dungeonSquarePrefab);
                        dungeonSquare[k].transform.position = new Vector2(possiblePositions[l].x, possiblePositions[l].y);
                   
                        isBlocked[l] = true;
                        break;
                    }

                    else
                    {
                      //  Debug.Log("fail"+k.ToString());
                        
                    }
                   

                }

                numberOfDestroyedSquares -= 1;
           
                
              
                
                }

           

            }

       
      
    }

    void CheckPossiblePositions()
    {
        for (int i=0;i<numberOfSquares;i++)
        {
            for (int j=0;j<numberOfPossiblePositions;j++)
            {
                if (dungeonSquare[i].transform.position.x==possiblePositions[j].x&& dungeonSquare[i].transform.position.y == possiblePositions[j].y)
                {
                    isBlocked[j] = true;
                }

               
            }
        }

       

        
    }


    void PlacePlayer()
    {
        playerStartPositionUpDown = Random.Range(0,2);
      
        //player se spawne na nejnizsim bode 
        if (playerStartPositionUpDown==0) {

            
                for (int i = 0; i < numberOfSquares; i++)
                {
                    for (int j = 0; j < numberOfSquares; j++) {

                        if (i == 0)
                        {
                            expectedPlayerPosition = dungeonSquare[i].transform.position;
                        start.transform.position = expectedPlayerPosition;
                        }
                        else
                        {
                            if (dungeonSquare[i].transform.position.y < dungeonSquare[j].transform.position.y && expectedPlayerPosition.y > dungeonSquare[i].transform.position.y)
                            {
                                expectedPlayerPosition = dungeonSquare[i].transform.position;
                            start.transform.position = expectedPlayerPosition;
                                Debug.Log("x: " + expectedPlayerPosition.x.ToString());
                                Debug.Log("y: " + expectedPlayerPosition.y.ToString());
                                Debug.Log(i.ToString());
                                Debug.Log(j.ToString());

                            }

                            else if (dungeonSquare[i].transform.position.y == dungeonSquare[j].transform.position.y && expectedPlayerPosition.y > dungeonSquare[i].transform.position.y)
                            {
                                expectedPlayerPosition = dungeonSquare[i].transform.position;
                            start.transform.position = expectedPlayerPosition;
                        }



                        }
                    }
                }
            

            

        }

        //player se spawne na nejvyssim bode
        if (playerStartPositionUpDown==1)
        {
            for (int i = 0; i < numberOfSquares; i++)
            {
                for (int j = 0; j < numberOfSquares; j++)
                {

                    if (i == 0)
                    {
                        expectedPlayerPosition = dungeonSquare[i].transform.position;
                        start.transform.position = expectedPlayerPosition;
                    }
                    else
                    {
                        if (dungeonSquare[i].transform.position.y > dungeonSquare[j].transform.position.y && expectedPlayerPosition.y < dungeonSquare[i].transform.position.y)
                        {
                            expectedPlayerPosition = dungeonSquare[i].transform.position;
                            start.transform.position = expectedPlayerPosition;
                            Debug.Log("x: " + expectedPlayerPosition.x.ToString());
                            Debug.Log("y: " + expectedPlayerPosition.y.ToString());
                            Debug.Log(i.ToString());
                            Debug.Log(j.ToString());

                        }

                        else if (dungeonSquare[i].transform.position.y == dungeonSquare[j].transform.position.y && expectedPlayerPosition.y < dungeonSquare[i].transform.position.y)
                        {
                            expectedPlayerPosition = dungeonSquare[i].transform.position;
                            start.transform.position = expectedPlayerPosition;
                        }



                    }
                }
            }

        }

        player.transform.position = expectedPlayerPosition;
        playerStartPosition = player.transform.position;
    }

    void CheckIfRoomIsClearStart()
    {
        for (int i=0;i<numberOfSquares;i++)
        {
            if (dungeonSquare[i].transform.position.x == playerStartPosition.x&& dungeonSquare[i].transform.position.y == playerStartPosition.y)
            {
                roomIsClear[i] = true;
            }
        }
    }
   
    void TeleportToUnclearRooms()
    {
        for (int i=0;i<numberOfSquares;i++)
        {
            if (player.transform.position==dungeonSquare[i].transform.position&&roomIsClear[i]==false)
            {
                player.GetComponent<PlayerMovement>().enabled = false;
                roomIsClear[i] = true;
                numberOfRoomToLoad = roomToCreate[i];
                SceneManager.LoadScene(sceneToLoad[i].ToString(),LoadSceneMode.Additive);
                coinText.gameObject.SetActive(false);
                break;
            }

           
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EnemiesOnlyLevel"))
        {
            player.GetComponent<PlayerMovement>().enabled = false;

        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ChestOnlyLevel"))
        {
            player.GetComponent<PlayerMovement>().enabled = false;

        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ChestAndEnemiesLevel"))
        {
            player.GetComponent<PlayerMovement>().enabled = false;

        }

        if (SceneManager.GetActiveScene()==SceneManager.GetSceneByName("DungeonSquareScene"))
        {
            player.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = true;
        }

       
    }

    void SetupDungeonRooms()
    {
        for (int i=0;i<numberOfSquares;i++)
        {
            roomToCreate[i] = Random.Range(0,3);
            if (roomToCreate[i]==0) {
                sceneToLoad[i] = "EnemiesOnlyLevel";
            }

            if (roomToCreate[i]==1)
            {
                sceneToLoad[i] = "ChestOnlyLevel";
            }

            if (roomToCreate[i]==2)
            {
                sceneToLoad[i] = "ChestAndEnemiesLevel";
            }

        }

    }

    void ReturnToBase()
    {
        if (player.transform.position == start.transform.position&&Input.GetKeyDown("e"))
        {
         
            SceneManager.UnloadSceneAsync(1);
           
        }
    }


    void HP_Gold_Tracker()
    {
        playerHealthText.text = playerHP.ToString();
        healthImage.transform.localScale = new Vector3((playerHP / maxHp) * (maxHp / startHP), 1.0f, 1.0f);
        coinText.text = numberOfGold.ToString();
        
    }
}
