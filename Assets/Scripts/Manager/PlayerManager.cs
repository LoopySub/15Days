using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static Public_Enum;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;

    public Researchable SelectResearchable;

    private void Awake()
    {
        // �̹� �ν��Ͻ��� �ִ��� Ȯ���ϰ�, �ִٸ� �ڽ��� �ı�
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        // �� ������Ʈ�� �ı����� �ʵ��� ����
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���� �ε�� �Ŀ� ȣ��Ǵ� �ݹ�
        transform.position = OverallManager.Instance.PublicVariable.NextCoordinate;
        OverallManager.Instance.UiManager.textRenewal();
        Invoke("DayChangeTextOff", 0.5f);
        Invoke("IsRestOff", 0.5f);
        


        if(OverallManager.Instance.PublicVariable.IsRest == true)
        {
            OverallManager.Instance.UiManager.HideDialog();
            OverallManager.Instance.PublicVariable.IsRest = false;
        }

        if (OverallManager.Instance.PublicVariable.Am_I_outside == true)
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1.0f);
            OverallManager.Instance.PublicVariable.CurrentHour += 1;

        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if(OverallManager.Instance.PublicVariable.Ending_Type ==Ending_type.None && OverallManager.Instance.PublicVariable.CurrentHour == 8 && OverallManager.Instance.PublicVariable.Am_I_outside ==false && OverallManager.Instance.PublicVariable.IsDM ==false)
        {
            Invoke("Morning_Monologue", 0.6f);
        }
    }

    void Morning_Monologue()
    {
        if (SelectResearchable == null)
        {
            OverallManager.Instance.PublicVariable.IsDM = true;
            SelectResearchable = OverallManager.Instance.UiManager.morning_monologue;
            SelectResearchable.Click_Text_Reset();
            SelectResearchable.Action();
        }
    }


    public void playerSetActive(GameState gameState)
    {
            if (gameState == GameState.Cutscene)
            {
                // Cutscene ������ ���
                gameObject.SetActive(false);
            }
            else
            {
                // �� ���� ���
                gameObject.SetActive(true);
            }
    }



    // �÷��̾ 'Z' Ű�� ������ �� ȣ��Ǵ� �޼���
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (SelectResearchable != null)
            {
                if (OverallManager.Instance.PublicVariable.IsDialog == true)
                {
                    SelectResearchable.Action();
                }
            }
            else
            {
                CheckForResearchableObject();
            }
        }
    }

    void DayChangeTextOff()
    {
        OverallManager.Instance.UiManager.DayChangeTextOn(false);
        Time.timeScale = 1.0f;
    }

    void IsRestOff()
    {
        OverallManager.Instance.PublicVariable.IsRest = false;
        Time.timeScale = 1.0f;
    }

    public void ResetRch()
    {
        SelectResearchable = null;
    }

    void CheckForResearchableObject()
    {
        float maxDistance = 0.5f; // ���ϴ� �Ÿ�

        // �÷��̾��� ���� ��ġ ������
        Vector2 playerPosition = transform.position;

        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // �÷��̾�� ���콺�� ���ϴ� ���� ���
        Vector2 playerToMouseDirection = (mousePosition - playerPosition).normalized;

        // �÷��̾�� ���콺 �������� �ִ� �Ÿ������� ��ǥ ���
        Vector2 targetPosition = playerPosition + playerToMouseDirection * maxDistance;

        // �ش� ��ġ�� Collider�� �ִ��� Ȯ��
        Collider2D[] colliders = Physics2D.OverlapCircleAll(targetPosition, 0.1f); // ���� ���� �˻�

        // Researchable ������Ʈ�� ���� �ִ��� Ȯ��
        foreach (var collider in colliders)
        {
            SelectResearchable = collider.GetComponent<Researchable>();
            if (SelectResearchable != null)
            {
                // Researchable ������Ʈ�� ã���� �� ������ ���� �߰�
                SelectResearchable.Action();
                break; // ���� ���� ������Ʈ �� �ϳ��� �����Ϸ��� break �߰�
            }
        }
    }
}
