using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
