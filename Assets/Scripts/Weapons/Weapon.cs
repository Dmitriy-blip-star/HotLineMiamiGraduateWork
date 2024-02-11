using System;

[Serializable]
public class Weapon
{
    public enum WeaponType
    {
        Null,
        Rifle,
        Shotgun,
        BigGun
    }

    public WeaponType weaponType;
}
