using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace SOD
{
    public class Timer
    {
        private float current;

        public float Current => current;

        public void StartTimer(float duration, TweenCallback callback)
        {
            var tweener = DOTween.To(() => current, (x) => current = x, duration, duration);
            tweener.onComplete += callback;
            tweener.onComplete += () => current = 0;
        }
    }
}
