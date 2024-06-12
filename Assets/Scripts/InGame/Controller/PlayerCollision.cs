using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

using InGame.Model;
using Common.Sound;
using Common.View;

namespace InGame.Controller
{
    /// <summary>
    /// Playerの当たり判定
    /// <summary>
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private new SpriteRenderer renderer;
        [SerializeField] private CapsuleCollider2D capsuleCollider2D;
        [SerializeField] private int loopCount;
        [SerializeField] private float flashInterval;
        private PlayerLifeModel playerLifeModel;
        private FadeSceneLoader fadeSceneLoader;
        private DamagedSoundEffect damagedSoundEffect;
        private ItemSoundEffect itemSoundEffect;

        private bool isHit = false;

        //プレイヤーの状態用列挙型（ノーマル、ダメージ、無敵の3種類）
        enum STATE
        {
            NORMAL,
            DAMAGED,
            INVINCIBLE
        }

        private STATE state;

        private void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            capsuleCollider2D = GetComponent<CapsuleCollider2D>();
            itemSoundEffect = GetComponent<ItemSoundEffect>();
            damagedSoundEffect = GetComponent<DamagedSoundEffect>();
            fadeSceneLoader = GameObject.Find("Canvas").GetComponent<FadeSceneLoader>();
            playerLifeModel = GameObject.Find("PlayerLife").GetComponent<PlayerLifeModel>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Star") && !isHit)
            {
                state = STATE.DAMAGED;

                if (playerLifeModel.playerLifePoint > 1)
                {
                    damagedSoundEffect.StarSoundTrigger();
                    playerLifeModel.playerLifeCount();
                }
                else
                {
                    fadeSceneLoader.CallCoroutine("GameOver");
                }

                StartCoroutine(OnDamageEffect());
            }

            if (itemSoundEffect != null)
            {
                if (other.gameObject.CompareTag("Sawagani"))
                {
                    itemSoundEffect.SawaganiSoundTrigger();
                }
                else if (other.gameObject.CompareTag("Koyadofu"))
                {
                    itemSoundEffect.KoyadofuSoundTrigger();
                }
                else if (other.gameObject.CompareTag("Wood"))
                {
                    itemSoundEffect.WoodSoundTrigger();
                }
            }
            else
            {
                Debug.LogWarning("ItemSoundEffect component is missing or not set.");
            }
        }


        private IEnumerator OnDamageEffect()
        {
            isHit = true;
            capsuleCollider2D.enabled = false;
            renderer.color = Color.black;

            //点滅ループ開始
            for (int i = 0; i < loopCount; i++)
            {
                yield return new WaitForSeconds(flashInterval);
                renderer.enabled = false;
                yield return new WaitForSeconds(flashInterval);
                renderer.enabled = true;

                if (i > 20)
                {
                    state = STATE.INVINCIBLE;
                    renderer.color = Color.green;
                }
            }

            state = STATE.NORMAL;
            capsuleCollider2D.enabled = true;
            renderer.color = Color.white;
            isHit = false;
        }

    }

}