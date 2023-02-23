using UnityEngine;
using UnityEngine.UI;

public class kadai2 : MonoBehaviour
{
    [SerializeField]
    private int _rows = 5;

    [SerializeField]
    private int _columns = 5;

    private Image[,] _images;
    private int _selectR = 0; // �s�ԍ�
    private int _selectC = 0; // ��ԍ�

    private void Start()
    {
        var layout = GetComponent<GridLayoutGroup>();
        layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        layout.constraintCount = _columns;

        _images = new Image[_rows, _columns];
        for (var r = 0; r < _images.GetLength(0); r++)
        {
            for (var c = 0; c < _images.GetLength(1); c++)
            {
                var obj = new GameObject($"Cell({r}, {c})");
                obj.transform.parent = transform;

                var image = obj.AddComponent<Image>();
                _images[r, c] = image;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // ���L�[��������
        {
            _selectC--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // �E�L�[��������
        {
            _selectC++;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) // ��L�[��������
        {
            _selectR--;

            if (Input.GetKeyDown(KeyCode.DownArrow)) // ���L�[��������
            {
                _selectR++;
            }

            for (var r = 0; r < _images.GetLength(0); r++)
            {
                for (var c = 0; c < _images.GetLength(1); c++)
                {
                    var image = _images[r, c];
                    if (r == _selectR && c == _selectC)
                    {
                        image.color = Color.red;
                    }
                    else { image.color = Color.white; }
                }
            }
        }
    }
}




































































































