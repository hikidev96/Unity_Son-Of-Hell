using UnityEngine;
using DG.Tweening;

namespace SOD
{
    public class NormalAttackController : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private Transform fireTrans;
        [SerializeField] private NormalAttack attack;
        [SerializeField] private GameObject rightHandIKTarget;
        [SerializeField] private GameObject rightHand;

        private Tweener recoilAnimationTweener;

        public void TryAttack()
        {
            if (attack == null)
            {
                return;
            }

            if (attack.IsReadyToFire == false)
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
            attack.DoAttack(fireTrans);
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