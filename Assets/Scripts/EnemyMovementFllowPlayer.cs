using UnityEngine;

namespace STG_Demo
{
    /// <summary>
    /// 敌人移动
    /// 自动朝向player移动
    /// </summary>
    public class EnemyMovementFllowPlayer : MonoBehaviour
    {

        private Transform player;
        //private PlayerHealth playerHealth;
        //private EnemyHealth enemyHealth;
        //private UnityEngine.AI.NavMeshAgent nav;
        // Start is called before the first frame update

        private Enemy enemy;
        private float targetZ;
        private float targetX;

        private bool follow = true;

        private void Start()
        {

        }

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            //playerHealth = player.GetComponent<PlayerHealth>();
            //enemyHealth = GetComponent<EnemyHealth>();
            //nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

            // 朝向玩家移动
            enemy = this.gameObject.GetComponent<Enemy>();
        }

        // Update is called once per frame
        private void Update()
        {

            if (this.transform.position.z >= player.position.z)
            {
                targetZ = player.position.z;
                targetX = player.position.x;
            }
            else
            {
                follow = false;
            }

            if (follow)
            {
                Vector3 target = new Vector3(targetX, this.transform.position.y, targetZ);
                // this.transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * enemy.speed);
                this.transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * enemy.speed);
            }
            else
            {
                // 向前移动
                Vector3 target = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 100);
                this.transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * enemy.speed);
            }


        }

        // GetComponent<Rigidbody>().velocity = player.position.normalized * 2;

        //if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        //    nav.SetDestination(player.position);
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
}