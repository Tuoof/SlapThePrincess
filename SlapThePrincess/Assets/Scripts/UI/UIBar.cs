using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBar : MonoBehaviour
{
    [SerializeField] GameObject health;
    [SerializeField] GameObject armor;
    [SerializeField] GameObject power;

    // Start is called before the first frame update
    void Start()
    {
        health.transform.localScale = new Vector3(1f, 1f);
        armor.transform.localScale = new Vector3(1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3(hpNormalized, 1f);
    }

    public void SetArmor(float armorNormalized)
    {
        armor.transform.localScale = new Vector3(armorNormalized, 1f);
    }

    public void SetPower(float powerNormalized)
    {
        power.transform.localScale = new Vector3(powerNormalized, 1f);
    }
}
