using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STG_Demo.Colliders
{
    // 拾取物品
    public class Pickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Item"))
            {
                // TODO 被敌人的子弹击中
                Debug.Log("拾取物品");
            }
        }
    }
}