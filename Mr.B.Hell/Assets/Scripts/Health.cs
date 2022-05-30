using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numberOfLifeBar;

    public Image[] lifeBar;
    public Sprite fullLifeBar;
    public Sprite emptyLifeBar;

    // Update is called once per frame
    void Update()
    {
        if (health > numberOfLifeBar)
        {
            health = numberOfLifeBar;
        }

        for (int i = 0; i < lifeBar.Length; i++)
        {
            if (i < health)
            {
                lifeBar[i].sprite = fullLifeBar;
            }
            else
            {
                lifeBar[i].sprite = emptyLifeBar;
            }

            if (i < numberOfLifeBar)
            {
                lifeBar[i].enabled = true;
            }
            else
            {
                lifeBar[i].enabled = true;
            }
        }
    }
}
