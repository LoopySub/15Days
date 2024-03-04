using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTip : Researchable
{

    public override void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text ���� ���� �ٸ� ���� ����
            switch (click_Text)
            {
                case 1:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "���� ���� Ȯ���ұ��?", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 2:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "���� 00�ð� �Ǹ� �ῡ ���, ������ 08�ÿ� �Ͼ�ϴ�.", 1);
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�׷� �ð� ����.", 1);
                        click_Text = 1000;
                    }
                    break;
                case 3:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "15�� °�� �Ǹ� ���� ���� ��Ȳ�� ���� �ٸ� ������ ���ɴϴ�.", 1);
                    break;
                case 4:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "1�ð��� ������ ������ ��θ� ��ġ�� 1.5�� �����մϴ�.", 1);
                    break;
                case 5:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "�� ��θ� ��ġ�� �Ϸ� 36�� �����մϴ�.", 1);
                    break;
                case 6:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "����ī�� �������� ���� ��ħ 25 ~ 35 ������ ������ ������ �����մϴ�.", 1);
                    break;
                case 7:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "�׻��� ��� �� 25~30�� ������ ��ġ�� ȸ����ų �� �ְ�, �׳� ��ȣ�� �� 10~20�� ȸ����ų �� �ֽ��ϴ�.", 1);
                    break;
                case 8:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "������ PC�� ����ϸ� ������ ������ �Լ��� ���� �ֽ��ϴ�.", 1);
                    break;
                case 9:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "���� 00�ð� �Ǹ� ������� �����ϹǷ� �ۿ� �ִ� ����� ��Ƴ��� ���մϴ�.", 1);
                    break;
                case 10:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "����ī�� �������� 100�� �Ǹ� ����ų �� �����ϴ�.", 1);
                    break;
                case 11:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "��θ��� 0�� �Ǹ� ���� �׽��ϴ�.", 1);
                    break;
                case 12:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "Ʈ�� ������ �����մϴ�. ������ �� ���� ���� �𸣰�����.", 1);
                    break;
                case 13:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "�׸��� ���� ���� ���� ���� �̰� ���� �ֽ��ϴ�. ���� �밡���Դϴ�.", 1);
                    break;
                case 14:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "���� ����Ƽ ���� ��մ� ������ �ٰ��� ���X���X�ؼ� ����� �;��µ�, �ʹ� �ƽ��׿�.", 1);
                    break;
                case 15:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "å��", "... ... ������ ����սô�...", 1);
                    break;
                case 16:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    break;
                /*
                case 17:
                    Prologue_Text.DOText("", 3);
                    break;
                case 18:
                    Prologue_Text.DOText("", 3);
                    break;
                case 19:
                    Prologue_Text.DOText("", 3);
                    break;
                case 20:
                    Prologue_Text.DOText("", 3);
                    break;
                case 21:
                    Prologue_Text.DOText("", 3);
                    break;
                case 22:
                    Prologue_Text.DOText("", 3);
                    break;
                case 23:
                    Prologue_Text.DOText("", 3);
                    break;
                case 24:
                    Prologue_Text.DOText("", 3);
                    break;
                case 25:
                    Prologue_Text.DOText("", 3);
                    break;
                case 26:
                    Prologue_Text.DOText("", 3);
                    break;
                case 27:
                    Prologue_Text.DOText("", 3);
                    break;
                case 28:
                    Prologue_Text.DOText("", 3);
                    break;
                case 29:
                    Prologue_Text.DOText("", 3);
                    break;
                case 30:
                    Prologue_Text.DOText("", 3);
                    break;
                */
                // �߰����� ��쿡 ���� ó���� �̾ �ۼ�
                default:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    break;
            }
        }
    }
}
