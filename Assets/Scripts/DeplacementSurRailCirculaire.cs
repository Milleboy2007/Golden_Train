using UnityEngine;

public class DeplacementSurRailCirculaire : MonoBehaviour
{
    [SerializeField] private Transform centre;
    [SerializeField, Min(0.1f)] private float rayon = 7.5f;
    [SerializeField] private float vitesseAngulaire = 25f;
    [SerializeField] private float hauteur = 0.5f;
    [SerializeField] private float angleInitial;

    private float angle;

    private void Start()
    {
        angle = angleInitial;
    }

    private void Update()
    {
        if (centre == null)
            return;

        angle += vitesseAngulaire * Time.deltaTime;
        float radians = angle * Mathf.Deg2Rad;

        Vector3 positionLocale = new Vector3(
            Mathf.Cos(radians) * rayon,
            hauteur,
            Mathf.Sin(radians) * rayon
        );

        transform.position = centre.position + positionLocale;

        Vector3 tangente = new Vector3(
            -Mathf.Sin(radians),
            0f,
            Mathf.Cos(radians)
        );

        if (vitesseAngulaire < 0f)
            tangente = -tangente;

        transform.rotation = Quaternion.LookRotation(tangente, Vector3.up);
    }

    public void Configurer(Transform nouveauCentre, float nouveauRayon)
    {
        centre = nouveauCentre;
        rayon = nouveauRayon;
    }
}
