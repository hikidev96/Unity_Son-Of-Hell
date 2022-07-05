using UnityEngine;
using Animancer;

namespace SOD
{
    public class IKController : MonoBehaviour
    {
        [SerializeField] private AnimancerComponent animancer;
        [SerializeField] private IKTarget rightHandIKTarget;

        private void OnEnable()
        {
            animancer.Layers[0].ApplyAnimatorIK = true;
        }

        private void OnAnimatorIK(int layerIndex)
        {
            rightHandIKTarget.UpdateAnimatorIK(animancer.Animator);
        }
    }
}