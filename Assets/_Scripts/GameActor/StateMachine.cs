using UnityEngine;

namespace SOD
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private bool showLog;

        private State startState;
        private State currentState;

        protected virtual void Awake()
        {

        }

        protected virtual void Start()
        {
            currentState = startState;
            startState?.Enter();
        }

        protected virtual void Update()
        {
            if (showLog == true)
            {
                Debug.Log(currentState.GetType());
            }

            currentState?.Update();
        }

        protected virtual void FixedUpdate()
        {
            currentState?.FixedUpdate();
        }

        public void ChangeState(State to)
        {
            currentState?.Exit();

            to?.Enter();

            currentState = to;
        }

        protected void SetStartState(State startState)
        {
            this.startState = startState;
        }
    }
}
