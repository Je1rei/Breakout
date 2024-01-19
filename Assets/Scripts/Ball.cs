using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField, Range(1, 5)] private int _live;
    [SerializeField] private int _playerScore;
    [SerializeField] private int _scoreToAdd;
    [SerializeField, Range(1f, 15f)] private float _maxSpeed;

    [SerializeField] private Text _playerScoreText;
    private Rigidbody2D _rigidbody;

    public int Live { get; private set; }

    private void Awake()
    {
        Live = _live;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();   
    }

    private void FixedUpdate()
    {
        CheckCurrentVelocity();
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
    }
    public void ResetLive()
    {
        LivesImage livesImage = FindAnyObjectByType<LivesImage>();
        Live = _live;

        livesImage.EnableLiveImage();
    }

    public void WasteLive()
    {
        LivesImage livesImage = FindAnyObjectByType<LivesImage>();

        if (Live > 0)
        {
            Live--;
            livesImage.DisableLiveImage();
        }
    }

    public void IncreaseScore()
    {
        _playerScore+= _scoreToAdd;
    }

    public void UpdatePlayerScoreText()
    {
        _playerScoreText.text = 0 + _playerScore.ToString();
    }

    private void CheckCurrentVelocity()
    {
        if(_rigidbody.velocity.magnitude >= _maxSpeed) 
        {
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
        }
    }
}
