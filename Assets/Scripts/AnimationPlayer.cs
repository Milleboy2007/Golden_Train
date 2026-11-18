using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;

    [Header("Reglages")]
    [SerializeField] private float vitesseCourse = 5f;

    private static readonly int ParametreVitesse = Animator.StringToHash("Vitesse");
    private static readonly int ParametreInteraction = Animator.StringToHash("Interaction");
    private static readonly int ParametreDegats = Animator.StringToHash("Degats");
    private static readonly int ParametrePunch = Animator.StringToHash("Punch");
    private static readonly int ParametreJump = Animator.StringToHash("Jump");
    private static readonly int ParametreIsAiming = Animator.StringToHash("isAiming");

    private Vector3 dernierePosition;

    private void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void Start()
    {
        dernierePosition = transform.position;
    }

    private void Update()
    {
        if (Time.deltaTime <= 0f) return;

        Vector3 deplacement = transform.position - dernierePosition;
        deplacement.y = 0f;
        float vitesseActuelle = deplacement.magnitude / Time.deltaTime;
        dernierePosition = transform.position;

        float vitesseNormalisee = Mathf.InverseLerp(0f, vitesseCourse, vitesseActuelle);
        animator.SetFloat(ParametreVitesse, vitesseNormalisee, 0.1f, Time.deltaTime);
    }

    public void JouerInteraction()
    {
        animator.SetTrigger(ParametreInteraction);
    }

    public void JouerDegats()
    {
        animator.SetTrigger(ParametreDegats);
    }

    public void JouerPunch()
    {
        animator.SetTrigger(ParametrePunch);
    }

    public void JouerJump()
    {
        animator.SetTrigger(ParametreJump);
    }
}