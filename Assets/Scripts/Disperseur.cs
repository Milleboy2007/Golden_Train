using UnityEngine;

public class Disperseur : MonoBehaviour
{
    public GameObject objet;
    public int nombre = 400;
    public float largeur = 800f;
    public float longueur = 1000f;
    public float couloirVoie = 8f;

    [ContextMenu("Disperser")]
    void Disperser()
    {
        for (int k = transform.childCount - 1; k >= 0; k--)
            DestroyImmediate(transform.GetChild(k).gameObject);

        Terrain terrain = Terrain.activeTerrain;
        int cree = 0;
        while (cree < nombre)
        {
            float x = Random.Range(-largeur / 2, largeur / 2);
            if (Mathf.Abs(x) < couloirVoie) continue;   // on évite la voie
            float z = Random.Range(-longueur / 2, longueur / 2);

            // SampleHeight donne la hauteur du terrain à cet endroit : le cactus se pose sur la dune
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.transform.position.y;

            GameObject o = Instantiate(objet, new Vector3(x, y, z),
                                       Quaternion.Euler(0, Random.Range(0, 360), 0), transform);
            o.transform.localScale *= Random.Range(0.8f, 1.4f);
            cree++;
        }
    }
}