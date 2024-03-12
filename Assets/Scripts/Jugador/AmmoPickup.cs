using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 30; // Cantidad de munición que este pickup proporcionará

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // Asegúrate de que el jugador esté etiquetado como "Player"
        {
            WeaponAmmo weaponAmmo = other.gameObject.GetComponentInChildren<WeaponAmmo>(); // Busca el componente WeaponAmmo en el hijo donde se supone que está el arma
            if (weaponAmmo != null)
            {
                weaponAmmo.extraAmmo += ammoAmount; // Añade munición extra
                Destroy(gameObject); // Destruye el objeto de munición después de recogerlo
            }
        }
    }
}