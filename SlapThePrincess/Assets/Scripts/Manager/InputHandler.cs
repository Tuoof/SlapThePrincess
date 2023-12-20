using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private Monster PlayerMonster;
    // Define the skill combinations and their corresponding actions
    private Dictionary<string, IBuffStrategy> skillCombinations = new Dictionary<string, IBuffStrategy>();

    // Buffer to store the pressed keys
    private List<KeyCode> keyBuffer = new List<KeyCode>();

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
    }

    private void Update()
    {
        CheckForKeyPress(KeyCode.A);
        CheckForKeyPress(KeyCode.S);
        CheckForKeyPress(KeyCode.D);
        CheckForKeyPress(KeyCode.F);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            string keySequence = string.Join("", keyBuffer);

            if (skillCombinations.ContainsKey(keySequence))
            {
                skillCombinations[keySequence].ApplyBuff(PlayerMonster);
            }

            // Clear the key buffer
            keyBuffer.Clear();
        }
    }

    private void CheckForKeyPress(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            keyBuffer.Add(key);
        }
    }
}
