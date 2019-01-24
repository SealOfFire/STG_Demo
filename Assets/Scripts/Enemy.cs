using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STG_Demo
{
    /// <summary>
    /// 敌人
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        public float speed = 12;
        public bool enable = false;

        public bool HP;

        // private Rigidbody enemyRigidbody;

        private void Awake()
        {
            // this.enemyRigidbody = this.GetComponent<Rigidbody>();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            // 移动改为使用移动脚本
            // GetComponent<Rigidbody>().velocity = transform.forward * this.speed;
            // this.gameObject.SetActive(false);
        }

        /// <summary>
        /// 
        /// </summary>
        private void FixedUpdate()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (this.enable)
            {
                switch (other.tag)
                {
                    case "Player":
                        // 撞到玩家
                        Debug.Log("撞到玩家");
                        // TODO 消灭玩家
                        break;
                    case "Player Bullet":
                        // 被玩家子弹击中
                        Debug.Log("被玩家子弹击中");
                        // 消灭玩家子弹
                        Destroy(other.gameObject);
                        // 消灭自身
                        Destroy(this.gameObject);
                        break;
                        //case "Boundary":
                        //    // 碰到边框
                        //    Debug.Log("碰到边框");
                        //    // TODO 消灭自身
                        //    break;
                }
            }
        }

    }
}