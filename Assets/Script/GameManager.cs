using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState
{
    Title,//タイトル画面
    Start,//ゲームイベント開始
    Prepare,//ポーズ画面
    Playing,//ゲーム中
    End//ゲームクリアorゲームオーバー
}

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance;
    public static GameManager Instance { get; private set; }

    private StageManager stageManager;
    private EventManager eventManager;

    public float clearTime { get; private set; } // クリア時間
    public GameState State { get; private set; } 

    private GameState currentGameState;// 現在の状態

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        stageManager = FindAnyObjectByType<StageManager>();
        eventManager = FindAnyObjectByType<EventManager>();

        if (scene.name == "Main")
        {
            SetCurrentState(GameState.Start);
        }
    }

    void Awake()
    {
        //インスタンス作成
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SetCurrentState(GameState.Title);
    }

    private void Update()
    {
        if (currentGameState == GameState.Playing)
        {
            clearTime += Time.deltaTime;
        }
    }

    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
        State= state;
        OnGameStateChanged(currentGameState);
    }

    void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Title:
                break;
            case GameState.Start:
                StartEvent();
                break;
            case GameState.Prepare:
                Prepare();
                break;
            case GameState.Playing:
                Playing();
                break;
            case GameState.End:
                EndEvent();
                break;
            default:
                break;
        }
    }


    private void StartEvent()//最初のイベント
    {
        stageManager.EventSet();
        eventManager.StartEvent();
    }


    private void Prepare()//ポーズ画面になったら
    {
        SetCurrentState(GameState.Playing);
    }

    private void Playing()//プレイ中
    {
        stageManager.GameStart();
    }


    private void EndEvent()//ゲームクリアイベント
    {
        eventManager.EndEvent();
    }

    public void Reset()
    {
        clearTime = 0f;

    }
}
