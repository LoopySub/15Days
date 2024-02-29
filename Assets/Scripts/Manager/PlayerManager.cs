using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
