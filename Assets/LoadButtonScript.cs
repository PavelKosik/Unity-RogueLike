using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadButtonScript : MonoBehaviour
{
    public Canvas loadButtonCanvas;
    public Canvas baseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        loadButtonCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCanvasActive()
    {
        loadButtonCanvas.gameObject.SetActive(true);
        baseCanvas.gameObject.SetActive(false);
    }

    public void SetCanvasUnActive()
    {
        loadButtonCanvas.gameObject.SetActive(false);
        baseCanvas.gameObject.SetActive(true);
    }
}
