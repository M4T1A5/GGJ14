using UnityEngine;
using System.Collections;

public class TakeScreenshot : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.K))
            Application.CaptureScreenshot("ruutukuva.png", 2);
	}
}
