using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public Image dashImage;
    public float dashCoolDown = 5;
    bool isDashCoolDown = false;
    public KeyCode dash;

    public Image shootImage;
    public float shootCoolDown = 5;
    bool isShootCoolDown = false;
    public KeyCode shoot;

    public Image grenadeImage;
    public float grenadeCoolDown = 5;
    bool isGrenadeCoolDown = false;
    public KeyCode grenade;

    // Start is called before the first frame update
    void Start()
    {
        dashImage.fillAmount = 0;
        shootImage.fillAmount = 0;
        grenadeImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
        Shoot();
        Grenade();
    }

    void Dash()
    {
        if (Input.GetKey(dash) && !isDashCoolDown)
        {
            isDashCoolDown = true;
            dashImage.fillAmount = 1;
        }

        if (isDashCoolDown)
        {
            dashImage.fillAmount -= 1/ dashCoolDown * Time.deltaTime;

            if (dashImage.fillAmount <= 0)
            {
                dashImage.fillAmount = 0;
                isDashCoolDown = false;
            }
        }
    }

    void Shoot()
    {
        if (Input.GetKey(shoot) && !isShootCoolDown)
        {
            isShootCoolDown = true;
            shootImage.fillAmount = 1;
        }

        if (isShootCoolDown)
        {
            shootImage.fillAmount -= 1/ shootCoolDown * Time.deltaTime;

            if (shootImage.fillAmount <= 0)
            {
                shootImage.fillAmount = 0;
                isShootCoolDown = false;
            }
        }
    }

    void Grenade()
    {
        if (Input.GetKey(grenade) && !isGrenadeCoolDown)
        {
            isGrenadeCoolDown = true;
            grenadeImage.fillAmount = 1;
        }

        if (isGrenadeCoolDown)
        {
            grenadeImage.fillAmount -= 1/ grenadeCoolDown * Time.deltaTime;

            if (grenadeImage.fillAmount <= 0)
            {
                grenadeImage.fillAmount = 0;
                isGrenadeCoolDown = false;
            }
        }
    }
}
