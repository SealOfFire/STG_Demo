using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STG_Demo
{
    /// <summary>
    /// 子弹
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        /// <summary>
        /// 子弹的移动速度
        /// </summary>
        public float speed = 15;

        private void Start()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * this.speed;
        }
    }
}
