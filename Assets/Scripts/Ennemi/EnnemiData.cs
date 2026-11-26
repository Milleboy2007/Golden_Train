using UnityEngine;

public abstract class EnnemiData : ScriptableObject
{
    [Header("Visuel & Animation")]
    public RuntimeAnimatorController animControl;
    public GameObject prefabArme;

    [Header("Combat")]
    public int vieMax = 100;
    public float vitesse = 3.5f;
    public float cooldownAttaque = 1.5f;
    public float distanceDetection = 10f;
}

[CreateAssetMenu(fileName = "EnnemiData", menuName = "Scriptable Objects/EnnemiBatte")]
public class EnnemiBatte: EnnemiData
{
    [Header("Stat de batte")]
    public int degat = 20;
    public float attackRange = 2f;
    public float distanceSuivie = 2f;
}

[CreateAssetMenu(fileName = "EnnemiData", menuName = "Scriptable Objects/EnnemiWinchester")]
public class EnnemiWinchester: EnnemiData
{
    [Header("Winchester State")]
    public float fireRange = 10f;
}