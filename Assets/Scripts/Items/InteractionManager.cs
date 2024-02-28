using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


//Layer Mask =  interactable 설정, PromptText에는 PromptText설정 ,거리설정 필요
public interface IInteractable
{
    string GetInteractPrompt();
    void OnInteract();
}
public class InteractionManager : MonoBehaviour
{
   
  
    private GameObject curInteractGameobject;
    private IInteractable curInteractable;

    public TextMeshProUGUI promptText;



    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.layer == LayerMask.NameToLayer("interactable"))
        {
            curInteractGameobject = coll.gameObject;
            curInteractable =curInteractGameobject.GetComponent<IInteractable>();
            SetPromptText();
        }
        
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("interactable"))
        {
            promptText.gameObject.SetActive(false);
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = string.Format("<b>[E]</b> {0}", curInteractable.GetInteractPrompt());

    }


    public void OnInteractInput(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnInteract();
            curInteractGameobject = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }

    public void OnInteractInput(InputValue value)
    {
        if (value.isPressed )
        {
            curInteractable.OnInteract();
            curInteractGameobject = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }
}

