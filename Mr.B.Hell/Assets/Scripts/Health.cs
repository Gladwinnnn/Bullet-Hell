using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Image[] heartImages;
    [SerializeField] Sprite emptyHeart;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthRemaining(player.Health.health);
    }

    public void HealthRemaining(int remaining)
    {
        for(int i = 0; i < heartImages.Length; i++)
        {
            if(i > remaining - 1)
            {
                heartImages[i].sprite = emptyHeart;
                break;
            }
        }
    }
}
