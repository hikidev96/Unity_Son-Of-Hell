using UnityEngine;

namespace SOD
{
    public static class BootStrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void CreateNeededObjectsBeforeSceneLoad()
        {
            var serviceProviderPrefab = Resources.Load<GameObject>("ServiceProvider");
            var serviceProviderObj = GameObject.Instantiate(serviceProviderPrefab);
            GameObject.DontDestroyOnLoad(serviceProviderObj);
        }
    }
}
