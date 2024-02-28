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
    private Sprite IconSprite_jone;

    [SerializeField]
    private Sprite IconSprite_Rebecca;


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
    // DialogUI�� Ȱ��ȭ�ϴ� �޼���
    public void ShowDialog(Icon_type icon, string name, string massage)
    {
        if (DialogUI != null)
        {
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
            MassageText.DOText(massage, 3);
        }
    }

    // DialogUI�� ��Ȱ��ȭ�ϴ� �޼���
    public void HideDialog()
    {
        if (DialogUI != null)
        {
            DialogUI.SetActive(false);
        }
    }

    // ==============================================[��޼��� ������]==================================================
}
