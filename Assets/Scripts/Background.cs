using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    /// <summary>
    /// 子弹的移动速度
    /// </summary>
    public float speed = 10;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * -this.speed;
    }
}
