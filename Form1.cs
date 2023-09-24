namespace ToDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            if(e.KeyCode == Keys.Enter)
            {
                string todo = "ÅF" + textBox1.Text;
                
                if (!string.IsNullOrEmpty(todo))
                {
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;

                    Label label = new Label();
                    label.Text = todo;

                    panel.Controls.Add(label);

                    tableLayoutPanel1.Controls.Add(panel);

                    textBox1.Clear();

                }
                
            }
            
        }
    }
}