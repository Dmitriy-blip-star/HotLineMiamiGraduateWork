using Assets.Scripts.Weapons;

namespace Assets.Scripts.Enemy
{
    public class EnemyWeapon : BaseWeapon
    {
        public int WeaponID;

        private void Awake()
        {
            curentWeaponType = Weapon.weaponType.ToString();
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
                    WeaponID = 0;
                    break;

                case "Rifle":
                    WeaponID = 1;
                    break;
                case "Shotgun":
                    WeaponID = 2;
                    break;
                case "BigGun":
                    WeaponID = 3;
                    break;
            }
        }

    }
}