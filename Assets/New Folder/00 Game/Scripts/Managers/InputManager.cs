using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private float inputHorizontal;
    private float inputVertical;
    public float InputHorizontal => inputHorizontal;
    public float InputVertical => inputVertical;

    // Update is called once per frame
    void Update()
    {
        this.GetInputMove();
    }

    protected virtual void GetInputMove()
    {
        this.inputHorizontal = Input.GetAxisRaw("Horizontal");
        this.inputVertical = Input.GetAxisRaw("Vertical");
    }

}
