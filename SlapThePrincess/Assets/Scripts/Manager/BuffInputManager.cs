using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuffInputManager : MonoBehaviour
{
    [SerializeField] private Monster PlayerMonster;
    private BattleManager battleManager;
    [SerializeField] UIBuff uiBuff;

    string keySequence;

    // Define the skill combinations and their corresponding actions
    private Dictionary<string, IBuffStrategy> skillCombinations = new Dictionary<string, IBuffStrategy>();
    private Dictionary<string, Sprite> skillImages = new Dictionary<string, Sprite>();

    // Buffer to store the pressed keys
    private List<KeyCode> keyBuffer = new List<KeyCode>();

    private void Awake()
    {
        battleManager = GameObject.FindFirstObjectByType<BattleManager>();
    }

    private void Start()
    {
        InitBuff();
    }

    private void InitBuff()
    {
        skillCombinations = new Dictionary<string, IBuffStrategy>();
        skillCombinations["ASD"] = new ASD(3);
        skillCombinations["ASF"] = new ASF(4);
        skillCombinations["ADF"] = new ADF(5);
        skillCombinations["ADA"] = new ADA(8);
        skillCombinations["AFA"] = new AFA(4);
        skillCombinations["ASA"] = new ASA(8);
        skillCombinations["FDA"] = new FDA(10);
        skillCombinations["FSA"] = new FSA(10);

        skillImages = new Dictionary<string, Sprite>();
        skillImages["ASD"] = uiBuff.kolakJadi[3];
        skillImages["ASF"] = uiBuff.kolakJadi[4];
        skillImages["ADF"] = uiBuff.kolakJadi[1];
        skillImages["AFA"] = uiBuff.kolakJadi[0];
        skillImages["ASA"] = uiBuff.kolakJadi[2];
        skillImages["ADA"] = uiBuff.kolakJadi[1]; // blom ada aset
        skillImages["FSA"] = uiBuff.kolakJadi[4];
        skillImages["FDA"] = uiBuff.kolakJadi[1];
    }

    private void Update()
    {
        CheckForKeyPress(KeyCode.A);
        CheckForKeyPress(KeyCode.S);
        CheckForKeyPress(KeyCode.D);
        CheckForKeyPress(KeyCode.F);

        if (keySequence != null && keySequence.Length == 3)
        {
            if (skillCombinations.ContainsKey(keySequence))
                uiBuff.kolak.sprite = skillImages[keySequence];
            else
                uiBuff.kolak.sprite = uiBuff.kolakJadi[5];
        }
        else
            uiBuff.kolak.sprite = uiBuff.kolakJadi[5];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (skillCombinations.ContainsKey(keySequence))
            {
                skillCombinations[keySequence].ApplyBuff(PlayerMonster);
             
                battleManager.SetHpUi();
                battleManager.SetArmorUi();
                battleManager.SetPowerUi(); 
            }
            // Clear the key buffer
            keyBuffer.Clear();
            keySequence = String.Empty;
            ResetImage();
        }
    }

    private void CheckForKeyPress(KeyCode key)
    {          
        if (Input.GetKeyDown(key))
        {
            if (keyBuffer.Count < 3)
            {
                keyBuffer.Add(key);
                keySequence = string.Join("", keyBuffer);

                switch (key)
                {
                    case KeyCode.A:
                        uiBuff.SetImageOnCooldown(uiBuff.kuah);
                        break;
                    case KeyCode.S:
                        uiBuff.SetImageOnCooldown(uiBuff.pisang);
                        break;
                    case KeyCode.D:
                        uiBuff.SetImageOnCooldown(uiBuff.kolangKaling);
                        break;
                    case KeyCode.F:
                        uiBuff.SetImageOnCooldown(uiBuff.labu);
                        break;
                }
            } 
        }
    }

    public void ResetImage()
    {
        uiBuff.SetImageOnReady(uiBuff.kuah);
        uiBuff.SetImageOnReady(uiBuff.pisang);
        uiBuff.SetImageOnReady(uiBuff.kolangKaling);
        uiBuff.SetImageOnReady(uiBuff.labu);
    }
}
