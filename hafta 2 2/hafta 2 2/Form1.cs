namespace hafta_2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool surukleniyor = false;
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            surukleniyor = true;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            surukleniyor = false;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (surukleniyor)
            {
                var mousePos = this.PointToClient(Cursor.Position);
                button1.Left = mousePos.X - button1.Width / 2;
                button1.Top = mousePos.Y - button1.Height / 2;
            }
        }
    }
}
