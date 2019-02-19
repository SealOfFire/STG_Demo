using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STG_Demo.Colliders
{
    /// <summary>
    /// 拾取物品
    /// </summary>
    public class Pickup : MonoBehaviour
    {
        public Player player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Item"))
            {
                Debug.Log("拾取物品");
                // 物品被玩家拾取
                Item item = other.gameObject.GetComponent<Item>();

                this.player.PowerUp(item.level);

                // 毁灭item
                Destroy(other.gameObject);
            }
        }
    }
}