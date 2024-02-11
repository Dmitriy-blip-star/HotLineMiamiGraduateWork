using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class BaseWeapon : MonoBehaviour
    {
        [SerializeField] public Weapon weapon;
        [SerializeField] public GameObject shootLight;

        public string curentWeaponType;
        public bool shoot = false;
        public Transform bulletSpawnPosition;
        private float _timer;
        private Vector3 _randomSpread;


        public void Shoot(float wait)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _randomSpread = new Vector3(0, Random.Range(-0.08f, 0.08f), 0);

                Instantiate(Resources.Load("Prefabs/Weapons/" + curentWeaponType + "Bullet"), bulletSpawnPosition.position + -_randomSpread, bulletSpawnPosition.rotation);
                shootLight.SetActive(true);
                _timer = wait;
            }
        }

        public virtual void DropWeapon(string weapon)
        {
            if (curentWeaponType != "Null")
            {
                Instantiate(Resources.Load("Prefabs/Weapons/" + weapon), transform.position, Quaternion.identity);
                curentWeaponType = "Null";
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
    }
}