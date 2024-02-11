using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyWeapon : BaseWeapon
    {
        public int Weapon;

        private void Awake()
        {
            curentWeaponType = weapon.weaponType.ToString();
            WeaponStrToID();
        }

        private void Start()
        {
            
            
        }

        public void WeaponStrToID()
        {
            switch (curentWeaponType)
            {
                case "Null":
                     Weapon = 0;
                    break;

                case "Rifle":
                    Weapon = 1;
                    break;
                case "Shotgun":
                    Weapon = 2;
                    break;
                case "BigGun":
                    Weapon = 3;
                    break;
            }
        }

    }
}