using System;
using UnityEngine;

public abstract class TrunkBase : MonoBehaviour
{
    [SerializeField] protected float moveOffset;

    private void OnEnable()
    {
        TrunksPool.OnTrunkHitted += TrunkFall;
    }

    private void TrunkFall()
    {
        transform.position = new Vector2(0, transform.position.y - moveOffset);
    }

    public void TrunkHitted()
    {
        TrunksPool.OnTrunkHitted -= TrunkFall;
        TrunksPool.OnTrunkHitted?.Invoke();
    }
}
