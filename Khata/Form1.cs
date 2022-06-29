namespace Khata
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
           
            if (this.textBox1.Text== "admin" && this.textBox2.Text=="1234")
            {
               new Form3().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error");
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}