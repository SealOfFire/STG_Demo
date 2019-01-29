using UnityEngine;

namespace STG_Demo
{
    /// <summary>
    /// 边界
    /// 销毁物体 避免内存泄露
    /// </summary>
    public class Boundary : MonoBehaviour
    {
        /// <summary>
        /// 离开边界
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerExit(Collider other)
        {
            // 摧毁离开边界的物体
            Debug.Log("离开边界:" + other.tag);
            Destroy(other.gameObject);
        }
    }
}
