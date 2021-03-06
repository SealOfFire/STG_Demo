﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STG_Demo
{
    /// <summary>
    /// 敌人管理
    /// </summary>
    public class EnemyManager : MonoBehaviour
    {
        // public PlayerHealth playerHealth;
        public GameObject[] enemys;
        public float spawnTime = 10f;
        public Transform[] spawnPoints;

        // 是否已经刷出这波敌人
        private struct Wave
        {
            public string MethodName;
            public int AppearTime;
            public Wave(string MethodName, int AppearTime)
            {
                this.MethodName = MethodName;
                this.AppearTime = AppearTime;
            }
        }

        private Wave[] waves = { new Wave("FirstWave", 2), new Wave("SecondWave", 5), new Wave("ThirdWave", 10), new Wave("BossWave", 12) };

        //private int index = 0;

        // Start is called before the first frame update
        private void Start()
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);

            foreach (Wave wave in this.waves)
            {
                Invoke(wave.MethodName, wave.AppearTime);
            }
        }

        private void Awake()
        {

        }

        /// <summary>
        /// 创建第1波敌人
        /// 普通敌人
        /// </summary>
        private void FirstWave()
        {
            Debug.Log("创建第1波敌人");
        }

        /// <summary>
        /// 创建第2波敌人
        /// pow up掉落
        /// </summary>
        private void SecondWave()
        {
            Debug.Log("创建第2波敌人");
            Instantiate(this.enemys[1], this.spawnPoints[2].position, this.spawnPoints[2].rotation);
        }

        /// <summary>
        /// 创建第3波敌人
        /// 普通敌人
        /// </summary>
        private void ThirdWave()
        {
            Debug.Log("创建第3波敌人");
        }

        /// <summary>
        /// 创建boss
        /// </summary>
        private void BossWave()
        {
            Debug.Log("创建第BOSS");
        }

        // Update is called once per frame
        private void Spawn()
        {
            Instantiate(enemys[0], spawnPoints[0].position, spawnPoints[0].rotation);
            Instantiate(enemys[0], spawnPoints[1].position, spawnPoints[1].rotation);
        }
    }
}