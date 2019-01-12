using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STG_Demo
{
    /// <summary>
    /// 内部范围，进入范围内的物体可以被攻击破坏
    /// </summary>
    public class InneBoundary : MonoBehaviour
    {
        /// <summary>
        /// 离开边界
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("敌人离开作战范围");
                // 设置敌人不可以被攻击
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.enable = false;
                }
            }
        }

        /// <summary>
        /// 进入作战范围
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("敌人进入作战范围");
                // 设置敌人可以被攻击
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.enable = true;
                }
            }
        }

    }
}