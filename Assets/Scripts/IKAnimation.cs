using UnityEngine;

[RequireComponent(typeof(Animator))]

public class IKAnimation : MonoBehaviour
{
    [SerializeField] private Animator animatorGO;

    [SerializeField] private Transform hand;
    [SerializeField] private Transform look;

    [SerializeField] private float righthandWeight = 1;
    [SerializeField] private bool ikActive;
    
    void Start()
    {
        animatorGO = GetComponent<Animator>();
    }
    private void OnAnimatorIk(int layerIndex)
    {
        if (ikActive)
        {
            if (hand)
            {
                animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, righthandWeight);
                animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, righthandWeight);

                animatorGO.SetIKPosition(AvatarIKGoal.RightHand, hand.position);
                animatorGO.SetIKRotation(AvatarIKGoal.RightHand, hand.rotation);
            }

            if (look)
            {
                animatorGO.SetLookAtWeight(1);
                animatorGO.SetLookAtPosition(look.position);
            }
        }
        else
        {
            animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animatorGO.SetLookAtWeight(0);
        }
    }
}
