using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    private void Start()
    {
        LoadRunTimeAnimator();
    }

    private void LoadRunTimeAnimator()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = transform.parent.GetComponent<PlayerCtrl>()
            .AnimationCurveRuntimeAnimatorController;
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
            this.animator.SetFloat(Horizontal, InputManager.Instance.InputHorizontal);
            this.animator.SetFloat(Vertical, InputManager.Instance.InputVertical);
        }
    }

    protected virtual void RunAnimation()
    {
        this.animator.SetBool(IsRunning, this.CanMoving());
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
