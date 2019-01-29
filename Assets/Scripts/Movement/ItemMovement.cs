using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STG_Demo.Movement
{
    /// <summary>
    /// 物品移动
    /// </summary>
    public class ItemMovement : MonoBehaviour
    {
        /// <summary>
        /// 改变方向的间隔时间
        /// </summary>
        public Vector2 intervalTime = new Vector2(2, 8);

        /// <summary>
        /// 在场景中的停留时间
        /// </summary>
        public float stayTime = 20f;

        /// <summary>
        /// 移动速度
        /// </summary>
        public float speed = 5;

        private Rigidbody rb;
        private float totalTime;
        private Vector3 target; // 移动到的目标位置

        private void Awake()
        {
            this.rb = this.GetComponent<Rigidbody>();
        }

        // Start is called before the first frame update
        void Start()
        {
            this.rb.velocity = this.rb.transform.forward * this.speed;
            // this.rb.velocity = new Vector3(0,0,100) * this.speed;
            StartCoroutine(Evade());
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            this.totalTime += Time.deltaTime;
            // this.rb.position = Vector3.MoveTowards(this.rb.position, this.target, Time.deltaTime * this.speed);
            // Debug.Log(this.target);
            // this.rb.MovePosition(this.rb.position + this.target * this.speed);
            this.rb.velocity = this.target;
        }

        /// <summary>
        /// 间隔时间修改移动方向
        /// </summary>
        /// <returns>The evade.</returns>
        IEnumerator Evade()
        {
            while (true)
            {
                if (this.totalTime >= this.stayTime)
                {
                    Debug.Log("移动到屏幕外");
                    // 移动到屏幕外
                    // 不修改移动方向，直到移动到屏幕外 
                    yield return new WaitForSeconds(30);
                }
                else
                {
                    // 间隔一段时间，修改一次移动方向
                    // 调整移动方向
                    Debug.Log("调整移动方向");
                    // 
                    // this.target = new Vector3(this.);
                    // Mathf.Sign(this.rb.velocity.z);
                    //Random.Range(0, 1);
                    this.target = new Vector3(Random.Range(0, 1000) * -Mathf.Sign(this.target.x), 0, Random.Range(0, 1000) * -Mathf.Sign(this.target.z));
                    // Debug.Log("1:" + this.target);
                    this.target = Vector3.Normalize(this.target) * this.speed;
                    // Debug.Log("2:" + this.target);
                    // this.rb.velocity = this.target;
                    // this.target = Vector3.Normalize(this.target);
                    // 设置间隔时间
                    yield return new WaitForSeconds(Random.Range(this.intervalTime.x, this.intervalTime.y));
                }
            }
        }
    }
}