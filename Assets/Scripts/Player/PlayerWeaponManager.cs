using Assets.Scripts.AudioManager;
using Assets.Scripts.Player;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private GameObject _shootLight;
    [SerializeField] private Transform bulletSpawnPosition;
    [SerializeField] private float _shootColdown = 0.05f;
    private float _timer;

    [SerializeField] public string CurentWeaponType;
    [HideInInspector] public bool inTrigger = false;
    [HideInInspector] public bool Shoot = false;
    
    private PlayerAnimationController _playerAnimation;
    
    private void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimationController>();
        Shoot = true;
        _timer = _shootColdown;
    }

    private void Update()
    {
        WeaponManager();
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            AttackManager(_playerAnimation.WeaponID);
            _timer = _shootColdown;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _shootLight.SetActive(false);
            _audioManager.StopShootAudio();
        }
    }

    private void WeaponManager()
    {
        if (Input.GetMouseButtonDown(1) && !inTrigger)
        {
            DropWeapon(CurentWeaponType);
        }
    }

    public void DropWeapon(string weapon)
    {
        if (CurentWeaponType != "Null")
        {
            Instantiate(Resources.Load("Prefabs/Weapons/" + weapon), transform.position, Quaternion.identity);
            if (!inTrigger)
            {
                CurentWeaponType = "Null";
            }
            else
            {
                print("Weapon is null");
            }
        }
    }

    private void AttackManager(int ID)
    {
        if (Input.GetMouseButton(0))
        {
            switch (ID)
            {
                case 1:
                    Shooting();
                    break;
                case 2:
                    Shooting();
                    break;
                case 3:
                    Shooting();
                    break;
                default: break;
            }
        }
    }
    void Shooting()
    {
        Instantiate(Resources.Load("Prefabs/Weapons/" + CurentWeaponType + "Bullet"), bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        _shootLight.SetActive(true);
        if (!_audioManager.isShoot)
        {
            _audioManager.PlayShootAudio();
        }
    }
}
