using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    static int deaths = 0;

    private void Start()
    {
        string text = "Deaths:";

        if (deaths <= 9999)
        {
            text += (deaths / 1000) % 10;
            text += (deaths / 100) % 10;
            text += (deaths / 10) % 10;
            text += (deaths) % 10;
        }
        else
        {
            text += "NOOB";
        }

        gameObject.GetComponent<Text>().text = text;
    }


    public void addDeath()
    {
        deaths++;
    }

}
