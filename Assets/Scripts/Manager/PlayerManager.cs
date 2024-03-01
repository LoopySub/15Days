using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static Public_Enum;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;

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
        if (OverallManager.Instance.PublicVariable.Am_I_outside == true)
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
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
            CheckForResearchableObject();
        }
    }

    // �÷��̾ �ٶ󺸴� �������κ��� 0.5 �Ÿ� ������ ���� researchable ������Ʈ�� �ִ��� üũ�ϴ� �޼���
    void CheckForResearchableObject()
    {
        float distance = 0.5f; // ���ϴ� �Ÿ�

        // �÷��̾��� ���� ��ġ�� �ٶ󺸴� ������ ������
        Vector2 playerPosition = transform.position;
        Vector2 playerDirection = transform.right;

        // �÷��̾ �ٶ󺸴� �������� 0.5��ŭ ������ ���� ���
        Vector2 raycastOrigin = playerPosition + playerDirection * distance;

        // ����ĳ��Ʈ�� �̿��Ͽ� �ش� ��ġ�� Collider�� �ִ��� Ȯ��
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, playerDirection);

        // Collider�� �ְ�, researchable ������Ʈ�� ���� �ִ��� Ȯ��
        if (hit.collider != null)
        {
            Researchable researchableObject = hit.collider.GetComponent<Researchable>();

            if (researchableObject != null)
            {
                // researchable ������Ʈ�� ã���� �� ������ ���� �߰�
                researchableObject.Action();
            }
        }
    }

}
