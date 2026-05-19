using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.EventSystems;
public enum GameState
{
    Title,//タイトル画面
    Begin,//最初のシーン（ゲームスタート前）
    Start,//情報リセット用
    Prepare,//ポーズ画面
    Playing,//ゲーム中
    End//ゲームクリアorゲームオーバー
}

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance;
    public static GameManager Instance { get; private set; }

    public StageManager stageManager;
    public GameState State { get; private set; } = GameState.Begin;

    public UIManager UI;

    public int CurrentFloor;
    private GameState currentGameState;// 現在の状態

    void Awake()
    {
        //インスタンス作成
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SetCurrentState(GameState.Begin);
    }

    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Title:

                break;
            case GameState.Begin:
                Begin();
                break;
            case GameState.Start:
                StartEvent();
                break;
            case GameState.Prepare:
                StartCoroutine(PrepareCoroutine());
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


    void StartEvent()
    {
        UI.UIStartEvent();
        
    }

    //
    void Begin()
    {
        stageManager.EventSet();
    }

    // Prepareになったときの処理
    IEnumerator PrepareCoroutine()
    {
        yield return new WaitForSeconds(1);
        SetCurrentState(GameState.Playing);
    }
    // Playingになったときの処理
    void Playing()
    {
        
    }
    // Endになったときの処理
    void EndEvent()
    {
    }
}
