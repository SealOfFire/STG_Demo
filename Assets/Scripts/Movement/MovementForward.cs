using UnityEngine;

namespace STG_Demo.Movement
{
    /// <summary>
    /// 向前移动
    /// </summary>
    public class MovementForward : MonoBehaviour
    {

        private Rigidbody rb;
        private Enemy enemy;

        private void Awake()
        {
            this.rb = this.GetComponent<Rigidbody>();
            this.enemy = this.gameObject.GetComponent<Enemy>();
        }

        // Start is called before the first frame update
        void Start()
        {
            this.rb.velocity = transform.forward * this.enemy.speed;
        }

    }
}