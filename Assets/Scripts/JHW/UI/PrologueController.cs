using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PrologueController : MonoBehaviour
{
    [SerializeField]
    private Text Prologue_Text;

    private int click_Text = 0;

    void Update()
    {
        // Ŭ���̳� ZŰ �Է� �� click_Text ����
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z))
        {
            click_Text++;
            HandleClickTextChange();
        }
    }

    void HandleClickTextChange()
    {
        // click_Text ���� ���� �ٸ� ���� ����
        switch (click_Text)
        {
            case 1:
                Prologue_Text.text = null;
                Prologue_Text.DOText("...", 1);
                break;
            case 2:
                Prologue_Text.text = null;
                Prologue_Text.DOText("���� ����Į������ �Ͼ �� 17��..", 3);
                break;
            case 3:
                Prologue_Text.text = null;
                Prologue_Text.DOText("���� �ķ��� �� ������ ����. " +
                    "�̴�δ� �������� ��ƿ �� ������...", 3);
                break;
            case 4:
                Prologue_Text.text = null;
                Prologue_Text.DOText("����..! " +
                    "������..", 3);
                break;
            case 5:
                Prologue_Text.text = null;
                Prologue_Text.DOText("��..?", 1);
                break;
            case 6:
                Prologue_Text.text = null;
                Prologue_Text.DOText("XX ������ ķ������ �ȳ� �帳�ϴ�..", 3);
                
                break;
            case 7:
                Prologue_Text.text = null;
                Prologue_Text.DOText("15�� �ڿ� ���ÿ� �����밡 �İߵ� �����Դϴ�.", 3);
                
                break;
            case 8:
                Prologue_Text.text = null;
                Prologue_Text.DOText("�׷��Ƿ� ������ ������ �������� 15�� ��...", 3);
                
                break;
            case 9:
                Prologue_Text.text = null;
                Prologue_Text.DOText("����.. ������..!", 3);
               
                break;
            case 10:
                Prologue_Text.text = null;
                Prologue_Text.DOText("��Ĭ,", 1);
                
                break;
            case 11:
                Prologue_Text.text = null;
                Prologue_Text.DOText("�� �츮 ��, ���� �Ա���! �����? �� �����밡 �´ٰ�..!", 3);
                
                break;
            case 12:
                Prologue_Text.text = null;
                Prologue_Text.DOText("��..��..", 2);
                break;
            case 13:
                Prologue_Text.text = null;
                Prologue_Text.DOText("��..        " +
                    "�н�!", 1);
                break;
            case 14:
                Prologue_Text.text = null;
                Prologue_Text.DOText("����ī..? ���� ����!!", 3);
                break;
            case 15:
                Prologue_Text.text = null;
                Prologue_Text.DOText("����ī, " +
                    "����ī!!", 3);
                break;
            case 16:
                Prologue_Text.text = null;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game_Livingroom Scene");
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
                // �⺻�����δ� �ƹ� ���۵� ���� ����
                break;
        }
    }
}