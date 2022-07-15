using System.Collections.Generic;
using UnityEngine;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/ScriptableObjectSet")]
    public class ScriptableObjectSet : ScriptableObject
    {
        [SerializeField] List<ScriptableObject> scriptableObjects;

        private List<ScriptableObject> copyOfScriptableObjects = new List<ScriptableObject>();

        private void OnEnable()
        {
            copyOfScriptableObjects.Clear();
            scriptableObjects.ForEach((item) =>
            {
                copyOfScriptableObjects.Add(item);
            });
        }

        public T Get<T>() where T : ScriptableObject
        {
            if (scriptableObjects == null)
            {
                return null;
            }

            var result = copyOfScriptableObjects[Random.Range(0, copyOfScriptableObjects.Count)] as T;

            copyOfScriptableObjects.Remove(result);

            return result;
        }
    }
}
