using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerBehaviour : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameSystem.instance.inputManager.OnHit += HitHandler;
    }

    private void HitHandler(Vector2 touchPosition)
    {
        Debug.LogWarning("screen width: " + Screen.width / 2);
        if (touchPosition.x > Screen.width / 2)
        {
            transform.parent.rotation = new Quaternion(0, 180, 0, 0);
            TimberHit();
        }
        else
        {
            transform.parent.rotation = new Quaternion(0, 0, 0, 0);
            TimberHit();
        }
    }

    private void TimberHit()
    {
        animator.SetTrigger("pHit");
        GameSystem.instance.OnTrunkHit();
        Debug.Log("TimberHit");
    }

    private void OnDestroy()
    {
        GameSystem.instance.inputManager.OnHit -= HitHandler;
    }
}
