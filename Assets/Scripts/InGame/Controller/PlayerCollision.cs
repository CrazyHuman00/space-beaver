using System.Collections;
using System.Collections.Generic;
using Common.Model;
using UnityEngine;

using InGame.Model;

namespace InGame.Controller
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private string starTag = "Star";
        [SerializeField] private GameObject player;
        [SerializeField] private new SpriteRenderer renderer;
        [SerializeField] private CapsuleCollider2D capsuleCollider2D;
        [SerializeField] private int loopCount;
        [SerializeField] private float flashInterval;
        PlayerLifeModel playerLifeModel = new();

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
            playerLifeModel = GameObject.Find("PlayerLife").GetComponent<PlayerLifeModel>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(starTag) && !isHit)
            {
                state = STATE.DAMAGED;
                playerLifeModel.playerLifeCount();
                StartCoroutine(OnDamageEffect());
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