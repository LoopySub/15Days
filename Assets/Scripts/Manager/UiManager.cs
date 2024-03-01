using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static Public_Enum;



public class UiManager : MonoBehaviour
{
    // ============================================[����� �ʱ�ȭ ������]=================================================
    [SerializeField]
    private GameObject DialogUI;

    [SerializeField]
    private Text MassageText;

    [SerializeField]
    private Text NameText;

    [SerializeField]
    private Image IconImage;

    [SerializeField]
    private GameObject ChoiceBoxUI;

    [SerializeField]
    private Image YexBox;

    [SerializeField]
    private Image NoBox;

    [SerializeField]
    private Image ZButtonBox;

    [SerializeField]
    private Sprite IconSprite_jone;

    [SerializeField]
    private Sprite IconSprite_Rebecca;

    private GameState past_state;

    // ============================================[����� �ʱ�ȭ ������]=================================================
    // ============================================[�鿪���� ������]=================================================

    private IOverallManager _overallManager;

    public IOverallManager _OverallManager
    {
        get { return _overallManager; }
    }

    public void Init(IOverallManager overallManager)
    {
        _overallManager = overallManager;
    }

    // ============================================[�迪���� ������]=================================================
    // ==============================================[��޼��� ������]==================================================
    void Update()
    {
        if (OverallManager.Instance.PublicVariable.IsDialog == true)
        {
            if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == true)
            {
                //���콺 ������ Ž��
                if (IsMouseOver(YexBox)) OverallManager.Instance.PublicVariable.IsChoice = true;
                else if (IsMouseOver(NoBox)) OverallManager.Instance.PublicVariable.IsChoice = false;
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    HideChoiceBox();
                }

                /*
                //����Ű�� ����Ŭ�� ����
                if (Input.GetMouseButtonDown(0))
                {
                    //���콺�� �̹��� ���� ���� ���
                    if (IsMouseOverAnyImage())
                    {
                        HideChoiceBox();
                    }
                }
                //Ű���� ����Ű �Է� ����
                HandleKeyboardInput();

                */
            }
            else
            {
                if (IsMouseOver(ZButtonBox) == true)
                {
                    SetImageTransparency(ZButtonBox, 220);
                }
                else
                {
                    SetImageTransparency(ZButtonBox, 172);
                }
            }
        }
    }



    // DialogUI�� Ȱ��ȭ�ϴ� �޼���
    public void ShowDialog(Icon_type icon, string name, string massage, float speed)
    {
        OverallManager.Instance.PublicVariable.IsDialog = true;
        if (DialogUI != null)
            {
                if (OverallManager.Instance.PublicVariable.GameState != GameState.Cutscene)
                {
                    OverallManager.Instance.PublicVariable.GameState = Public_Enum.GameState.Interface_On;
                }
            }
        IconImage.sprite = null;
            NameText.text = null;
            MassageText.text = null;

            if (icon == Icon_type.Jone)
            {
                IconImage.sprite = IconSprite_jone;
            }
            else if (icon == Icon_type.Rebecca)
            {
                IconImage.sprite = IconSprite_Rebecca;
            }
            else
            {
                IconImage.sprite = null;
            }

            DialogUI.SetActive(true);
            NameText.text = name;
            MassageText.DOText(massage, speed).SetUpdate(true);
    }

    // DialogUI�� ��Ȱ��ȭ�ϴ� �޼���
    public void HideDialog()
    {
        if (DialogUI != null)
        {
            DialogUI.SetActive(false);
        OverallManager.Instance.PublicVariable.IsDialog = false;
        if (OverallManager.Instance.PublicVariable.GameState != GameState.Cutscene && OverallManager.Instance.PublicVariable.IsUIPopup ==false) 
            { 
                    OverallManager.Instance.PublicVariable.GameState = Public_Enum.GameState.Playing;
            }
        }
    }

    public void ShowChoiceBox()
    {
        ChoiceBoxUI.SetActive(true);
        OverallManager.Instance.PublicVariable.IsChoiceBoxUI = true;
    }
    public void HideChoiceBox()
    {
        ChoiceBoxUI.SetActive(false);
        OverallManager.Instance.PublicVariable.IsChoiceBoxUI = false;
        //return OverallManager.Instance.PublicVariable.IsChoice;
    }


    public void HandleKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            OverallManager.Instance.PublicVariable.IsChoice = !OverallManager.Instance.PublicVariable.IsChoice;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow))
            OverallManager.Instance.PublicVariable.IsChoice = !OverallManager.Instance.PublicVariable.IsChoice;
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            OverallManager.Instance.PublicVariable.IsChoice = !OverallManager.Instance.PublicVariable.IsChoice;
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            OverallManager.Instance.PublicVariable.IsChoice = !OverallManager.Instance.PublicVariable.IsChoice;
    }

    public bool IsMouseOver(Image image)
    {
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        Vector2 localMousePosition = rectTransform.InverseTransformPoint(Input.mousePosition);
        return rectTransform.rect.Contains(localMousePosition);
    }

    public void SetImageTransparency(Image image, byte alpha)
    {
        Color color = image.color;
        color.a = alpha / 255f;
        image.color = color;
    }

    public void HandleIsTargetedChanged()
    {
        if (OverallManager.Instance.PublicVariable.IsChoice == true)
        {
            SetImageTransparency(YexBox, 192);
            SetImageTransparency(NoBox,114);
        }
        else 
        {
                SetImageTransparency(NoBox, 192);
                SetImageTransparency(YexBox,114);
        }
    }

    public bool IsMouseOverAnyImage()
    {
        return IsMouseOver(YexBox) || IsMouseOver(NoBox);
    }


    // ==============================================[��޼��� ������]==================================================
    // ==============================================[������ ������]==================================================
    public Image zButtonBox { get { return ZButtonBox; } }


    // ==============================================[������ ������]==================================================
}
