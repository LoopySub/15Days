using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Researchable
{ 
    public override void Click_Text_Reset()
    {
        if (OverallManager.Instance.PublicVariable.Day == 1)
        {
            click_Text = 4;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 2)
        {
            click_Text = 8;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 3)
        {
            click_Text = 13;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 4)
        {
            click_Text = 16;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 5)
        {
            click_Text = 21;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 6)
        {
            click_Text = 25;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 7)
        {
            click_Text = 30;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 8)
        {
            click_Text = 36;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 9)
        {
            click_Text = 41;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 10)
        {
            click_Text = 43;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 11)
        {
            click_Text = 47;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 12)
        {
            click_Text = 50;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 13)
        {
            click_Text = 59;
        }
        else if (OverallManager.Instance.PublicVariable.Day == 14)
        {
            click_Text = 64;
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
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ ������ ����?", 1);
                    break;
                case 2:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ �����մϴ�. 3�ð� / ���¹̳� 20 ���", 1);
                    OverallManager.Instance.UiManager.ShowChoiceBox();
                    break;
                case 3:
                    if (OverallManager.Instance.PublicVariable.IsChoice == true)
                    {
                        if (OverallManager.Instance.PublicVariable.IsDayRadio == true)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "������ �� ������ ���� ������ �� ����.", 1);
                            click_Text = 3;
                            break;
                        }
                        if(OverallManager.Instance.PublicVariable.Stamina < 20)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "", "���¹̳��� �����մϴ�.", 1);
                            click_Text = 3;
                            break;

                        }
                        else if(OverallManager.Instance.PublicVariable.CurrentHour >=22)
                        {
                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���� �ʹ� �ʾ���.", 1);
                        }
                        else
                        {

                            OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "����.. ������..", 1);
                            Click_Text_Reset();
                        }
                    }
                    else
                    {
                        OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..������ ����.", 1);
                        click_Text = 3;
                    }
                    break;
                case 4:
                    OverallManager.Instance.UiManager.HideDialog();
                    resetSelectRch();
                    click_Text = 0;
                    break;
                case 5:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ �ҽ���...", 1);
                    break;
                case 6:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "����- ������..!", 1);
                    break;
                case 7:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "���İ� �� ��������...", 1);
                    click_Text = 1000;
                    break;
                case 8:
                    click_Text = 3;
                    break;
                case 9:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ ���� ķ�� ����!", 1);
                    break;
                case 10:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "����..! ���� ���� �����ϴٸ�,", 1);
                    break;
                case 11:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "��ó�� ��Ʈ, ������ ���� ��������.", 1);
                    break;
                case 12:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���� �����ڵ��� ���� ���� �ΰ��� ���� �����ϱ�! ", 1);
                    break;
                case 13:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..�׷�����.", 1);
                    click_Text = 1000;
                    break;
                case 14:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "[���ִ� ��Ʈ���ڸ� ��~ �ε巴�� ��ŭ�� ��Ʈ���ڸ� ��~ ]", 1);
                    break;
                case 15:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "[��Ʈ���ڸ� �� ��ѱ� �����..] ����.. ������..!", 1);
                    break;
                case 16:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "��Ʈ���ڸ� ��.. �ǿܷ� ����������? ", 1);
                    click_Text = 1000;
                    break;
                case 17:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ �ҽ��Դϴ�. ", 1);
                    break;
                case 18:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���δ� ���� ���¸� �ܰ����������� ���븦 ������ ������ ������ �ֽ��ϴ�.", 1);
                    break;
                case 19:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���� �������� �ù� ��ü���� �� �������� �߻��ϴ� �ǵ�ġ ���� �ΰ��� �л��� �����ϸ�..", 1);
                    break;
                case 20:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "����.. ������..!", 1);
                    break;
                case 21:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..���İ� �����. ", 1);
                    click_Text = 1000;
                    break;
                case 22:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���� ���̷����� ���� õõ�� ����س����� ������ ���̷����Դϴ�. ", 1);
                    break;
                case 23:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���а迡���� �� ���̷����� �������� ���������� ����� �и��ϴٴ� ������ ��ġ�� ������..,", 1);
                    break;
                case 24:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "����.. ����..!", 1);
                    break;
                case 25:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�̷� �� ����������!!!", 1);
                    click_Text = 1000;
                    break;
                case 26:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "����- ������..!", 1);
                    break;
                case 27:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���ξ��� ���ڿ� �����ƿ� ��ġ�� ���� ����ǰ!!", 1);
                    break;
                case 28:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "��ġ-���ξ��� ��ġ ����!!", 1);
                    break;
                case 29:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���� �ٷ� �ֹ��ϼ���! ", 1);
                    break;
                case 30:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...���ְڴµ�?", 1);
                    click_Text = 1000;
                    break;
                case 31:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "����.. ������..!!", 1);
                    break;
                case 32:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���δ� ���ο� ��ħ����, ������ �ù��� ���� ����� ���� �����߽��ϴ�.", 1);
                    break;
                case 33:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ �̸� �ѷ��ΰ� �����.. ���.. ����..!", 1);
                    break;
                case 34:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..����� ���� ���̴°� ����. ��.", 1);
                    break;
                case 35:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�����̳� �ٸ� ���� ����̴ϱ�.", 1);
                    break;
                case 36:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "����ī..", 1);
                    click_Text = 1000;
                    break;
                case 37:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ ���� �Ұ� �ڳ� - [��-���屹]!!", 1);
                    break;
                case 38:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "��ŭ�� �ְ� ������ ������ ȯ������ ����!", 1);
                    break;
                case 39:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���� ��ó �������� ����������! ", 1);
                    break;
                case 40:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...", 1);
                    break;
                case 41:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�������.", 1);
                    click_Text = 1000;
                    break;
                case 42:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "����- ������..!!!", 1);
                    break;
                case 43:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ ���İ� ������ �ʴ� �� ����.", 1);
                    click_Text = 1000;
                    break;
                case 44:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���� XX���� �����Ҹ� �����ϴ� �ߡ�ȸ���� �ڽŰ� ���̷����� �ƹ� ������ ���ٰ� ����������..", 1);
                    break;
                case 45:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "����.. ������-!!", 1);
                    break;
                case 46:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�������.", 1);
                    break;
                case 47:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...������ �� ���̴�, ����и� ������ �� ����.", 1);
                    click_Text = 1000;
                    break;
                case 48:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "..���ΰ� ���� �����밡 �������� �ùε��� �����ϰ� �ֽ��ϴ�. ", 1);
                    break;
                case 49:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "�׵��� �����Ǿ �ȵ��� �� ������ �������δ� ������ ���� ���Ŀ�... ", 1);
                    break;
                case 50:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "�츮�� ���ݸ� �� ��Ƽ��.. ����� ����.", 1);
                    click_Text = 1000;
                    break;
                case 51:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "ġ��ġ�� ��������\r\nChipi chipi chapa chapa", 1);
                    break;
                case 52:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "�κ�κ� �ٹٴٹ�\r\nDubi dubi daba daba", 1);
                    break;
                case 53:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ ���� �κ�κ�\r\nMagico mi dubi dubi", 1);
                    break;
                case 54:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "��, ��, ��, ��\r\nBum, bum, bum, bum", 1);
                    break;
                case 55:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "ġ��ġ�� ��������\r\nChipi chipi chapa chapa", 1);
                    break;
                case 56:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "�κ�κ� �ٹٴٹ�\r\nDubi dubi daba daba", 1);
                    break;
                case 57:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "������ ���� �κ�κ�\r\nMagico mi dubi dubi", 1);
                    break;
                case 58:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "��\r\nBum ", 1);
                    break;
                case 59:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..���� �� �������� ��ġ�� �뷡��? ", 1);
                    click_Text = 1000;
                    break;
                case 60:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "�Ӻ��Դϴ�.", 1);
                    break;
                case 61:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "�ߡ�ȸ���� �ڽ��� �η� ��ȭ ��ȹ�� ���ļ��󿡼� ��ǥ�߽��ϴ�. ", 1);
                    break;
                case 62:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "�״� ���ù��� �ڸ��� �� ������ �� ���ϰ� ������ ������ ������ �ʴ�", 1);
                    break;
                case 63:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "��ȭ�� �η��� �� ���̶�� ���������� ���忡 ������� �޽��ϸ鼭 �Ƽ������� �Ǿ���.. ����-!! ", 1);
                    break;
                case 64:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "...���� ���� �� ��������?", 1);
                    click_Text = 1000;
                    break;
                case 65:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���� ��ħ �� �����밡 ������ �������� ����,", 1);
                    break;
                case 66:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "���� �ǽ��� �����ִ� �ùε� ����ϴ� ������ �˷����鼭", 1);
                    break;
                case 67:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "�����ڵ� ���̿��� ȥ���� �ϰ� �ֽ��ϴ�.", 1);
                    break;
                case 68:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "�׸��� �ߡ�ȸ���� �������ϱ� ���� �����忡�� �� �߾��� �����.. ����..!", 1);
                    break;
                case 69:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "�ߡ�ȸ��", "��� ���̳�? ���Ѵٸ� �ֵ��� ����... ã�ƶ�! �� ������ ��� ���� �ű⿡ �ΰ� ������!", 1);
                    break;
                case 70:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Jone, "��", "..��?", 1);
                    click_Text = 1000;
                    break;
                case 71:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 72:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 73:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 74:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 75:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 76:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 77:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 78:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 79:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 80:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 81:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 82:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 83:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 84:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 85:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 86:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 87:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 88:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 89:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 90:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 91:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 92:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 93:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 94:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                case 95:
                    OverallManager.Instance.UiManager.ShowDialog(Public_Enum.Icon_type.Null, "����", "...", 1);
                    break;
                default:
                    OverallManager.Instance.UiManager.HideDialog();
                    OverallManager.Instance.PublicVariable.Stamina -= 20;
                    OverallManager.Instance.PublicVariable.CurrentHour += 3;
                    OverallManager.Instance.PublicVariable.IsDayRadio = true;
                    resetSelectRch();
                    click_Text = 0;
                    break;
            }
        }
    }
}