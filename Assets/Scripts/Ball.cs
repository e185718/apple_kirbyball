using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    /// <summary>
    /// 物理剛体
    /// </summary>
    private Rigidbody physics = null;

    /// <summary>
    /// 初期化処理
    /// </summary>
    public void Awake()
    {
        this.physics = this.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 毎フレームごとの処理
    /// </summary>
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.Flip(new Vector3(-3f, 1f, 0));
        }
    }

    /// <summary>
    /// ボールをはじく
    /// </summary>
    /// <param name="force"></param>
    public void Flip(Vector3 force)
    {
        // 瞬間的に力を加えてはじく
        this.physics.AddForce(force, ForceMode.Impulse);
    }
}
