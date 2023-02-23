using UnityEngine;
using UnityEngine.UI;

public class Minesweeper : MonoBehaviour
{
    [SerializeField]
    private int _rows = 1;

    [SerializeField]
    private int _columns = 1;

    [SerializeField]
    private int _mineCount = 1;

    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;

    [SerializeField]
    private Cell _cellPrefab = null;

    private Cell[,] _cells;

    void Start()
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _columns;

        // �v���n�u����Z���𐶐�����
        var parent = _gridLayoutGroup.gameObject.transform;
        _cells = CreateCells(_rows, _columns, parent);

        // �n����ݒu����
        InitializeCells(_mineCount);
    }

    private void InitializeCells(int mineCount)
    {
        if (mineCount > _cells.Length)
        {
            Debug.LogError($"�n�����̓Z������菭�Ȃ��ݒ肵�Ă�������\n" +
                $"�n����={mineCount}, �Z����={_cells.Length}");
            return;
        }

        // ���ׂẴZ���̏�Ԃ� None �ɂ���B
        ClearCells();
        HideCell(_rows, _columns);
        for (var i = 0; i < mineCount; i++)
        {
            var r = Random.Range(0, _rows);
            var c = Random.Range(0, _columns);
            var cell = _cells[r, c];

            // �����_���ɑI�΂ꂽ�Z�����n�����ǂ���
            if (cell.CellState == CellState.Mine)
            {
                Debug.Log("�d�������̂ōĒ��I");
                i--;
            }
            else { cell.CellState = CellState.Mine; }
        }

        // �n���̐��𐔂���
        for (var r = 0; r < _rows; r++)
        {
            for (var c = 0; c < _columns; c++)
            {
                var cell = _cells[r, c];
                cell.CellState = GetMineCount(r, c);
            }
        }
    }

    private void ClearCells()
    {
        foreach (var cell in _cells)
        {
            cell.CellState = CellState.None;
        }
    }

    private Cell[,] CreateCells(int rows, int columns, Transform parent)
    {
        var cells = new Cell[_rows, _columns];
        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < columns; c++)
            {
                var cell = Instantiate(_cellPrefab);
                cell.transform.SetParent(parent);
                cells[r, c] = cell;
            }
        }
        return cells;
    }

    private CellState GetMineCount(int row, int column)
    {
        var cell = _cells[row, column];
        if (cell.CellState == CellState.Mine) { return CellState.Mine; }

        // ���͂̃Z���̒n���̐��𐔂���
        var count = 0;

        var up = row - 1;
        var down = row + 1;
        var left = column - 1;
        var right = column + 1;

        if (IsMine(up, left)) { count++; } // ����
        if (IsMine(up, column)) { count++; } // ��
        if (IsMine(up, right)) { count++; } // �E��
        if (IsMine(row, left)) { count++; } // ��
        if (IsMine(row, right)) { count++; } // �E
        if (IsMine(down, left)) { count++; } // ����
        if (IsMine(down, column)) { count++; } // ��
        if (IsMine(down, right)) { count++; } // �E��

        return (CellState)count;
   
    }

    private bool IsMine(int row, int column)
    {
        if (row >= 0 && row < _rows && column >= 0 && column < _columns)
        {
            return _cells[row, column].CellState == CellState.Mine;
        }
        else
        {
            return false;
        }
    }
    private void HideCell(int row, int column)
    {
        var cell = _cells[row, column];
        cell.gameObject.SetActive(false);
    }

}
