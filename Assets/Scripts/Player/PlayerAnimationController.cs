using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        private PlayerWeaponManager _playerWeaponManager;
        private PlayerMovement _playerMovement;

        //public int WeaponID = 0;
        private bool _shoot = false;
        internal int WeaponID;

        private void Start()
        {
            _playerWeaponManager = GetComponent<PlayerWeaponManager>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            _anim.SetInteger("weapons", WeaponID);
            //WeaponAnimation(_playerWeaponManager.CurentWeaponType);
            if (_playerMovement.isMove)
            {
                _anim.StopPlayback();
            }
            else
            {
                _anim.StartPlayback();

            }
        }

        //private void WeaponAnimation(string weapon)
        //{
        //    switch (weapon)
        //    {
        //        case "Null":
        //            WeaponID = 0;
        //            break;

        //        case "Rifle":
        //            WeaponID = 1;
        //            break;
        //        case "Shotgun":
        //            WeaponID = 2;
        //            break;
        //        case "BigGun":
        //            WeaponID = 3;
        //            break;
        //    }
        //}

        public void DeadAnimation()
        {
            _anim.SetBool("isDead", true);
        }

    }
}