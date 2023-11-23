using UnityEngine;

public class BombController : MonoBehaviour
{
    void Update()
    {

        /// <summary>
        /// 爆弾の破壊
        /// </summary>
        if (transform.position.y < -3.5)
        {
            Destroy(gameObject);
        }
    }
}
