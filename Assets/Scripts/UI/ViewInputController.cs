using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ViewInputController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference openReference;
    [SerializeField]
    private GameObject inventoryWindow;
    private InputAction openAction;

    private void Toggle(InputAction.CallbackContext ctx) => inventoryWindow.SetActive(!inventoryWindow.activeSelf);

    private void Awake()
    {
        openAction = openReference.action;
    }

    private void OnEnable() => openAction.performed += Toggle;
    private void OnDisable() => openAction.performed -= Toggle;

}
