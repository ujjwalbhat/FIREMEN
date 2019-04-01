using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public GameObject instructionPanel;

    bool instructionPanelactive = false;

    void Start()
    {
        instructionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstructionPanel()
    {
        instructionPanelactive = !instructionPanelactive;
        instructionPanel.SetActive(instructionPanelactive);
    }
}
