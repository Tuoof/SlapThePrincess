using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    [SerializeField] GameObject health;
    [SerializeField] GameObject Stamina;

    // Start is called before the first frame update
    void Start()
    {
        health.transform.localScale = new Vector3(1f, 1f);
        Stamina.transform.localScale = new Vector3(1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3(hpNormalized, 1f);
        Stamina.transform.localScale = new Vector3(hpNormalized, 1f);
    }
}
