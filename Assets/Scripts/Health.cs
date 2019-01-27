using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STG_Demo
{
    /// <summary>
    /// 血量控制
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// 初始血量
        /// </summary>
        public int startingHealth = 1;

        /// <summary>
        /// 当前血量
        /// </summary>
        public int currentHealth;

        /// <summary>
        /// 
        /// </summary>
        private bool isDead;

        /// <summary>
        /// 是否收到攻击
        /// </summary>
        private bool damaged;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Awake()
        {
            this.currentHealth = this.startingHealth;
        }

        // Update is called once per frame
        void Update()
        {
            if (damaged)
            {
                // damageImage.color = flashColour;
                // TODO 播放被攻击的特效
            }
            else
            {
                // damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
                // TODO 恢复未被攻击的状态
            }
            damaged = false;
        }

        /// <summary>
        /// 收到攻击
        /// </summary>
        /// <param name="amount"></param>
        public void TakeDamage(int amount)
        {
            if (isDead)
                return;

            damaged = true;
            this.currentHealth -= amount;
            // TODO 播放被攻击的音效
            // playerAudio.Play();

            if (currentHealth <= 0 && !isDead)
            {
                // 目标死亡
                Death();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void Death()
        {
            isDead = true;
            // TODO 播放死亡特效

            //playerShooting.DisableEffects();

            //anim.SetTrigger("Die");

            //playerAudio.clip = deathClip;
            //playerAudio.Play();

            //playerMovement.enabled = false;
            //playerShooting.enabled = false;

            // 掉落物品
            DropItem dropItem = GetComponent<DropItem>();
            if (dropItem != null)
            {
                dropItem.Drop();
            }

            Destroy(gameObject);
        }
    }
}