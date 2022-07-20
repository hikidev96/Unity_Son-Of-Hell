using UnityEngine;
using DG.Tweening;

namespace SOD
{
    [System.Serializable]
    public class PlayerHealthPoint : HealthPoint
    {
        [SerializeField] private HitBox hitbox;
        [SerializeField] private Player player;
        [SerializeField] private Renderer renderer;
        [SerializeField] private PlayerHealthPointData healthPointData;

        private Tweener colorAnimationTweener;

        public override void Init()
        {
            base.Init();

            hitbox.OnHit.AddListener((hitData) => Damage(hitData.DamageData));            
        }

        public override void Damage(DamageData damageData)
        {
            if (IsDead == true)
            {
                return;
            }

            if (healthPointData.CurrentHp <= 0.0f)
            {
                healthPointData.IsDead = true;
                OnDie.Invoke();
            }

            healthPointData.CurrentHp -= damageData.Damage;
            PlayOutlineAnimation();
            ServiceProvider.CameraService.Damage();
            ServiceProvider.CameraService.Shake();
            ServiceProvider.UIService.SpawnDamageUI(damageData, player.GetActorPart(EActorPart.Top));
        }

        private void PlayOutlineAnimation()
        {
            if (colorAnimationTweener != null)
            {
                colorAnimationTweener.Kill();
            }

            renderer.material.SetColor("_MainColor", Color.red);
            colorAnimationTweener = DOTween.To(() => renderer.material.GetColor("_MainColor"), (x) => renderer.material.SetColor("_MainColor", x), Color
                .white, 0.5f);
        }
    }
}