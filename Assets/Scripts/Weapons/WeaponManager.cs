using UnityEngine;

namespace Assets.Scripts.Weapons
{
    [SelectionBase]
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] public Weapon Weapon;

        private PlayerWeaponManager _playerWeaponManager;

        private void Start()
        {
            _playerWeaponManager = FindObjectOfType<PlayerWeaponManager>();
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
            if (_playerWeaponManager.CurentWeaponType != "Null")
            {
                _playerWeaponManager.DropWeapon(_playerWeaponManager.CurentWeaponType);
            }

            _playerWeaponManager.CurentWeaponType = Weapon.weaponType.ToString();
            Destroy(gameObject, 0.05f);
        }
    }
}