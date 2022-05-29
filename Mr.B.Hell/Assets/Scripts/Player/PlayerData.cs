using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Health")]
    public int health;
    public float knockbackForce;
    public float knockbackTime;
    public float immunityTime;

    [Header("Movement")]
    public float moveForce;

    [Header("Charge")]
    public float chargeCoolDown;
    public float shake;
    public float maxChargeTime;
    public float chargeTime;

    [Header("Dash")]
    public float dashForce;
    public float dashTime;

    [Header("Echo Effect")]
    public float echoTime;
    public GameObject echo;


    [Header("Shooter")]
    public float shootCoolDown;
    public float shootForce;
    public float moveForceRestriction;
    public GameObject bulletPrefab;
    public float shakeAmount;

    [Header("Grenade")]
    public float grenadeCoolDown;
    public float grenadeForce;
    public GameObject grenadePrefab;

}
