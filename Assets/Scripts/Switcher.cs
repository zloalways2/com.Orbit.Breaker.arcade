using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public GameObject[] activateOnState;
    public GameObject[] deactivateOnState;

    public bool state;
    public bool instantStateChange;

    public Action<bool> onChangeState;

    private void OnEnable()
    {
        UpdateButton();
    }

    private void Update()
    {
        if (instantStateChange)
        {
            UpdateButton();
            instantStateChange = false;
        }
    }

    public void SwapState()
    {
        state = !state;
        UpdateButton();

        onChangeState?.Invoke(state);
    }

    private void UpdateButton()
    {
        foreach(GameObject go in activateOnState)
        {
            go.SetActive(state);
        }

        foreach(GameObject go in deactivateOnState)
        {
            go.SetActive(!state);
        }
    }
}