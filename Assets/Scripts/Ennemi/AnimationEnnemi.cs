using System.Data.Common;
using UnityEngine;

public class AnimationEnnemi : MonoBehaviour
{
    [SerializeField] private EnnemiData data;
    private Animator animator;

    void Awake()
    {
        data = GetComponent<EnnemiData>();
        animator.runtimeAnimatorController = data.animControl;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attaquer()
    {
        if(data is EnnemiBatte batteData)
        {

        }
        else if (data is EnnemiWinchester winchesterData)
        {
            
        }
    }
}
