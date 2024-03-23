using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        private PlayerWeaponManager _playerWeaponManager;
        private PlayerMovement _playerMovement;

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
            if (_playerMovement.isMove)
            {
                _anim.SetBool("isWalk", true);
            }
            else
            {
                _anim.SetBool("isWalk", false);
            }
        }
        public void DeadAnimation()
        {
            _anim.SetTrigger("Dead");
        }

    }
}