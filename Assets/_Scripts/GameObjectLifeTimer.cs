using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SOD
{
    public class GameObjectLifeTimer : MonoBehaviour
    {
        [SerializeField] private float lifeTime;
        [SerializeField] private bool onStart;

        [SerializeField] private UnityEvent onLifeOver = new UnityEvent();

        public UnityEvent OnLifeOver => onLifeOver;

        private void Start()
        {
            if (onStart == true)
            {
                StartCountingLifeTime();
            }
        }

        public void StartCountingLifeTime()
        {
            StartCoroutine(CountLifeTime());
        }

        IEnumerator CountLifeTime()
        {
            yield return new WaitForSeconds(lifeTime);

            onLifeOver?.Invoke();
        }
    }
}
