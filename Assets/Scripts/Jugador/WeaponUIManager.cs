using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUIManager : MonoBehaviour
{
    [SerializeField] private Image weaponImage; 
    [SerializeField] private Image bulletTypeImage; 
    [SerializeField] private TMP_Text ammoText; 
    [SerializeField] private WeaponClassManager weaponClassManager;

    
    public Sprite[] weaponSprites; 
    public Sprite[] bulletTypeSprites; 

    void Update()
    {
        UpdateWeaponUI();
    }

    void UpdateWeaponUI()
    {
        if (weaponClassManager.currentWeaponIndex >= 0)
        {
            WeaponManager currentWeapon = weaponClassManager.weapons[weaponClassManager.currentWeaponIndex];
            int weaponIndex = weaponClassManager.currentWeaponIndex; 

            weaponImage.sprite = weaponSprites[weaponIndex];

            bulletTypeImage.sprite = bulletTypeSprites[weaponIndex];

            ammoText.text = $"{currentWeapon.ammo.currentAmmo} / {currentWeapon.ammo.extraAmmo}";
        }
    }
}