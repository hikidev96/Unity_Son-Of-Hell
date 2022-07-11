using UnityEngine;
using DG.Tweening;

namespace SOD
{
    public class HandController : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private Transform fireTrans;
        [SerializeField] private Hand hand;
        [SerializeField] private GameObject rightHandIKTarget;
        [SerializeField] private GameObject rightHand;

        private Tweener recoilAnimationTweener;

        public void TryAttack()
        {
            if (hand == null)
            {
                return;
            }

            if (hand.IsReadyToFire == false)
            {
                return;
            }

            Attack();
            PlayRecoilAnimation();
        }

        private void PlayRecoilAnimation()
        {
            recoilAnimationTweener.ForceInit();
            recoilAnimationTweener = rightHandIKTarget.transform.DOLocalMoveY(rightHandIKTarget.transform.localPosition.y + 1.0f, 0.02f);
            recoilAnimationTweener.onComplete = () => rightHandIKTarget.transform.DOLocalMoveY(rightHandIKTarget.transform.localPosition.y - 1.0f, 0.1f);
        }

        private void Attack()
        {
            ServiceProvider.CameraService.Shake(1.0f);
            hand.Fire(fireTrans);
        }

        private void OnDrawGizmos()
        {
            if (fireTrans == null)
            {
                return;
            }

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(fireTrans.position, 0.3f);
        }
    }
}