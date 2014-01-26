using UnityEngine;
using System.Collections;

public class YouLose : MonoBehaviour
{
    public GUISkin skin;

    void OnGUI()
    {
        GUI.skin = skin;
        var content = new GUIContent("Sauna is too cold\nyou lose");

        var size = GUI.skin.box.CalcSize(content);
        GUI.Box(new Rect(Screen.width / 2 - size.x/2, Screen.height / 2 - size.y/2, size.x, size.y), content);
    }

    void OnDestroy()
    {
        Application.LoadLevel("menu");
    }
}
