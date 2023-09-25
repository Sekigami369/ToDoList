namespace ToDoList
{
    public partial class Form1 : Form
    {

        Label label;
        Panel panel;
        int row;
        int column;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.SaddleBrown;
            this.ForeColor = Color.SaddleBrown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string todo = "：　" + textBox1.Text;

                if (!string.IsNullOrEmpty(todo))
                {
                    float fontSize = 12;
                    label = new Label();
                    label.Text = todo;
                    label.Dock = DockStyle.Fill;
                    label.MouseDown += Label_Click;
                    label.BackColor = Color.GhostWhite;
                    label.Font = new Font(label.Font.FontFamily, fontSize, label.Font.Style);
                    label.Font = new Font(label.Font, label.Font.Style | FontStyle.Bold);
                    label.TextAlign = ContentAlignment.MiddleCenter;

                    tableLayoutPanel1.Controls.Add(label, 0, 0);

                    textBox1.Clear();
                }
            }
        }

        private void Label_Click(object sender, MouseEventArgs e)
        {
            Label clickedLabel = (Label)sender;
            Font originalFont = clickedLabel.Font;

            //右クリックで表示したテキストを削除する
            if (e.Button == MouseButtons.Right)
            {
                if (clickedLabel != null)
                {
                    row = tableLayoutPanel1.GetRow(clickedLabel);
                    column = tableLayoutPanel1.GetColumn(clickedLabel);

                    Control control = tableLayoutPanel1.GetControlFromPosition(column, row);


                    tableLayoutPanel1.Controls.Remove(control);
                    control.Dispose();
                }
            }

            //左クリックで表示したテキストに取り消し線を入れる
            else if (e.Button == MouseButtons.Left)
            {
                if (clickedLabel != null)
                {
                    row = tableLayoutPanel1.GetRow(clickedLabel);
                    column = tableLayoutPanel1.GetColumn(clickedLabel);

                    //Control control = tableLayoutPanel1.GetControlFromPosition(column, row);
                    if (!clickedLabel.Font.Style.HasFlag(FontStyle.Strikeout))
                    {
                        clickedLabel.Font = new Font(clickedLabel.Font, clickedLabel.Font.Style | FontStyle.Strikeout);
                    }
                    else if (clickedLabel.Font.Style.HasFlag(FontStyle.Strikeout))
                    {
                        clickedLabel.Font = new Font(originalFont, originalFont.Style & ~FontStyle.Strikeout);
                    }
                }
            }
        }
    }
}