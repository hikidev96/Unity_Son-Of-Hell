using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace SOD
{
    public class HandController : MonoBehaviour
    {
        [SerializeField] private Transform fireTrans;
        [SerializeField] private GameObject rightHandIKTarget;
        [SerializeField] private GameObject rightHand;
        [SerializeField] private PlayerHandData playerHandData;

        private Hand hand;
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

        public void SetHandPrefab(GameObject handPrefab)
        {
            var hand = Instantiate(handPrefab, this.transform).GetComponent<Hand>();
            SetHand(hand);  
        }

        private void SetHand(Hand hand)
        {
            playerHandData.Hand = hand;
            this.hand = hand;
        }

        private void Attack()
        {
            ServiceProvider.CameraService.Shake(1.0f);
            hand.Fire(fireTrans);
        }

        private void PlayRecoilAnimation()
        {
            recoilAnimationTweener.ForceInit();
            recoilAnimationTweener = rightHandIKTarget.transform.DOLocalMoveY(rightHandIKTarget.transform.localPosition.y + 1.0f, 0.02f);
            recoilAnimationTweener.onComplete = () => rightHandIKTarget.transform.DOLocalMoveY(rightHandIKTarget.transform.localPosition.y - 1.0f, 0.1f);
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