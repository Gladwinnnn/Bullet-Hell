using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Data")]
public class PlayerData : ScriptableObject
{
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

    [Header("Shooter")]
    public float shootCoolDown;
    public float shootForce;
    public float moveForceRestriction;
    public GameObject bulletPrefab;

    [Header("Grenade")]
    public float grenadeCoolDown;
    public float grenadeForce;
    public GameObject grenadePrefab;

}
