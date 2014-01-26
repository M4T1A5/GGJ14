using UnityEngine;
using System.Collections;

public class TreeTransition : MonoBehaviour
{
    public static GameObject SaunaContainer;
    public Thermometer thermometer;
    public OutOfWood wood;

    public GUISkin skin;

    void Start()
    {
        SaunaContainer = GameObject.Find("SaunaContainer");
        thermometer.enabled = false;
    }

    void OnGUI()
    {
        GUI.skin = skin;
        var content = new GUIContent("Sauna is too cold\nYou need to get more wood");

        var size = GUI.skin.box.CalcSize(content);
        GUI.Box(new Rect(Screen.width / 2 - size.x / 2, Screen.height / 2 - size.y / 2, size.x, size.y), content);
    }

    void OnDestroy()
    {
        thermometer.enabled = true;
        thermometer.Heat = thermometer.startHeat;
        wood.enabled = true;
        Application.LoadLevelAdditive("puunhakkuu");
        SaunaContainer.SetActive(false);
    }
}
