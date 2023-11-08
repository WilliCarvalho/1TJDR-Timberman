using System;
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

    private void HitHandler(Vector2 touchPos)
    {
        CheckHitPosition(touchPos);
        PlayHitAnimation();
        PlayHitSFX();
        TimberHit();
    }

    private void CheckHitPosition(Vector2 touchPos)
    {
        float screenSize = Camera.main.pixelWidth;
        if (touchPos.x < (screenSize / 2))
        {
            transform.parent.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (touchPos.x > (screenSize / 2))
        {
            transform.parent.rotation = new Quaternion(0, 180, 0, 0);
        }
    }

    private void PlayHitAnimation()
    {
        animator.SetTrigger("pHit");
    }

    private void PlayHitSFX()
    {
        GameSystem.instance.PlaySFXAudioByType(SFXAudioType.TimberHit);
    }

    private void TimberHit()
    {
        GameSystem.instance.TrunkHit();
        Debug.Log("HIT!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TrunkBase>())
        {
            GameSystem.instance.GameOver();
        }
    }

    private void OnDestroy()
    {
        GameSystem.instance.inputManager.OnHit -= HitHandler;
    }
}
