using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BaseSceneGetUIDownScript : MonoBehaviour
{
    public GameObject[] ui;
    public bool sceneUILoaded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene()!=SceneManager.GetSceneByBuildIndex(3)) {
            sceneUILoaded = false;
            GetUIDown();
        }

        else
        {
            if (sceneUILoaded==false)
            {
                GetUIActive();
                sceneUILoaded = true;
            }
        }
    }

    

    void GetUIDown()
    {
        for (int i = 0; i < ui.Length; i++)
        {
            ui[i].SetActive(false);

        }

    }

    void GetUIActive()
    {
        for (int i = 0; i < ui.Length; i++)
        {
            ui[i].SetActive(true);

        }
    }
}
