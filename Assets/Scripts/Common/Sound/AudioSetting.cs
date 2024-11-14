using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Common.Sound
{
    public class AudioSetting : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [FormerlySerializedAs("BGMSlider")] [SerializeField] Slider bgmSlider;
        [FormerlySerializedAs("SESlider")] [SerializeField] Slider seSlider;

        private void Start()
        {
            //BGM
            audioMixer.GetFloat("BGM", out var bgmVolume);
            bgmSlider.value = bgmVolume;
            //SE
            audioMixer.GetFloat("SE", out var seVolume);
            seSlider.value = seVolume;
        }

        public void SetBGM(float volume)
        {
            audioMixer.SetFloat("BGM", volume);
        }

        public void SetSe(float volume)
        {
            audioMixer.SetFloat("SE", volume);
        }
    }
}