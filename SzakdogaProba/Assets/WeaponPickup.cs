using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponPickup : MonoBehaviour
{
    public Weapons weaponScript;
    private System.Random rnd = new System.Random();

    private void OnTriggerEnter2D(Collider2D other)
    {
        int weapon = rnd.Next(0, 2);
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            switch (weapon)
            {
                case 0:
                    weaponScript.Pistol = true;
                    Debug.Log(weapon);
                    Destroy(gameObject);
                    break;
                case 1:
                    weaponScript.LaserGum = true;
                    Destroy(gameObject);
                    Debug.Log(weapon);
                    break;
                default:
                    break;
            }
        }
    }
}
