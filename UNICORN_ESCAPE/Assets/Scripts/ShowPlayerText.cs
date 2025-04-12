using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerText : MonoBehaviour
{
    [SerializeField]
    private Text playerText;
    [SerializeField]
    private string animationName = "ShowText";
    private Animator textAnimator;

    private void Start()
    {
        textAnimator = playerText.GetComponent<Animator>();
    }

    public void ShowText(string text)
    {
        playerText.text = text;
        textAnimator.Play(animationName);
    }
}
