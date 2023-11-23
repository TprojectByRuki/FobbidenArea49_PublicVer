using UnityEngine;

public class ExplodeController : MonoBehaviour
{
    void Update()
    {
        // 破壊エフェクト生成後、1秒後に破壊
        Invoke("Destroy", 1.0f);
    }

    /// <summary>
    /// 爆発エフェクトを破壊
    /// </summary>
    void Destroy()
    {
        Destroy(gameObject);
    }
}
