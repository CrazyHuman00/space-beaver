using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Common.Sound
{
    public class AudioSetting : MonoBehaviour
    {
        [SerializeField] AudioMixer audioMixer;
        [SerializeField] Slider BGMSlider;
        [SerializeField] Slider SESlider;

        private void Start()
        {
            //BGM
            audioMixer.GetFloat("BGM", out float bgmVolume);
            BGMSlider.value = bgmVolume;
            //SE
            audioMixer.GetFloat("SE", out float seVolume);
            SESlider.value = seVolume;
        }

        public void SetBGM(float volume)
        {
            audioMixer.SetFloat("BGM", volume);
        }

        public void SetSE(float volume)
        {
            audioMixer.SetFloat("SE", volume);
        }
    }
}