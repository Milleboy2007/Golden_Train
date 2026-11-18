using UnityEngine;

public class CameraSuivie : MonoBehaviour
{
    [Header("Paramètres")]
    [SerializeField] private Transform player;
    [SerializeField] private float distanceWithPlayer = 5f;
    [SerializeField] private float mouseDPI = 3f;
    [SerializeField] private Vector3 highDecal = new Vector3(0f, 1.5f, 0f); // Pour regarder les épaules/la tête, pas les pieds

    // Limites pour empêcher la caméra de faire un tour complet verticalement
    [SerializeField] private float minAngle = -20f;
    [SerializeField] private float maxAngle = 60f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private void Start()
    {
        // Verrouille le curseur au centre de l'écran et le rend invisible pour le confort de jeu
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (player == null) return;

        // 1. Lire les mouvements de la souris
        float mouseX = Input.GetAxis("Mouse X") * mouseDPI;
        float mouseY = Input.GetAxis("Mouse Y") * mouseDPI;

        // 2. Additionner ces mouvements aux angles de rotation
        rotationX += mouseX;
        rotationY -= mouseY; // On soustrait pour que glisser la souris vers le haut fasse regarder vers le haut

        // 3. Bloquer l'angle vertical pour ne pas passer sous le sol ou faire des saltos
        rotationY = Mathf.Clamp(rotationY, minAngle, maxAngle);

        // 4. Calculer la nouvelle rotation
        Quaternion rotationCamera = Quaternion.Euler(rotationY, rotationX, 0f);

        // 5. Calculer la position en reculant la caméra par rapport au joueur
        Vector3 positionVisee = player.position + highDecal;
        Vector3 positionCamera = positionVisee - (rotationCamera * Vector3.forward * distanceWithPlayer);

        // 6. Appliquer la rotation et la position à la caméra
        transform.rotation = rotationCamera;
        transform.position = positionCamera;
    }
}