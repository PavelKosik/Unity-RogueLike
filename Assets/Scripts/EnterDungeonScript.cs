using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterDungeonScript : MonoBehaviour
{
    public GameObject[] ui;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Enter()
    {
      
        SceneManager.LoadScene(1,LoadSceneMode.Additive);
       
     
    }
}
