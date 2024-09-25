using UnityEngine;

public class PlayerMovement :BasePlayer
{
   private float horizontal;
   private float vertical;
   protected void FixedUpdate()
   {
      this.GetInput();
      this.Moving();
   }

   protected virtual void GetInput()
   {
       this.horizontal = InputManager.Instance.InputHorizontal;
       this.vertical = InputManager.Instance.InputVertical;
   }

   protected virtual void Moving()
   {
       Vector3 direction = new(this.horizontal, this.vertical, 0);
       direction.Normalize();
       transform.parent.position += direction * speed * Time.fixedDeltaTime;
   }
}
