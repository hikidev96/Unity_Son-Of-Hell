using System.Collections.Generic;
using UnityEngine;

namespace SOD
{
    public enum ESoundType
    {
        FX,
        BGM,
    }

    [CreateAssetMenu(menuName = "SOD/AudioData")]
    public class AudioData : ScriptableObject
    {
        [SerializeField] private ESoundType soundType;
        [SerializeField] private List<AudioClip> clips;

        public ESoundType SoundType => soundType;

        public AudioClip GetClip()
        {
            return clips[Random.Range(0, clips.Count)];
        }
    }
}
