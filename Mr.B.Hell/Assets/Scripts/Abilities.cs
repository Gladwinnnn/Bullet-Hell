using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [SerializeField]
    Animator dashAnim, shootAnim, grenadeAnim;

    public Image dashImage;
    public float dashCoolDown = 5;
    bool isDashCoolDown = false;

    public Image shootImage;
    public float shootCoolDown = 5;
    bool isShootCoolDown = false;

    public Image grenadeImage;
    public float grenadeCoolDown = 5;
    bool isGrenadeCoolDown = false;

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

    public void OnCooldown(int type, float cooldown)
    {
        switch(type)
        {
            case 1: 
                isDashCoolDown = true;
                dashCoolDown = cooldown;
                dashImage.fillAmount = 1;
                break;
            case 2:
                isShootCoolDown = true;
                shootCoolDown = cooldown;
                shootImage.fillAmount = 1;
                break;
            case 3:
                isGrenadeCoolDown = true;
                grenadeCoolDown = cooldown;
                grenadeImage.fillAmount = 1;
                break;
        }
    }

    void Dash()
    {
        if (isDashCoolDown)
        {
            dashImage.fillAmount -= 1/ dashCoolDown * Time.deltaTime;

            if (dashImage.fillAmount <= 0)
            {
                dashImage.fillAmount = 0;
                isDashCoolDown = false;
                dashAnim.SetTrigger("nudge");
            }
        }
    }

    void Shoot()
    {
        if (isShootCoolDown)
        {
            shootImage.fillAmount -= 1/ shootCoolDown * Time.deltaTime;

            if (shootImage.fillAmount <= 0)
            {
                shootImage.fillAmount = 0;
                isShootCoolDown = false;
                shootAnim.SetTrigger("nudge");
            }
        }
    }

    void Grenade()
    {
        if (isGrenadeCoolDown)
        {
            grenadeImage.fillAmount -= 1/ grenadeCoolDown * Time.deltaTime;

            if (grenadeImage.fillAmount <= 0)
            {
                grenadeImage.fillAmount = 0;
                isGrenadeCoolDown = false;
                grenadeAnim.SetTrigger("nudge");
            }
        }
    }
}
