using UnityEngine;
using DG.Tweening;

namespace SOD
{
    [System.Serializable]
    public class EnemyHealthPoint : HealthPoint
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private PrefabSet damageFXPrefabs;
        [SerializeField] private Renderer renderer;
        [SerializeField] private HitBox hitbox;

        private Tweener scaleAnimationTweener;
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

            base.Damage(damageData);

            SpawnDamageFX();
            PlayScaleAnimation();
            PlayOutlineAnimation();
            enemy.Forcer.AddForce(enemy.transform.forward * -1, 10.0f);
            ServiceProvider.CameraService.Shake();
            ServiceProvider.UIService.SpawnDamageUI(damageData, enemy.GetActorPart(EActorPart.Top));
        }

        private void SpawnDamageFX()
        {
            GameObject.Instantiate(damageFXPrefabs.Get(), enemy.GetActorPart(EActorPart.Middle), Quaternion.identity);
        }

        private void PlayScaleAnimation()
        {
            if (scaleAnimationTweener != null)
            {
                scaleAnimationTweener.Kill();
            }

            renderer.transform.localScale = Vector3.one;
            scaleAnimationTweener = renderer.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.2f);
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

        public void DisableHitBox()
        {
            hitbox.gameObject.SetActive(false);
        }
    }
}