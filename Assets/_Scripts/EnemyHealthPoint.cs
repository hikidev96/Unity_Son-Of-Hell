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

        private Tweener scaleAnimationTweener;
        private Tweener colorAnimationTweener;

        public EnemyHealthPoint(Enemy enemy, float maxHP) : base(maxHP)
        {

        }

        public override void Damage(DamageData damageData)
        {
            base.Damage(damageData);

            SpawnDamageFX();
            PlayScaleAnimation();
            PlayOutlineAnimation();
            ServiceProvider.CameraService.Shake();
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

            enemy.transform.localScale = Vector3.one;
            scaleAnimationTweener = enemy.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.2f);
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