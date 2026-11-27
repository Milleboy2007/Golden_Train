using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamageEffect : MonoBehaviour
{

    [Header("Interface")]
    [SerializeField]
    private CanvasGroup tachesDeSang;

    [SerializeField, Min(0.1f)]
    private float dureeDisparitionSang = 2.0f; // Le temps (en secondes) que met le sang à disparaître

    private Coroutine effetEnCours;

    private void Awake()
    {

        if (tachesDeSang != null)
        {
            tachesDeSang.GameObject().SetActive(true); // Activation du sang puisque désactiver pour ne pas gênée l'édition
            tachesDeSang.alpha = 0f; // Le sang est invisible au démarrage
        }
    }

    public void DeclencherEffet()
    {
        if (effetEnCours != null)
        {
            StopCoroutine(effetEnCours);
        }

        effetEnCours = StartCoroutine(JouerEffetSang());
    }

    private IEnumerator JouerEffetSang()
    {
        if (tachesDeSang != null) tachesDeSang.alpha = 1f; // Opacité à 100%
        // 2. FONDU : Le sang disparaît progressivement
        if (tachesDeSang != null)
        {
            float tempsEcoule = 0f;

            // On fait une boucle qui tourne tant que le temps écoulé est inférieur à la durée voulue
            while (tempsEcoule < dureeDisparitionSang)
            {
                tempsEcoule += Time.deltaTime; // Ajoute le temps passé depuis la dernière frame

                // Mathf.Lerp calcule une valeur fluide entre 1 (départ) et 0 (fin) en fonction du temps
                tachesDeSang.alpha = Mathf.Lerp(1f, 0f, tempsEcoule / dureeDisparitionSang);

                yield return null; // Attend la frame suivante avant de continuer la boucle
            }

            // Par sécurité, on s'assure qu'à la fin de la boucle, l'opacité est bien exactement à zéro
            tachesDeSang.alpha = 0f;
        }

        effetEnCours = null;
    }

    private void OnDisable()
    {
        if (tachesDeSang != null) tachesDeSang.alpha = 0f;
    }

    
}
