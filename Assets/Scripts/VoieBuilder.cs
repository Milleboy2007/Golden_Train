using UnityEngine;

public class VoieBuilder : MonoBehaviour
{
    public GameObject railPrefab;
    public int nombre = 50;
    public float echelle = 10f;   

    void Start() { Construire(); }

    [ContextMenu("Construire")]
    void Construire()
    {

        for (int k = transform.childCount - 1; k >= 0; k--)
            DestroyImmediate(transform.GetChild(k).gameObject);

        float longueur = railPrefab.GetComponentInChildren<MeshFilter>().sharedMesh.bounds.size.z * echelle;

        for (int i = 0; i < nombre; i++)
        {
            GameObject r = Instantiate(railPrefab, transform);
            r.transform.localPosition = new Vector3(0, 0, i * longueur);
            r.transform.localScale = Vector3.one * echelle;
        }
    }
}