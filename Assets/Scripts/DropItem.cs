using UnityEngine;

namespace STG_Demo
{
    /// <summary>
    /// 掉落物品
    /// </summary>
    public class DropItem : MonoBehaviour
    {
        public Item item;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 掉落物品
        /// </summary>
        public void Drop()
        {
            Instantiate(this.item, this.transform.position, this.transform.rotation);
        }

    }
}