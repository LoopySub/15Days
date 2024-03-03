using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndingController : MonoBehaviour
{
    [SerializeField]
    private Text Ending_Text;

    [SerializeField]
    private int click_Text = 0;

    bool End;

    private void Start()
    {
        OverallManager.Instance.PublicVariable.GameState = Public_Enum.GameState.Cutscene;
        Ending_Text.DOText("...", 1).SetUpdate(true);

        if(OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.OverNight)
            click_Text = 0;
        else if (OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.GameOver)
            click_Text = 8;
        else if (OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.Infection)
            click_Text = 16;
        else if (OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.Starvation)
            click_Text = 50;
        else if (OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.Normal)
            click_Text = 26;
        else if (OverallManager.Instance.PublicVariable.Ending_Type == Public_Enum.Ending_type.True)
            click_Text = 57;

    }

    void Update()
    {
        // Ŭ���̳� ZŰ �Է� �� click_Text ����
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z))
        {
            if (End == false)
            {
                click_Text++;
                HandleClickTextChange();
            }
        }
    }

    void HandleClickTextChange()
    {
        // click_Text ���� ���� �ٸ� ���� ����
        switch (click_Text)
        {
            case 1:
                Ending_Text.text = null;
                Ending_Text.DOText("���� ���̷����� Ư¡��..", 1).SetUpdate(true);
                break;
            case 2:
                Ending_Text.text = null;
                Ending_Text.DOText("������ �������� ���������� Ȱ��ȭ �ȴٴ� ���̴�.", 1).SetUpdate(true);
                break;
            case 3:
                Ending_Text.text = null;
                Ending_Text.DOText("������ ���ε� �̰ܳ� �� ���� ������ ������, �糳��, �ܴ�������.", 1).SetUpdate(true);
                break;
            case 4:
                Ending_Text.text = null;
                Ending_Text.DOText("�Ӹ� �ƴ϶�, ������ ��ġ�Ǿ� �ִ� ������ ��ü�鵵 �����̱� �����Ѵ�.", 1).SetUpdate(true);
                break;
            case 5:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "ũ�ƾƾƾƾ�-!!", 3);
                break;
            case 6:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("�׸��� �ѳ� �ΰ����� ���� �� ���� ������ �ð��� �ε��� �ٴ� ����� �翬�ߴ�.", 3).SetUpdate(true);
                break;
            case 7:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "��.. ��ī....", 1);
                break;
            case 8:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("ENDING 1: OVER NIGHT", 3).SetUpdate(true);
                End = true;
                break;
            case 9:
                Ending_Text.text = null;
                Ending_Text.DOText("���� ����鿡�� �ѷ��׿� �׾�� �ִ�.", 3).SetUpdate(true);
                break;
            case 10:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "�����", "�׸�������.. �Ʊ���, ����, �׿���..!", 1);
                break;
            case 11:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "....", 3);
                break;
            case 12:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("���� �ð� �Ǹ� ���ô� �Ҹ��� �鸱 ��,", 3).SetUpdate(true);
                break;
            case 13:
                Ending_Text.text = null;
                Ending_Text.DOText("������ �Ͼ�� �ʴ´�.", 3).SetUpdate(true);
                break;
            case 14:
                Ending_Text.text = null;
                Ending_Text.DOText("�����̸� ���ϰ� �;��� �ƹ����� ����, �׷��� �ű⼭ ���� ����.", 3).SetUpdate(true);
                break;
            case 15:
                Ending_Text.text = null;
                Ending_Text.DOText("ENDING 2: GAME OVER", 3).SetUpdate(true);
                break;
            case 16:
                End = true;
                Application.Quit();
                break;
            case 17:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "�׸�����...", 2);
                break;
            case 18:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī..?", 1);
                break;
            case 19:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "ļ�ƾƾƾ�-!!", 2);
                break;
            case 20:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("�ʹ� �ʾ���� ſ�ϱ�, �ƴϸ� �� ������ �ʾұ� �����ϱ�.", 3);
                break;
            case 21:
                Ending_Text.text = null;
                Ending_Text.DOText("�װ��� �ִ� �� �� �̻� ���� �� ����ī�� �ƴϾ���.", 3);
                break;
            case 22:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī, ����! �ȵ�!", 1);
                break;
            case 23:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���ƾƾƾƾ�-!", 1);
                break;
            case 24:
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("�����밡 �������� ��, �� ���� �ִ� �� ���� ���� ������ �ý��� ���԰� �ִ� �ҳ� ���� �� ���� ���̾���.", 3);
                break;
            case 25:
                Ending_Text.text = null;
                Ending_Text.DOText("ENDING 3: INFECTION", 3).SetUpdate(true);
                break;
            case 26:
                End = true;
                Application.Quit();
                break;
            case 27:
                Ending_Text.text = null;
                Ending_Text.DOText("Day-15", 1);
                break;
            case 28:
                Ending_Text.text = null;
                Ending_Text.DOText("�ȶ�,", 1);
                break;
            case 29:
                Ending_Text.text = null;
                Ending_Text.DOText("���ε��� ���� �� �������� �ε帰��.", 1);
                break;
            case 30:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "���ε�", "�ű� ������ ��ʴϱ�?", 1);
                break;
            case 31:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī, �����? �����밡 �Ծ�!", 1);
                break;
            case 32:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���� �����ϴ�!", 1);
                break;
            case 33:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("��Ĭ,", 3);
                break;
            case 34:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ �����ڰ� �־�����. �����Դϴ�.", 1);
                break;
            case 35:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "��..��.. �ݷ��ݷ�, ���� ���̾�..?", 1);
                break;
            case 36:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "��..?", 1);
                break;
            case 37:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "��, �� ���̴� �� ���Դϴ�.. �����ƿ�!", 1);
                break;
            case 38:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "ö��,", 1);
                break;
            case 39:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("�� -      !!!,", 3);
                break;
            case 40:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "��.. ����.. ...", 1);
                break;
            case 41:
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("�н�.", 3);
                break;
            case 42:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī, ����ī�ƾƾ�!!!! ��ŵ�, ���� ����..!!", 1);
                break;
            case 43:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���� ��ħ ��, �����ڴ� ���� �߰� ��� ����Դϴ�.", 1);
                break;
            case 44:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "��.. ��....", 1);
                break;
            case 45:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī, �ȵ�, ���� ����, �̷� ����.. �ȵ�, �ȵ�!!!", 1);
                break;
            case 46:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "��¿ �� �����ϴ�. ����� �������� ������ �� ������, ����� �Բ� ������.", 1);
                break;
            case 47:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī, ����ī.. �ȵ�.. �ƾ�.. �ƾƾƾƾƾƾƾƾ�-!!!", 1);
                break;
            case 48:
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("������ ���� �ýŰ�, ���� ���� �ƹ����� ���Ը��� �� �ڸ��� ���� �־���.", 3);
                break;
            case 49:
                Ending_Text.text = null;

                Ending_Text.DOText("ENDING 5: TRAGEDY", 3).SetUpdate(true);
                break;
            case 50:
                End = true;
                Application.Quit();
                break;
            case 51:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ļ�.. �� �ϳ� ����� ���� ����..", 1);
                break;
            case 52:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�̸��̸� �ķ��� �����ص׾�� �ߴµ�...", 1);
                break;
            case 53:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "... ...", 1);
                break;
            case 54:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                break;
            case 55:
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("���� ����Į���� ���迡��, �ƻ�� ���� �����̴�.", 3);
                break;
            case 56:
                Ending_Text.text = null;
                Ending_Text.DOText("ENDING 4: STARVATION", 3).SetUpdate(true);
                break;
            case 57:
                End = true;
                Application.Quit();
                break;
            case 58:
                Ending_Text.DOText("Day-15", 3);
                break;
            case 59:
                Ending_Text.text = null;
                Ending_Text.DOText("�ȶ�,", 1);
                break;
            case 60:
                Ending_Text.text = null;
                Ending_Text.DOText("���ε��� ���� �� �������� �ε帰��.", 3);
                break;
            case 61:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "���ε�", "�ű� ������ ��ʴϱ�?", 1);
                break;
            case 62:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī, �����? �����밡 �Ծ�!", 1);
                break;
            case 63:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���� �����ϴ�!", 1);
                break;
            case 64:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ �����ڰ� �־�����. �����Դϴ�.", 1);
                break;
            case 65:
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Rebecca, "����ī", "����..!", 1);
                break;
            case 66:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "�� ��, �����ʴϱ�? ��.. �� �� �� �ǰ��� ������ ���� �� ������.", 1);
                break;
            case 67:
                Ending_Text.text = null;
                OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "�׷� ����� �Բ� ������. ������ ķ���� �������� ȯ���մϴ�.", 1);
                break;
            case 68:
                OverallManager.Instance.UiManager.HideDialog();
                Ending_Text.DOText("���� ��ġ�� ����ī�� �������� ��ȣ�� �޾� ������ ������ ķ���� �շ��� �� �־���.", 1);
                break;
            case 69:
                Ending_Text.DOText("���� �̷��� �Ҿ�������, �׷��� �׵��� �ճ����� �ູ�� ��ٸ��� ���� ���̴�.", 1);
                break;
            case 70:
                Ending_Text.text = null;
                Ending_Text.color = Color.yellow;
                Ending_Text.DOText("ENDING 6: HAPPY END", 3).SetUpdate(true);
                break;
            case 71:
                End = true;
                Application.Quit();
                break;
            case 72:
                Ending_Text.DOText("Text for case 72", 3);
                break;
            case 73:
                Ending_Text.DOText("Text for case 73", 3);
                break;
            case 74:
                Ending_Text.DOText("Text for case 74", 3);
                break;
            case 75:
                Ending_Text.DOText("Text for case 75", 3);
                break;
            case 76:
                Ending_Text.DOText("Text for case 76", 3);
                break;
            case 77:
                Ending_Text.DOText("Text for case 77", 3);
                break;
            case 78:
                Ending_Text.DOText("Text for case 78", 3);
                break;
            case 79:
                Ending_Text.DOText("Text for case 79", 3);
                break;
            case 80:
                Ending_Text.DOText("Text for case 80", 3);
                break;
            default:
                // �⺻ ó��
                break;
        }
    }
}

