using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonOkScript : MonoBehaviour
{
    public Canvas saveCanvas;
    public Canvas baseCanvas;
    public Canvas loadCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUnActiveSaveCanvas() {
        saveCanvas.gameObject.SetActive(false);
        baseCanvas.gameObject.SetActive(true);
       loadCanvas.gameObject.SetActive(false);
    }
}
