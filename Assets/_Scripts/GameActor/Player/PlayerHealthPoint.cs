using UnityEngine;
using DG.Tweening;

namespace SOD
{
    public class PlayerHealthPoint : HealthPoint
    {
        [SerializeField] private HitBox hitbox;
        [SerializeField] private Player player;
        [SerializeField] private Renderer view;
        [SerializeField] private PlayerHealthPointData healthPointData;

        private Tweener colorAnimationTweener;

        public override void Init()
        {
            base.Init();

            hitbox.OnHit.AddListener((hitData) => Damage(hitData.DamageData));            
        }

        public override void Damage(DamageData damageData)
        {
            if (healthPointData.IsDead == true)
            {
                return;
            }

            healthPointData.CurrentHp -= damageData.Damage;
            PlayOutlineAnimation();
            ServiceProvider.CameraService.Damage();
            ServiceProvider.CameraService.Shake();
            ServiceProvider.UIService.SpawnDamageUI(damageData, player.ActorParts.GetPart(EActorPart.Top));

            if (healthPointData.CurrentHp <= 0.0f)
            {
                healthPointData.IsDead = true;
                healthPointData.CurrentHp = 0.0f;
                OnDie.Invoke();
            }
        }

        private void PlayOutlineAnimation()
        {
            if (colorAnimationTweener != null)
            {
                colorAnimationTweener.Kill();
            }

            view.material.SetColor("_MainColor", Color.red);
            colorAnimationTweener = DOTween.To(() => view.material.GetColor("_MainColor"), (x) => view.material.SetColor("_MainColor", x), Color
                .white, 0.5f);
        }
    }
}