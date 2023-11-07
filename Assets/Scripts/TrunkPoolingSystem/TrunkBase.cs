using UnityEngine;
using Random = UnityEngine.Random;

public abstract class TrunkBase : MonoBehaviour
{
    [SerializeField] private float moveOffset;
    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        TrunkPool.OnTrunkHitted += TrunkFall;
        int randomNum = Random.Range(0, 2);
        spriteRenderer.flipX = randomNum == 0;
        //Pode substituir a linha de cima
        //if(randomNum == 0)
        //{
        //    spriteRenderer.flipX = true;
        //}
        //else
        //{
        //    spriteRenderer.flipX = false;
        //}
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
        TrunkPool.OnTrunkHitted -= TrunkFall;
        TrunkPool.OnTrunkHitted?.Invoke();
    }
}
