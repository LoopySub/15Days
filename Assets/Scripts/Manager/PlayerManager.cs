using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Public_Enum;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;

    private void Awake()
    {
        // 이미 인스턴스가 있는지 확인하고, 있다면 자신을 파괴
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        // 이 오브젝트를 파괴되지 않도록 설정
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
                // Cutscene 상태인 경우
                gameObject.SetActive(false);
            }
            else
            {
                // 그 외의 경우
                gameObject.SetActive(true);
            }
    }
}
