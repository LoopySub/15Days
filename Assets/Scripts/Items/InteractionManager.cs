using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;



public interface IInteractable  //인터페이스
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
        
        if (coll.gameObject.layer == LayerMask.NameToLayer("interactable")) // 레이어가 "interactable"인 아이템과 충돌했을 경우
        {
            curInteractGameobject = coll.gameObject;
            curInteractable =curInteractGameobject.GetComponent<IInteractable>();
            SetPromptText();
        }
        
    }
    void OnCollisionExit2D(Collision2D coll) //  레이어가 "interactable"인 아이템과 충돌했을 경우
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("interactable"))
        {
            promptText.gameObject.SetActive(false);
        }
    }

    private void SetPromptText() // [e] 집어넣기 상호작용 표시 텍스트
    {
        promptText.gameObject.SetActive(true);
        promptText.text = string.Format("<b>[E]</b> {0}", curInteractable.GetInteractPrompt());

    }


  

    public void OnInteractInput(InputValue value)  // E키, 획득이  눌렸을때 
    {
        if (value.isPressed)
        {
            if (curInteractGameobject != null)
                {
                    curInteractable.OnInteract();
                    curInteractGameobject = null;
                    curInteractable = null;
                    promptText.gameObject.SetActive(false);
                }
        }
    }
}

