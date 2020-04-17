using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameMaster : MonoBehaviour
{
    // ゲームオーバー判定
    public bool IsOver;

    [SerializeField]
    private CharactorControl playerController = default;
    [SerializeField]
    private CharactorUserControl userController = default;
    [SerializeField]
    private EnemyControl enemyController = default;
    [SerializeField]
    private CameraControl cameraController = default;

    public DoorManager DoorManager;

    [SerializeField]
    private GameObject overImages = default;
    [SerializeField]
    private GameObject overMovie = default;
    private VideoPlayer videoPlayer;
    private bool isMoviePlay = false;
    private int downCount = 0;

    public bool IsNowMessage = false;

    [SerializeField]
    private MessageManager mManager = default;

    public bool isChase = false;
    public bool isFirstChaseEnd = false;

    public int FormerAreaID = 100;
    public int CurrentAreaID = 0;
    public int ChangeCount = 0;

    [SerializeField]
    private GameObject lastText = default;

    private bool isStartGame = false;

    public bool isCheckDoor = false;

    public bool IsGetKey = false;

    public bool isOpenExitDoor = false;

    public bool IsEnd = false;

    [SerializeField]
    //private bool isDebugMode = false;
    private static bool isDebugMode = false;

    public bool IsDebugMode { get => isDebugMode; set => isDebugMode = value; }

    private static bool isBugFixed = false;

    private void Start()
    {
        //if (!this.IsDebugMode)
        //{
        //    DontDestroyOnLoad(this);
        //}
        Cursor.lockState = CursorLockMode.Locked;

        if (isStartGame == false)
        {
            isStartGame = true;

            mManager.ShowText(0);

            EnemyStop();
            enemyController.gameObject.SetActive(true);
        }
        videoPlayer = overMovie.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOver)
        {
            StopAll();
            if (isMoviePlay == false)
            {
                videoPlayer.time = 0f;
                overMovie.SetActive(true);
                videoPlayer.Play();
                isMoviePlay = true;
                return;
            }
            else
            {
                if ((ulong)videoPlayer.frame == videoPlayer.frameCount)
                {
                    downCount++;
                    overImages.SetActive(true);
                }
            }
            if (Input.anyKeyDown)
            {
                if (downCount == 0)
                {
                    downCount++;
                    overImages.SetActive(true);
                    return;
                }
                else
                {
                    downCount = 0;
                    SceneManager.LoadScene(0);
                }
            }
        }
        if (IsEnd)
        {
            lastText.SetActive(false);
            StopAll();
            if (IsNowMessage == false)
            {
                if (Input.GetKeyDown(KeyCode.B) && this.IsDebugMode)
                {
                    isBugFixed = true;
                    SceneManager.LoadScene(0);
                }
                if (!isBugFixed)
                {
                    return;
                }
                else if(isBugFixed && Input.anyKeyDown)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    public void StopAll()
    {
        playerController.enabled = false;
        userController.enabled = false;
        enemyController.Pause();
        cameraController.enabled = false;
    }

    public void MoveAll()
    {
        playerController.enabled = true;
        userController.enabled = true;
        if (isChase)
        {
            enemyController.StartChase();
        }
        else
        {
            enemyController.enabled = true;
        }
        cameraController.enabled = true;
    }

    public void ChangeArea()
    {
        this.ChangeCount++;
        if (ChangeCount > 3)
        {
            if (isFirstChaseEnd == false)
            {
                StartCoroutine("FirstChaseEnd");
            }
            EnemyStop();
            ChangeCount = 0;
        }
    }

    public void EnemyStop()
    {
        isChase = false;
        enemyController.StopChase();
    }

    public void EnemyStart()
    {
        isChase = true;
        enemyController.StartChase();
    }

    private IEnumerator FirstChaseEnd()
    {
        yield return new WaitForSeconds(2);
        mManager.ShowText(3);
        DoorManager.OpenSecond();
    }

}
