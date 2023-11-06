using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class TrunkBase : MonoBehaviour
{
    [SerializeField] protected float moveOffset;
    private Sprite sprite;
    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        int randomNum = Random.Range(0, 2);
        spriteRenderer.flipX = randomNum == 1;
        spriteRenderer.flipY = randomNum == 0;
        TrunksPool.OnTrunkHitted += TrunkFall;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
