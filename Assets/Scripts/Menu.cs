using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    public GUISkin skin;

    void Start()
    {
    }

    void OnGUI()
    {
        GUI.skin = skin;

        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 200),
            "Heitähä vähä löylyä\n(Start Game)"))
            Application.LoadLevel("testi");
    }
}
