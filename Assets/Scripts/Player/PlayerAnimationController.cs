using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        private PlayerWeaponManager _playerWeaponManager;
        private PlayerMovement playerMovement;

        public int weaponID = 0;
        private bool _shoot = false;

        private void Start()
        {
            _playerWeaponManager = GetComponent<PlayerWeaponManager>();
            playerMovement= GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            _anim.SetInteger("weapons", weaponID);
            WeaponAnimation(_playerWeaponManager.curentWeaponType);
            if (playerMovement.isMove)
            {
                _anim.StopPlayback();
            }
            else
            {
                _anim.StartPlayback();

            }
        }

        private void WeaponAnimation(string weapon)
        {
            switch (weapon)
            {
                case "Null":
                    weaponID = 0;
                    break;

                case "Rifle":
                    weaponID = 1;
                    break;
                case "Shotgun":
                    weaponID = 2;
                    break;
                case "BigGun":
                    weaponID = 3;
                    break;
            }
        }

        public void DeadAnimation()
        {
            _anim.SetBool("isDead", true);
        }

    }
}