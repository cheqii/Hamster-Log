using UnityEngine;

public class UIManager : MonoBehaviour
{
    private LogControl _logControl;
    private LevelSelect _levelSelect;
    private GameManager _gameManager;
    
    [Header("Start Button")] 
    [SerializeField] private GameObject[] St_Close;
    [SerializeField] private GameObject[] St_Open;
    
    [Header("Shop Button")] 
    [SerializeField] private GameObject[] Sh_Close;
    [SerializeField] private GameObject[] Sh_Open;

    [Header("Start Game Button")] 
    [SerializeField] private GameObject[] Sg_Close;
    [SerializeField] private GameObject[] Sg_Open;
    
    [Header("You Win Ui")] 
    [SerializeField] private GameObject[] Uw_Close;
    [SerializeField] private GameObject[] Uw_Open;
    
    [Header("Back Button")] 
    [SerializeField] private GameObject[] Ba_Close;
    [SerializeField] private GameObject[] Ba_Open;
    
    [Header("Credit Button")] 
    [SerializeField] private GameObject[] Cr_Close;
    [SerializeField] private GameObject[] Cr_Open;

    
    private void Start()
    {
        _logControl = FindObjectOfType<LogControl>().GetComponent<LogControl>();
        _levelSelect= FindObjectOfType<LevelSelect>().GetComponent<LevelSelect>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    public void StartButton()
    {
        OpenAndClose(St_Close, St_Open);
        SoundManager.Instance.PlayOpenUi();
    }
    
    public void CreditsButton()
    {
        OpenAndClose(Cr_Close, Cr_Open);
        SoundManager.Instance.PlayOpenUi();
    }
    
    public void BackButton()
    {
        OpenAndClose(Ba_Close, Ba_Open);
        SoundManager.Instance.PlayBackUi();
    }
    
    public void ShopButton()
    {
        OpenAndClose(Sh_Close, Sh_Open);
        SoundManager.Instance.PlayOpenUi();

        
    }


    public void StartGame()
    {
        OpenAndClose(Sg_Close, Sg_Open);
        _logControl.HamsterStart();
        SoundManager.Instance.PlayOpenUi();
        SoundManager.Instance.PlayOKHEREWEGO();

    }

    public void YouWin()
    {
        OpenAndClose(Uw_Close, Uw_Open);
        SoundManager.Instance.StopSound();
        SoundManager.Instance.PlayWin();

    }
    
    

    private void OpenAndClose(GameObject[] close, GameObject[] open)
    {
        foreach (var i in close)
        {
            i.SetActive(false);
        }
        foreach (var i in open)
        {
            i.SetActive(true);
        }
    }
}
