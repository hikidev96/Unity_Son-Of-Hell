using UnityEngine;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/PlayerData/DashData")]
    public class PlayerDashData : ScriptableObject
    {
        private float dashTime;
        private float dashSpeed;
        private float dashCoolTime;
        private Timer dashCoolTimer;

        public float DashSpeed => dashSpeed;
        public float DashTime => dashTime;
        public float DashCoolTime => dashCoolTime;        
        public Timer DashCoolTimer => dashCoolTimer;        

        private void OnEnable()
        {
            dashTime = 0.25f;
            dashSpeed = 25.0f;
            dashCoolTime = 1.0f;
            dashCoolTimer = new Timer();
        }
    }
}