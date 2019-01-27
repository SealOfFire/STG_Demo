using UnityEngine;

namespace STG_Demo
{
    /// <summary>
    /// 物品
    /// </summary>
    public class Item : MonoBehaviour
    {
        /// <summary>
        /// 武器提升等级
        /// </summary>
        public int level = 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Debug.Log("物品被玩家拾取");
                // 物品被玩家拾取
                Player player = other.gameObject.GetComponent<Player>();
                player.PowerUp(this.level);

                // 消灭自身
                Destroy(this.gameObject);
            }
        }

    }
}