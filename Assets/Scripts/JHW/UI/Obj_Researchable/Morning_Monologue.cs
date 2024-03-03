using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morning_Monologue : Researchable
{
    public override void Click_Text_Reset()
    {
        if(OverallManager.Instance.PublicVariable.Day == 1)
        {

        }
        else if (OverallManager.Instance.PublicVariable.Day == 2)
        {
            click_Text = 2;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 3)
        {
            click_Text = 5; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 4)
        {
            click_Text = 8 ; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 5)
        {
            click_Text = 11 ; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 6)
        {
            click_Text = 15; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 7)
        {
            click_Text = 18; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 8)
        {
            click_Text = 22; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 9)
        {
            click_Text = 24; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 10)
        {
            click_Text = 27; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 11)
        {
            click_Text = 29; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 12)
        {
            click_Text = 31; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 13)
        {
            click_Text = 34; 
        }
        else if (OverallManager.Instance.PublicVariable.Day == 14)
        {
            click_Text = 37; 
        }
    }

    public override void Action()
    {
        if (OverallManager.Instance.PublicVariable.IsChoiceBoxUI == false)
        {
            click_Text++;
            // click_Text ���� ���� �ٸ� ���� ����
            switch (click_Text)
            {
                case 1:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 2:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�켱 ����ī�� �濡�� ����ī�� ���¸� Ȯ���غ���. ", 1);
                    click_Text = 100;
                    break;
                case 3:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "....", 1);
                    break;
                case 4:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���� �ķ��� ����� �ֳ�?", 1);
                    break;
                case 5:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "������� ����� ��� �ƹ��͵� �� �� ���� �Ǿ����. ", 1);
                    click_Text = 100;
                    break;
                case 6:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 7:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���÷� 3����.", 1);
                    break;
                case 8:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī�� ���� �����ְ� ������, �̷� ������ �������� ����� �� ������.. ", 1);
                    click_Text = 100;
                    break;
                case 9:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "4�� °�ΰ�.", 1);
                    break;
                case 10:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�����밡 ������� 11�� ���ҳ�..", 1);
                    break;
                case 11:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�׻����� �ķ��� �������� ��Ƶδ°� ���ھ�. ", 1);
                    click_Text = 100;
                    break;
                case 12:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "5�����α�.", 1);
                    break;
                case 13:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "��Ե� ����ī�� ������ ���纸���� �ϰ�������..", 1);
                    break;
                case 14:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���°� ���� �� �������� �־�.", 1);
                    break;
                case 15:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�̴�δ�.. ���� ��å�� ã�ƾ� ��.. ", 1);
                    click_Text = 100;
                    break;
                case 16:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..������̱���.", 1);
                    break;
                case 17:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...������ �ǹ�..������..", 1);
                    break;
                case 18:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�ű⿡ ���� ��������..", 1);
                    click_Text = 100;
                    break;
                case 19:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�������� ������.", 1);
                    break;
                case 20:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 21:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "��������, ������.", 1);
                    break;
                case 22:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "��� ���� �ž�.", 1);
                    click_Text = 100;
                    break;
                case 23:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "������ ��, ������ �� �ִ� �� �ʹۿ� ����.", 1);
                    break;
                case 24:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "������ �� ����̿���, ����ִٴ� �� �߿���.", 1);
                    click_Text = 100;
                    break;
                case 25:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���� ���ϰ� �ִ� �ɱ�..", 1);
                    break;
                case 26:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 27:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�ּ��� ������.", 1);
                    click_Text = 100;
                    break;
                case 28:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�����밡 ������� 5�� ���Ҿ�.", 1);
                    break;
                case 29:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���ݸ� �� ��Ƽ��..! ", 1);
                    click_Text = 100;
                    break;
                case 30:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�ȵ�.. �ȵ�.. ����ī!!", 1);
                    break;
                case 31:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "��.. ��.. �Ǹ��� ���.. ", 1);
                    click_Text = 100;
                    break;
                case 32:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�׷�����.. �θ���� �� ��Ǳ�,", 1);
                    break;
                case 33:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "������ �� �Ǵµ�.. ������ �ð���...", 1);
                    break;
                case 34:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...�Ͼ�.", 1);
                    click_Text = 100;
                    break;
                case 35:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 36:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "��Ʋ..", 1);
                    break;
                case 37:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "....����ī��.. ��������?", 1);
                    click_Text = 100;
                    break;
                case 38:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "....", 1);
                    break;
                case 39:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�����̱���.", 1);
                    break;
                case 40:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���� �Ϸ縸 �� ��Ƽ��..!!", 1);
                    click_Text = 100;
                    break;
                case 41:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 42:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 43:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 44:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 45:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 46:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 47:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 48:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 49:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 50:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 51:
                    break;
                case 52:
                    break;
                case 53:
                    break;
                case 54:
                    break;
                case 55:
                    break;
                case 56:
                    break;
                case 57:
                    break;
                case 58:
                    break;
                case 59:
                    break;
                case 60:
                    break;
                default:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    break;
            }
        }
    }
}

