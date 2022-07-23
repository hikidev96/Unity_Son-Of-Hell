using System.Collections;
using UnityEngine;

namespace SOD
{
    public class DashController : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationData playerData;       
        [SerializeField] private CharacterController characterController;
        [SerializeField] private TrailGenerator trailGenerator;
        [SerializeField] private UnityEngine.Animator animator;
        [SerializeField] private PlayerDashData playerDashData;
        
        private bool isDashable = true;

        public void TryDash()
        {
            if (isDashable == false)
            {
                return;
            }

            StartCoroutine(Dash());
        }

        private IEnumerator Dash()
        {
            isDashable = false;
            DisableRootMotion();
            EnableTrail();
            StartDashCoolTimer();
            var dashStartTime = Time.time;
            var dirToDash = GetDirToDash();
            while (dashStartTime + playerDashData.DashTime > Time.time)
            {
                characterController.SimpleMove(dirToDash * playerDashData.DashSpeed);
                yield return null;
            }
            EnableRootMotion();
            DisableTrail();            
        }

        private void StartDashCoolTimer()
        {
            playerDashData.DashCoolTimer.StartTimer(playerDashData.DashCoolTime, () => isDashable = true);
        }

        private Vector3 GetDirToDash()
        {
            if (ServiceProvider.InputService.MovementValue == Vector3.zero)
            {
                return characterController.transform.forward;
            }

            return Quaternion.Euler(0.0f, Camera.main.transform.rotation.eulerAngles.y, 0.0f) * ServiceProvider.InputService.MovementValue;
        }
        
        private void DisableRootMotion()
        {
            animator.applyRootMotion = false;
        }

        private void EnableRootMotion()
        {
            animator.applyRootMotion = true;
        }

        private void DisableTrail()
        {
            trailGenerator.StopTrail();
        }

        private void EnableTrail()
        {
            trailGenerator.StartTrail();
        }
    }
}
