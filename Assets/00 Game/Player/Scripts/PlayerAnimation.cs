using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Player Animation")]
    public Animator animator;

    private void OnValidate()
    {
       LoadAnimator();
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    private void Update()
    {
        Animation();
    }
    protected virtual void Animation()
    {
        this.MoveAnimation();
        this.RunAnimation();
    }
    protected virtual void MoveAnimation()
    {
        if (this.CanMoving())
        {
            this.animator.SetFloat("Horizontal", InputManager.Instance.InputHorizontal);
            this.animator.SetFloat("Vertical", InputManager.Instance.InputVertical);
        }
    }

    protected virtual void RunAnimation()
    {
        this.animator.SetBool("IsRunning", this.CanMoving());
    }
    
    protected virtual bool CanMoving()
    {
        float horizontal = InputManager.Instance.InputHorizontal;
        float vertical = InputManager.Instance.InputVertical;
        Vector2 input = new(horizontal, vertical);

        if (input.magnitude > 0.1f) return true;
        return false;
    }

}
