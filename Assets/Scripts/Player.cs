﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STG_Demo
{
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// 移动速度
        /// </summary>
        public float moveSpeed = 10;

        /// <summary>
        /// 子弹的prefab
        /// </summary>
        public GameObject shot;

        /// <summary>
        /// 发射子弹的位置
        /// </summary>
        public Transform[] shotSpawns;

        /// <summary>
        /// 武器威力等级
        /// </summary>
        public int PowerLevel = 1;

        private Rigidbody playerRigidbody;
        private Vector3 movement; // The vector to store the direction of the player's movement.
        public float fireRate; // 每次射击的间隔
        private float nextFire; // 距离下一次射击的间隔

        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            this.playerRigidbody = this.GetComponent<Rigidbody>();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                foreach (Transform shotSpawn in this.shotSpawns)
                {
                    Instantiate(this.shot, shotSpawn.position, shotSpawn.rotation);
                }
                // GetComponent<AudioSource>().Play();
                // TODO 播放设计音效
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void FixedUpdate()
        {
            // 获取移动的幅度（0f~1f）
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            // Move the player around the scene.
            this.Move(h, v);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /*
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy Bullet"))
            {
                // TODO 被敌人的子弹击中
                Debug.Log("被敌人的子弹击中");
            }
        }
        */

        /// <summary>
        /// 移动自机
        /// </summary>
        /// <param name="h"></param>
        /// <param name="v"></param>
        private void Move(float h, float v)
        {
            // TODO 设置移动速度

            // Set the movement vector based on the axis input.
            this.movement.Set(h, 0f, v);

            // Normalise the movement vector and make it proportional to the speed per second.
            this.movement = movement.normalized * this.moveSpeed * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            this.playerRigidbody.MovePosition(transform.position + movement);
        }

        /// <summary>
        /// 武器威力提升
        /// </summary>
        public void PowerUp(int level)
        {
            this.PowerLevel += level;
            Debug.Log("PowerUp:" + this.PowerLevel);
        }
    }
}
