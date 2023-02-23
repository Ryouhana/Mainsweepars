using System;
using UnityEngine;
using UnityEngine.UI;

public class sanmoku : MonoBehaviour
{
    private const int Size = 3;

    private GameObject[,] _cells;

    [SerializeField]
    private Color _normalCell = Color.white;

    [SerializeField]
    private Color _selectedCell = Color.cyan;

    private int _selectedRow;
    private int _selectedColumn;

    [SerializeField]
    private Sprite _circle = null;

    [SerializeField]
    private Sprite _cross = null;

    // 現在のプレイヤー（〇か×か）
    private Sprite _currentPlayer;

    private bool _isGameOver;

    void Start()
    {
        // 初手は〇からはじめる
        _currentPlayer = _circle;

        _cells = new GameObject[Size, Size];
        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                var cell = new GameObject($"Cell({r},{c})");
                cell.transform.parent = transform;
                cell.AddComponent<Image>();
                _cells[r, c] = cell;
            }
        }
    }
    void Update()
    {
        // ゲームオーバーになったら入力拒否
        if (_isGameOver) { return; }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) { _selectedColumn--; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { _selectedColumn++; }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { _selectedRow--; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { _selectedRow++; }

        if (_selectedColumn < 0) { _selectedColumn = 0; }
        if (_selectedColumn >= Size) { _selectedColumn = Size - 1; }
        if (_selectedRow < 0) { _selectedRow = 0; }
        if (_selectedRow >= Size) { _selectedRow = Size - 1; }

        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                var cell = _cells[r, c];
                var image = cell.GetComponent<Image>();
                image.color =
                    (r == _selectedRow && c == _selectedColumn)
                    ? _selectedCell : _normalCell;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var cell = _cells[_selectedRow, _selectedColumn];
            var image = cell.GetComponent<Image>();
            if (image.sprite == null)
            {
                image.sprite = _currentPlayer;
                if (GetJudgement(_currentPlayer))
                {
                    Debug.Log($"プレイヤー {_currentPlayer.name} の勝利");
                    _isGameOver = true;
                }
                else
                {
                    _currentPlayer = _currentPlayer == _circle ? _cross : _circle;
                }
            }
        }
    }

    private bool GetJudgement(Sprite player)
        => (
            _cells[0, 0].GetComponent<Image>().sprite == player &&
            _cells[0, 1].GetComponent<Image>().sprite == player &&
            _cells[0, 2].GetComponent<Image>().sprite == player
        )
        ||
        (
            _cells[1, 0].GetComponent<Image>().sprite == player &&
            _cells[1, 1].GetComponent<Image>().sprite == player &&
            _cells[1, 2].GetComponent<Image>().sprite == player
        )
        ||
        (
            _cells[2, 0].GetComponent<Image>().sprite == player &&
            _cells[2, 1].GetComponent<Image>().sprite == player &&
            _cells[2, 2].GetComponent<Image>().sprite == player
        )
        ||
        (
            _cells[0, 0].GetComponent<Image>().sprite == player &&
            _cells[1, 0].GetComponent<Image>().sprite == player &&
            _cells[2, 0].GetComponent<Image>().sprite == player
        )
        ||
        (
            _cells[0, 1].GetComponent<Image>().sprite == player &&
            _cells[1, 1].GetComponent<Image>().sprite == player &&
            _cells[2, 1].GetComponent<Image>().sprite == player
        )
        ||
        (
            _cells[0, 2].GetComponent<Image>().sprite == player &&
            _cells[1, 2].GetComponent<Image>().sprite == player &&
            _cells[2, 2].GetComponent<Image>().sprite == player
        )
        ||
        (
            _cells[0, 0].GetComponent<Image>().sprite == player &&
            _cells[1, 1].GetComponent<Image>().sprite == player &&
            _cells[2, 2].GetComponent<Image>().sprite == player
        )
        ||
        (
            _cells[0, 2].GetComponent<Image>().sprite == player &&
            _cells[1, 1].GetComponent<Image>().sprite == player &&
            _cells[2, 0].GetComponent<Image>().sprite == player
        );
}