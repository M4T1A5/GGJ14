using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    public GUISkin skin;
    //public Texture2D background;

    void Start()
    {
        Screen.lockCursor = false;
    }

    void OnGUI()
    {
        GUI.skin = skin;
        
        var startContent = new GUIContent("Heitähä vähä löylyä\n(Start Game)");
        var startSize = GUI.skin.button.CalcSize(startContent);

        var endContent = new GUIContent("Quit Game");

        GUILayout.BeginArea(new Rect(Screen.width / 2 - startSize.x / 2, Screen.height / 2 - startSize.y / 2 - 50, startSize.x, startSize.y*3));

        if (GUILayout.Button(startContent))
        {
            Application.LoadLevel("sauna");
        }
        else if (GUILayout.Button(endContent))
        {
            Application.Quit();
        }

        GUILayout.EndArea();
    }
}
