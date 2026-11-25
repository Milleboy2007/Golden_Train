using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Vitesse de Mouvement")]
    [SerializeField] private float vitesse = 5f;
    [SerializeField] private float vitesseRotation = 10f;

    [Header("Saut")]
    [SerializeField] private float forceSaut = 6f;
    [SerializeField] private float distanceSol = 0.2f;
    [SerializeField] private LayerMask coucheSol = ~0;
    private bool veutSauter;
    private bool estAuSol;

    [Header("Autre")]
    [SerializeField] private Transform cameraTransform; // Référence à la caméra
    private AnimationPlayer animationPlayerScript;
    
    private Rigidbody corps;
    private Vector3 direction;

    private void Awake() 
    {
        corps = GetComponent<Rigidbody>();
        animationPlayerScript = GetComponent<AnimationPlayer>();
        
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

        if(Input.GetButtonDown("Jump") && estAuSol) veutSauter = true;
        if(Input.GetKeyDown(KeyCode.Q)) animationPlayerScript.JouerPunch();

        if(Input.GetButtonDown("Fire2")) animationPlayerScript.SwitchAim(true);
        if(Input.GetButtonUp("Fire2")) animationPlayerScript.SwitchAim(false);
    }

    private void FixedUpdate()
    {
        estAuSol = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, distanceSol + 0.1f, coucheSol);
        if (veutSauter)
        {
            animationPlayerScript.JouerJump();
            corps.AddForce(Vector3.up * forceSaut, ForceMode.Impulse);
            veutSauter = false;
        }

        corps.MovePosition(corps.position + direction * vitesse * Time.fixedDeltaTime);
        
        if (direction.sqrMagnitude <= 0.001f) return;
        
        Quaternion cible = Quaternion.LookRotation(direction, Vector3.up);
        corps.MoveRotation(Quaternion.Slerp(corps.rotation, cible, vitesseRotation * Time.fixedDeltaTime));
    }
}