using UnityEngine;

namespace STG_Demo.Movement
{
    /// <summary>
    /// 在屏幕中悬停以断事件后，移除屏幕
    /// </summary>
    public class Hover : MonoBehaviour
    {
        /// <summary>
        /// 目标位置
        /// </summary>
        public Vector3 target = new Vector3(0, 100, 30);
        public float swing = 20;
        public float moveOutTime = 10;

        private Rigidbody rb;
        private Enemy enemy;
        private Vector3 t1, t2;
        private bool moveLeft = true, moveRight = false;
        private float timer = 0;

        private void Awake()
        {
            this.rb = this.GetComponent<Rigidbody>();
            this.enemy = this.gameObject.GetComponent<Enemy>();
        }

        // Start is called before the first frame update
        void Start()
        {
            this.t1 = new Vector3(this.target.x - this.swing, target.y, target.z);
            this.t2 = new Vector3(this.target.x + this.swing, target.y, target.z);
        }

        private void FixedUpdate()
        {
            this.timer += Time.deltaTime;
            //float newManeuver = Mathf.MoveTowards(this.rb.velocity.z, target.z, Time.deltaTime);
            //this.rb.velocity = new Vector3(newManeuver, 0.0f, this.enemy.speed);
            //this.rb.position = new Vector3(this.rb.position.x,this.rb.position.y, );
            if (this.timer < this.moveOutTime)
            {
                if (this.rb.position.z > this.target.z)
                {
                    this.rb.position = Vector3.MoveTowards(this.rb.position, target, Time.deltaTime * enemy.speed);
                }
                else
                {
                    // 横向摆动
                    if (this.rb.position.x > this.t1.x && this.moveLeft)
                    {
                        this.rb.position = Vector3.MoveTowards(this.rb.position, this.t1, Time.deltaTime * enemy.speed);
                    }
                    else
                    {
                        this.moveLeft = false;
                        this.moveRight = true;
                    }

                    if (this.rb.position.x < this.t2.x && this.moveRight)
                    {
                        this.rb.position = Vector3.MoveTowards(this.rb.position, this.t2, Time.deltaTime * enemy.speed);
                    }
                    else
                    {
                        this.moveLeft = true;
                        this.moveRight = false;
                    }
                }
            }
            else
            {
                // 从左侧移出屏幕
                this.rb.position = Vector3.MoveTowards(this.rb.position, new Vector3(-1000, this.rb.position.y, this.rb.position.z), Time.deltaTime * enemy.speed);
            }

            //float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
            //GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
            //GetComponent<Rigidbody>().position = new Vector3
            //(
            //    Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            //    0.0f,
            //    Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            //);

            //GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
        }
    }
}