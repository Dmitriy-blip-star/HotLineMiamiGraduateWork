using Assets.Scripts.AudioManager;
using Assets.Scripts.Player;
using Assets.Scripts.Weapons;
using UnityEngine;

public class PWM : BaseWeapon
{
    [SerializeField] private AudioManager _audioManager;
    [HideInInspector] public bool inTrigger = false;

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
}
