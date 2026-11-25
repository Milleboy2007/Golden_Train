using UnityEngine;

public class Disperseur : MonoBehaviour
{
    public GameObject objet;        
    public int nombre = 60;
    public float largeur = 200f;    
    public float longueur = 400f;   
    public float couloirVoie = 8f;  

    [ContextMenu("Disperser")]
    void Disperser()
    {
        for (int k = transform.childCount - 1; k >= 0; k--)
            DestroyImmediate(transform.GetChild(k).gameObject);

        for (int i = 0; i < nombre; i++)
        {
            float x = Random.Range(-largeur / 2, largeur / 2);
            if (Mathf.Abs(x) < couloirVoie) continue;   // on évite la voie
            float z = Random.Range(0, longueur);

            GameObject o = Instantiate(objet, transform);
            o.transform.localPosition = new Vector3(x, 0, z);
            o.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            o.transform.localScale *= Random.Range(0.8f, 1.4f);
        }
    }
}