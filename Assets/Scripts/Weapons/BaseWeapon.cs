using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class BaseWeapon : MonoBehaviour
    {
        [SerializeField] public Weapon Weapon;
        [SerializeField] public GameObject ShootLight;

        public string CurrentWeaponType;
        public bool shoot = false;
        public Transform bulletSpawnPosition;
        private float _timer;
        private Vector3 _randomSpread;
        public int WeaponID;

        private void Awake()
        {
            CurrentWeaponType = Weapon.weaponType.ToString();
            WeaponStrToID();
        }

        public void Shoot(float wait)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _randomSpread = new Vector3(0, Random.Range(-0.08f, 0.08f), 0);

                Instantiate(Resources.Load("Prefabs/Weapons/" + CurrentWeaponType + "Bullet"), bulletSpawnPosition.position + -_randomSpread, bulletSpawnPosition.rotation);
                ShootLight.SetActive(true);
                _timer = wait;
            }
        }

        public virtual void DropWeapon(string weapon)
        {
            if (CurrentWeaponType != "Null")
            {
                Instantiate(Resources.Load("Prefabs/Weapons/" + weapon), transform.position, Quaternion.identity);
                CurrentWeaponType = "Null";
            }
        }

        public void AttackManager(int ID)
        {
            switch (ID)
            {
                case 1:
                    Shoot(0.3f);
                    break;
                case 2:
                    Shoot(0.5f);
                    break;
                case 3:
                    Shoot(0.7f);
                    break;
                default: break;
            }
        }

        public void WeaponStrToID()
        {
            switch (CurrentWeaponType)
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
                default:
                    WeaponID = 1;
                    break;
            }
        }
    }
}