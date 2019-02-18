using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STG_Demo.PlayerCollied
{
    // 被攻击
    public class Attacked : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy Bullet"))
            {
                // TODO 被敌人的子弹击中
                Debug.Log("被敌人的子弹击中");
            }
        }
    }
}