using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GuideHandler : MonoBehaviour
{
    internal static GuideHandler _;

    void Awake()
    {
        _ = this;
    }
    
    
    private int _currentSlide;
    public Sprite[] slides;
    public Image slideShow;
    public Button previous;
    public Button next;
    
    
    public void Init()
    {   
        slideShow.sprite = slides[0];
        previous.interactable = false;
        next.interactable = true;
        _currentSlide = 0;
    }

    public void ShowGuide(bool show)
    {
        gameObject.SetActive(show);
    }

    public void NextSlide()
    {
        if (_currentSlide == 0)
            previous.interactable = true;
        
        _currentSlide++;
        slideShow.sprite = slides[_currentSlide];
        
        if (_currentSlide == slides.Length - 1)
            next.interactable = false;
    }

    public void PreviousSlide()
    {
        if (_currentSlide == slides.Length - 1)
            next.interactable = true;
        
        _currentSlide--;
        slideShow.sprite = slides[_currentSlide];
                
        if (_currentSlide == 0)
            previous.interactable = false;
    }
}
