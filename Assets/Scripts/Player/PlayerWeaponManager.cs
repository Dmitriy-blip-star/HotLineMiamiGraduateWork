using Assets.Scripts;
using Assets.Scripts.AudioManager;
using Assets.Scripts.Player;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public string curentWeaponType;
    public bool inTrigger = false;
    public bool shoot = false;

    public Transform bulletSpawnPosition;
    PlayerAnimationController playerAnimation;

    [SerializeField] GameObject shootLight;

    [SerializeField] float shootColdown = 0.05f;

    private float _timer;

    [SerializeField] AudioManager audioManager;
    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimationController>();
        shoot = true;
        _timer = shootColdown;
    }

    private void Update()
    {
        WeaponManager();
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            AttackManager(playerAnimation.weaponID);
            _timer = shootColdown;
        }
        if (Input.GetMouseButtonUp(0))
        {
            shootLight.SetActive(false);
            audioManager.StopShootAudio();
        }
    }

    private void WeaponManager()
    {
        if (Input.GetMouseButtonDown(1) && !inTrigger)
        {
            DropWeapon(curentWeaponType);
        }
    }

    public void DropWeapon(string weapon)
    {
        if (curentWeaponType != "Null")
        {
            Instantiate(Resources.Load("Prefabs/Weapons/" + weapon), transform.position, Quaternion.identity);
            if (!inTrigger)
            {
                curentWeaponType = "Null";
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
        Instantiate(Resources.Load("Prefabs/Weapons/" + curentWeaponType + "Bullet"), bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        shootLight.SetActive(true);
        if (!audioManager.isShoot)
        {
            audioManager.PlayShootAudio();
        }
    }
}
