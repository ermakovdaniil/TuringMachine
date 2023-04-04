using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turing
{
    public partial class MainForm : Form
    {
        private static List<string> alphabet = new List<string>();
        private static List<string> states = new List<string>();
        private static string currentState = "q1";
        private static int stateTableCellIndex;
        private static int stateTableRowIndex;
        private static bool stop = false;

        public MainForm()
        {
            InitializeComponent();
            for (int i = 0; i < 30; i++)
            {
                InputTable.Columns.Add(i.ToString(), "");
                InputTable.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            InputTable.Rows.Add();
            for (int i = 0; i < 30; i++)
            {
                InputTable.Rows[0].Cells[i].Value = "_";
            }
            InputTable.Enabled = false;
            StartButton.Enabled = false;
            MakeStepButton.Enabled = false;
            AddState.Enabled = false;
            RemoveState.Enabled = false;
            StopButton.Enabled = false;
            MessageBox.Show("Алгоритм работы программы:\n" +
                            "Для работы нужно указать алфавит, с которым будет работать машина.\n" +
                            "Затем ввести в ленту значения. Символ `*` является указателем на текующую ячейку в ленте. \n" +
                            "Также нужно ввести состояния в формате символ из алфавита, направление, следущее состояние.\n" +
                            "Пример ввода: 0>q2, 1<q1, hh - состояние для обозначения конца программы.\n", "Справка о программе",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InputTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn column = InputTable.Columns[e.ColumnIndex];
            if (!alphabet.Contains(e.FormattedValue.ToString()))
            {
                MessageBox.Show("Алфавит не содержит данный символ.", "Ошибка!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }      
        }

        private void StateTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn column = StateTable.Columns[e.ColumnIndex];
            if (column.Index != 0 && e.FormattedValue != "")
            {         
                string value = e.FormattedValue.ToString();
                if(value.Length >= 4)
                {
                    //var a = value[0].ToString();
                    if (!alphabet.Contains(value[0].ToString()))
                    {
                        MessageBox.Show("Алфавит не содержит данный символ.\n" +
                                        "Пример ввода: 0>q2, 1<q1, hh - состояние для обозначения конца программы.\n", "Ошибка!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    //var b = value[1].ToString();
                    if (value[1].ToString() != "<" && value[1].ToString() != ">")
                    {
                        MessageBox.Show("Неверно указано направление.\n" +
                                        "Пример ввода: 0>q2, 1<q1, hh - состояние для обозначения конца программы.\n", "Ошибка!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    string substring = value.Substring(2);
                    if (!states.Contains(substring))
                    {
                        MessageBox.Show("Неверно указано состояние.\n" +
                                        "Пример ввода: 0>q2, 1<q1, hh - состояние для обозначения конца программы.\n", "Ошибка!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else if (e.FormattedValue != "")
                {
                    e.Cancel = true;
                }                
            }
        }

        private void InputTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fristColIndex = 0;
            int lastColIndex = InputTable.ColumnCount - 1;

            foreach (DataGridViewColumn col in InputTable.Columns)
            {
                col.HeaderText = "";
            }
            DataGridViewColumn column = InputTable.Columns[e.ColumnIndex];
            column.HeaderText = "*";

            if (e.ColumnIndex == fristColIndex)
            {
                InputTable.Columns[e.ColumnIndex].HeaderText = "";
                DataGridViewColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.Name = (int.Parse(InputTable.Columns[e.ColumnIndex].Name) - 1).ToString();
                InputTable.Columns.Insert(0, newColumn);
                InputTable.Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                InputTable.Rows[0].Cells[0].Value = "_";
                InputTable.Columns[e.ColumnIndex].HeaderText = "*";
            }
            if (e.ColumnIndex == lastColIndex)
            {
                InputTable.Columns[e.ColumnIndex].HeaderText = "";
                InputTable.Columns.Add(InputTable.ColumnCount.ToString(), "");
                InputTable.Columns[lastColIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                InputTable.Rows[0].Cells[lastColIndex].Value = "_";
                InputTable.Columns[lastColIndex].HeaderText = "*";
            }
        }

        private void AlphabetTextBox_TextChanged(object sender, EventArgs e)
        {
            try {
                InputTable.Enabled = true;
                StartButton.Enabled = true;
                MakeStepButton.Enabled = true;
                AddState.Enabled = true;
                RemoveState.Enabled = true;
                alphabet.Clear();
                states.Clear();
                StateTable.Columns.Clear();
                StateTable.Columns.Add("zero", "");
                StateTable.Columns[0].ReadOnly = true;
                StateTable.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                StateTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                StateTable.Columns.Add("1", "q1");
                StateTable.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                for (int i = 0; i < AlphabetTextBox.Text.Length; i++)
                {
                    if (alphabet.Contains(AlphabetTextBox.Text[i].ToString()))
                    {
                        throw new AlphabetException();
                    }
                    alphabet.Add(AlphabetTextBox.Text[i].ToString());
                    StateTable.Rows.Add(alphabet[i]);
                    StateTable.Rows[i].HeaderCell.Value = alphabet[i];
                }
                alphabet.Add("_");
                StateTable.Rows.Add("_");
                states.Add("hh");
                states.Add("q1");
            }           
            catch (AlphabetException)
            {
                MessageBox.Show("В алфавите указаны повторяющиеся символы.", "Ошибка!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                StartButton.Enabled = false;
                MakeStepButton.Enabled = false;
                AddState.Enabled = false;
                RemoveState.Enabled = false;
            }
        }

        public class AlphabetException : ApplicationException
        {
            public AlphabetException() : base() { }
        }

        private void AddState_Click(object sender, EventArgs e)
        {
            string nameOFNewColumn = StateTable.Columns[StateTable.Columns.Count - 1].Name;
            StateTable.Columns.Add((int.Parse(nameOFNewColumn) + 1).ToString(), "q" + (int.Parse(nameOFNewColumn) + 1).ToString());
            StateTable.Columns[(int.Parse(nameOFNewColumn) + 1).ToString()].SortMode = DataGridViewColumnSortMode.NotSortable;
            states.Add("q" + (int.Parse(nameOFNewColumn) + 1).ToString());
        }

        private void RemoveState_Click(object sender, EventArgs e)
        {
            if (StateTable.CurrentCell.ColumnIndex > 1)
            {
                string nameOfColumn = StateTable.Columns[StateTable.Columns.Count - 1].Name;
                StateTable.Columns.RemoveAt(StateTable.CurrentCell.ColumnIndex);
                states.Remove("q" + (int.Parse(nameOfColumn) - 1).ToString());
            }               
        }

        private void MakeStepButton_Click(object sender, EventArgs e)
        {
            try
            {
                StateTable.Rows[stateTableRowIndex].Cells[stateTableCellIndex].Style.BackColor = Color.White;
                int inputTableCellIndex = 0;
                foreach (DataGridViewColumn col in InputTable.Columns)
                {
                    if (col.HeaderText == "*")
                    {
                        col.HeaderText = "";
                        inputTableCellIndex = col.Index;
                        break;
                    }
                }
                var cellValue = InputTable.Rows[0].Cells[inputTableCellIndex].Value;

                foreach (DataGridViewColumn col in StateTable.Columns)
                {
                    if (col.HeaderText == currentState)
                    {
                        stateTableCellIndex = col.Index;
                        break;
                    }
                }

                string operation = "";
                foreach (DataGridViewRow row in StateTable.Rows)
                {
                    if (row.Cells[0].Value.ToString() == cellValue.ToString())
                    {
                        if (row.Cells[stateTableCellIndex].Value != null)
                        {
                            operation = row.Cells[stateTableCellIndex].Value.ToString();
                            row.Cells[stateTableCellIndex].Style.BackColor = Color.GreenYellow;
                            stateTableRowIndex = row.Index;
                            break;
                        }
                        else
                        {
                            row.Cells[stateTableCellIndex].Style.BackColor = Color.Red;
                            throw new EmptyCellException();                            
                        }
                    }
                }
                var newValue = operation[0].ToString();
                var direction = operation[1].ToString();
                currentState = operation.Substring(2);

                InputTable.Rows[0].Cells[inputTableCellIndex].Value = newValue;
                if (direction == ">")
                {
                    inputTableCellIndex++;
                }
                else
                {
                    inputTableCellIndex--;
                }
                if (inputTableCellIndex < 0)
                {
                    DataGridViewColumn column = new DataGridViewTextBoxColumn();
                    column.Name = (int.Parse(InputTable.Columns[inputTableCellIndex + 1].Name) - 1).ToString();                   
                    InputTable.Columns.Insert(0, column);
                    InputTable.Columns[inputTableCellIndex + 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    InputTable.Rows[0].Cells[0].Value = "_";
                    InputTable.Columns[inputTableCellIndex + 1].HeaderText = "*";
                }
                else if (inputTableCellIndex == InputTable.ColumnCount)
                {
                    InputTable.Columns.Add(InputTable.ColumnCount.ToString(), "");
                    InputTable.Columns[inputTableCellIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                    InputTable.Rows[0].Cells[inputTableCellIndex].Value = "_";
                    InputTable.Columns[inputTableCellIndex].HeaderText = "*";
                }
                else
                {
                    InputTable.Columns[inputTableCellIndex].HeaderText = "*";
                }                
            }
            catch(EmptyCellException)
            {
                MessageBox.Show("Данная ячейка пустая.",
                                "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public class EmptyCellException : ApplicationException
        {
            public EmptyCellException() : base() { }
        }

        private async void StartButton_ClickAsync(object sender, EventArgs e)
        {
            AlphabetTextBox.Enabled = false;
            StartButton.Enabled = false;
            MakeStepButton.Enabled = false;
            AddState.Enabled = false;
            RemoveState.Enabled = false;
            StopButton.Enabled = true;
            do
            {
                if(!stop)
                {
                    MakeStepButton_Click(sender, e);
                    await Task.Delay(750);
                }
                else
                {
                    break;
                }
            } while (currentState != "hh");
            stop = false;
            AlphabetTextBox.Enabled = true;
            StartButton.Enabled = true;
            MakeStepButton.Enabled = true;
            AddState.Enabled = true;
            RemoveState.Enabled = true;
            StopButton.Enabled = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            stop = true;
        }
    }
}