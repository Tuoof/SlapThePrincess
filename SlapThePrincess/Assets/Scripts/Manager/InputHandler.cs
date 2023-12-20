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
        skillCombinations["ASD"] = new ASD();
        skillCombinations["ASF"] = new ASF();
        skillCombinations["ADF"] = new ADF();
        skillCombinations["ADA"] = new ADA();
        skillCombinations["AFA"] = new AFA();
        skillCombinations["ASA"] = new ASA();
        skillCombinations["FDA"] = new FDA();
        skillCombinations["FSA"] = new FSA();
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
