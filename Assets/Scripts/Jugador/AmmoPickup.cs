using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 30; // Cantidad de munici�n que este pickup proporcionar�

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // Aseg�rate de que el jugador est� etiquetado como "Player"
        {
            WeaponAmmo weaponAmmo = other.gameObject.GetComponentInChildren<WeaponAmmo>(); // Busca el componente WeaponAmmo en el hijo donde se supone que est� el arma
            if (weaponAmmo != null)
            {
                weaponAmmo.extraAmmo += ammoAmount; // A�ade munici�n extra
                Destroy(gameObject); // Destruye el objeto de munici�n despu�s de recogerlo
            }
        }
    }
}