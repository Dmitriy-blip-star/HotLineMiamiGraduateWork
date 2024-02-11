using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    [SelectionBase]
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] public Weapon weapon;

        PlayerWeaponManager playerWeaponManager;

        private void Start()
        {
            playerWeaponManager = FindObjectOfType<PlayerWeaponManager>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerWeaponManager>())
            {
                collision.GetComponent<PlayerWeaponManager>().inTrigger = true;
                if (Input.GetMouseButtonDown(1))
                {
                    ChangeWeapons();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerWeaponManager>())
            {
                collision.GetComponent<PlayerWeaponManager>().inTrigger = false;
            }
        }

        private void ChangeWeapons()
        {
            if (playerWeaponManager.curentWeaponType != "Null")
            {
                playerWeaponManager.DropWeapon(playerWeaponManager.curentWeaponType);
            }

            playerWeaponManager.curentWeaponType = weapon.weaponType.ToString();
            Destroy(gameObject, 0.05f);
        }
    }
}