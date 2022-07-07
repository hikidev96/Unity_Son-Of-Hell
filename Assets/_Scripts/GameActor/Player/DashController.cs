using System.Collections;
using UnityEngine;

namespace SOD
{
    public class DashController : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;       
        [SerializeField] private CharacterController characterController;
        [SerializeField] private TrailGenerator trailGenerator;
        [SerializeField] private Animator animator;
        [SerializeField] private float TEMP_dashTime = 0.25f; // should be in playerData
        [SerializeField] private float TEMP_dashSpeed = 50.0f; // should be in playerData        

        private bool isDashing;

        public void TryDash()
        {
            if (isDashing == true)
            {
                return;
            }

            StartCoroutine(Dash());
        }

        private IEnumerator Dash()
        {
            isDashing = true;
            DisableRootMotion();
            EnableTrail();
            var dashStartTime = Time.time;
            var dirToDash = GetDirToDash();
            while (dashStartTime + TEMP_dashTime > Time.time)
            {
                characterController.SimpleMove(dirToDash * TEMP_dashSpeed);
                yield return null;
            }
            EnableRootMotion();
            DisableTrail();
            isDashing = false;
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
