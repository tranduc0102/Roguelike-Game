using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionWeapon : OptionBase
{
    private Transform weapons;
    private int idWeapon;
    [SerializeField] protected Animator transitionAnim;

    public void Init(Transform weapon,int id)
    {
        description.text = weapon.name;
        this.weapons = weapon;
        idWeapon = id;
    }

    protected override void Start()
    {
        base.Start();
        transitionAnim = GameObject.Find("Scence Transtision").GetComponent<Animator>();
        chooseBtn.onClick.AddListener(() =>
        {
            StartCoroutine(this.Choice());
        });
    }
    
    protected virtual IEnumerator Choice()
    {
     
            this.transitionAnim.SetTrigger("End");
            WaitForSeconds waitForSeconds = new WaitForSeconds(1);
            yield return waitForSeconds;
            SelectWeapon();
            this.transitionAnim.SetTrigger("Start");

    }

    private void SelectWeapon()
    {
        DataSelect.Instance.IDWeapon = idWeapon;
        SceneManager.LoadScene("InGame");
    }
}
