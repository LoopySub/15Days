using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;



public interface IInteractable  //�������̽�
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
        
        if (coll.gameObject.layer == LayerMask.NameToLayer("interactable")) // ���̾ "interactable"�� �����۰� �浹���� ���
        {
            curInteractGameobject = coll.gameObject;
            curInteractable =curInteractGameobject.GetComponent<IInteractable>();
            SetPromptText();
        }
        
    }
    void OnCollisionExit2D(Collision2D coll) //  ���̾ "interactable"�� �����۰� �浹���� ���
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("interactable"))
        {
            promptText.gameObject.SetActive(false);
        }
    }

    private void SetPromptText() // [e] ����ֱ� ��ȣ�ۿ� ǥ�� �ؽ�Ʈ
    {
        promptText.gameObject.SetActive(true);
        promptText.text = string.Format("<b>[E]</b> {0}", curInteractable.GetInteractPrompt());

    }


  

    public void OnInteractInput(InputValue value)  // EŰ, ȹ����  �������� 
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

