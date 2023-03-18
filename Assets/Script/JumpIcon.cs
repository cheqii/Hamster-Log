using UnityEngine;
using UnityEngine.UI;

public class JumpIcon : MonoBehaviour
{
    private GroundCheck gc;
    private Image _sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GroundCheck>().GetComponent<GroundCheck>();
        _sprite = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.GetIsGround())
        {
            _sprite.color = new Color32(255,255,225,100);
        }
        else
        {
            _sprite.color = new Color32(255,255,225,0);
        }
    }
}
