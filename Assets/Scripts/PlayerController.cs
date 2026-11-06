using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float vitesse = 5f;
    [SerializeField] private float vitesseRotation = 10f;
    [SerializeField] private Transform cameraTransform; // Référence à la caméra
    
    private Rigidbody corps;
    private Vector3 direction;

    private void Awake() 
    {
        corps = GetComponent<Rigidbody>();
        
        // Si aucune caméra n'est assignée dans l'inspecteur, on prend la caméra principale
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 1. Obtenir les directions avant et droite de la caméra
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        // 2. Aplatir ces vecteurs sur l'axe Y (pour ne pas voler ou s'enfoncer dans le sol)
        camForward.y = 0f;
        camRight.y = 0f;

        // 3. Normaliser pour garder une longueur de 1 après avoir retiré le Y
        camForward.Normalize();
        camRight.Normalize();

        // 4. Calculer la direction finale en fonction de la caméra et des inputs
        Vector3 directionRelative = camForward * vertical + camRight * horizontal;
        
        direction = Vector3.ClampMagnitude(directionRelative, 1f);
    }

    private void FixedUpdate()
    {
        corps.MovePosition(corps.position + direction * vitesse * Time.fixedDeltaTime);
        
        if (direction.sqrMagnitude <= 0.001f) return;
        
        Quaternion cible = Quaternion.LookRotation(direction, Vector3.up);
        corps.MoveRotation(Quaternion.Slerp(corps.rotation, cible, vitesseRotation * Time.fixedDeltaTime));
    }
}