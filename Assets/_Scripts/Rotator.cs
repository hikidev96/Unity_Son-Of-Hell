using UnityEngine;
using UnityEngine.InputSystem;

namespace SOD
{
    public class Rotator
    {
        private float rotationSpeed = 0.5f;
        private Transform rotatorTrans;

        public Rotator(Transform rotatorTrans)
        {
            this.rotatorTrans = rotatorTrans;
        }

        public void RotateSmoothly(Vector3 dir, bool considerCamera = false)
        {
            var goalRot = GetGoalRot(dir, considerCamera);
            rotatorTrans.rotation = Quaternion.Slerp(rotatorTrans.rotation, goalRot, rotationSpeed);
        }

        public void RotateDirectly(Vector3 dir, bool considerCamera = false)
        {
            var goalRot = GetGoalRot(dir, considerCamera);
            rotatorTrans.rotation = goalRot;
        }

        public void RotateTowardMouse(bool considerCamera = true)
        {
            var mouseViewportPos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
            var rotatorViewportPos = Camera.main.WorldToViewportPoint(rotatorTrans.position);
            var dirTowardingMouse = (mouseViewportPos - rotatorViewportPos).normalized;

            RotateDirectly(new Vector3(dirTowardingMouse.x, 0.0f, dirTowardingMouse.y), considerCamera);
        }

        private Quaternion GetGoalRot(Vector3 dir, bool considerCamera = false)
        {
            return Quaternion.LookRotation(dir) * GetCameraRot(considerCamera);
        }

        private Quaternion GetCameraRot(bool considerCamera)
        {
            return considerCamera ? Quaternion.Euler(new Vector3(0.0f, Camera.main.transform.rotation.eulerAngles.y, 0.0f)) : Quaternion.Euler(Vector3.zero);
        }
    }
}