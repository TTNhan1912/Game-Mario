using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Script : MonoBehaviour
{
    public Transform HpEmpty;
    public Slider slider;
    public Transform boss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateHp();
        transform.position = new Vector3(boss.transform.position.x, transform.position.y, transform.position.z);
    }

    protected virtual void UpdateHp()
    {
        if (this.slider == null) return;
        IHpInterface hpInterface = this.HpEmpty.GetComponent<IHpInterface>();
        if (hpInterface == null) return;
        this.slider.value = hpInterface.HP();
    }
}
