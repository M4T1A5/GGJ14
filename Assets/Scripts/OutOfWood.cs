using UnityEngine;
using System.Collections;

public class OutOfWood : MonoBehaviour
{
    public GameObject transition;
    public GameObject youlose;

    public int lives;
	
    public void HitSomeTrees(Thermometer thermometer)
    {
        if (lives > 1)
        {
            thermometer.enabled = false;
            var go = (GameObject)Instantiate(transition);
            var trans = go.GetComponent<TreeTransition>();
            trans.wood = this;
            trans.thermometer = thermometer;
            Destroy(go, 5.0f);
            enabled = false;
        }
        else
        {
            thermometer.enabled = false;
            var go = (GameObject)Instantiate(youlose);
            Destroy(go, 5.0f);
            enabled = false;
        }
        lives--;
    }
}
