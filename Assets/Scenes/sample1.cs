using UnityEngine;
using UnityEngine.UI;

public class sample1 : MonoBehaviour
{
    [SerializeField]
    private int _count = 5;

    private Image[] _images;
    private int _selectedIndex = 0;

    void Start()
    {
        _images = new Image[_count];
        for (var i = 0; i < _images.Length; i++)
        {
            var obj = new GameObject($"Cell{i}");
            obj.transform.parent = transform;

            var image = obj.AddComponent<Image>();
            _images[i] = image;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // 左キーを押した
        {
            _selectedIndex--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // 右キーを押した
        {
            _selectedIndex++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_images[_selectedIndex])
            {
                Destroy(_images[_selectedIndex]);
                _selectedIndex++;
            }
        }

        if (_selectedIndex < 0) { _selectedIndex = 0; }
        if (_selectedIndex >= _images.Length)
        {
            _selectedIndex = _images.Length - 1;
        }

        for (var i = 0; i < _images.Length; i++)
        {
            if (!_images[i]) { continue; }

            if (i == _selectedIndex) { _images[i].color = Color.red; }
            else { _images[i].color = Color.white; }
        }
    }
}