using Assets.Scripts.AudioManager;
using Assets.Scripts.Player;
using Assets.Scripts.Weapons;
using UnityEngine;

public class PlayerWeaponManager : BaseWeapon
{
    [SerializeField] private AudioManager _audioManager;
    [HideInInspector] public bool inTrigger = false;

    [SerializeField] public int Ammo;
    public int BulletInMagazine { get; private set; }
    public int CapacityMagazine { get; private set; } = 30;

    private void Update()
    {
        WeaponManager();
        if (Input.GetMouseButton(0))
        {
            AttackManager(WeaponID);
        }
           
        if (Input.GetMouseButtonUp(0))
        {
            ShootLight.SetActive(false);
            _audioManager.StopShootAudio();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void WeaponManager()
    {
        if (Input.GetMouseButtonDown(1) && !inTrigger)
        {
            DropWeapon(CurrentWeaponType);
        }
    }

    public override void DropWeapon(string weapon)
    {
        if (CurrentWeaponType != "Null")
        {
            Instantiate(Resources.Load("Prefabs/Weapons/" + weapon), transform.position, Quaternion.identity);
            if (!inTrigger)
            {
                CurrentWeaponType = "Null";
            }
            else
            {
                print("Weapon is null");
            }
        }
    }

    public override void Shoot(float wait)
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0 && BulletInMagazine > 0)
        {
            BulletInMagazine--;
            RandomSpread = new Vector3(0, Random.Range(-0.08f, 0.08f), 0);

            Instantiate(Resources.Load("Prefabs/Weapons/" + CurrentWeaponType + "Bullet"), bulletSpawnPosition.position + -RandomSpread, bulletSpawnPosition.rotation);
            ShootLight.SetActive(true);
            Timer = wait;
        }
    }

    private void Reload()
    {
        if (Ammo >= CapacityMagazine)
        {
            BulletInMagazine = CapacityMagazine;
            Ammo -= CapacityMagazine;
        }
        else if(Ammo > 0)
        {
            BulletInMagazine = Ammo;
            Ammo = 0;
        }
        else
        {
            print("No ammo");
        }
    }
}
