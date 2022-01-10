using UnityEngine;
using UnityEngine.UI;

namespace Sudoku.UI
{
    [RequireComponent(typeof(Button))]
    public class UICell : MonoBehaviour
    {
        private Button btn;

        private void Awake()
        {
            btn = GetComponent<Button>();
        }

    }
}