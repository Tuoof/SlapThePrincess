using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuff : MonoBehaviour
{
    public SpriteRenderer labu;
    public SpriteRenderer pisang;
    public SpriteRenderer kuah;
    public SpriteRenderer kolangKaling;
    public SpriteRenderer kolak;

    public Sprite[] kolakJadi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetImageOnCooldown(SpriteRenderer image)
    {
        Color tmp = image.color;
        tmp.a = 0.3f;
        image.color = tmp;
    }

    public void SetImageOnReady(SpriteRenderer image)
    {
        Color tmp = image.color;
        tmp.a = 1f;
        image.color = tmp;
    }
}
