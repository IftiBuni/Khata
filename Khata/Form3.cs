using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Khata
{

    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-4PO5R29;Initial Catalog=Khata;Integrated Security=True");
        public int KhataNo;
        public int remain;
        public int Paid;
        public int Total;
        public void Remaining()
        {
            if (Convert.ToInt32(textBox7.Text)>0)
            {
                
                Paid = Convert.ToInt32(textBox7.Text);
                Total = Convert.ToInt32(textBox1.Text);
                remain = Total - Paid;
                textBox6.Text = Convert.ToString(remain);
            }
            else
            {

            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            GetCostumerInfo();
        }

        private void GetCostumerInfo()
        {
            
            SqlCommand cmd = new SqlCommand("select * from Costumer", con);
            DataTable Dt = new DataTable();
            con.Open();
            SqlDataReader sdr=cmd.ExecuteReader();
            Dt.Load(sdr);
            con.Close();
            dataGridView1.DataSource = Dt;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (IsValid()) ;
            SqlCommand cmd = new SqlCommand("INSERT INTO Costumer VALUES (@Name,@PhoneNo,@Location,@CnicNo,@RemainingAmount,@PaidAmount,@Date,@TotalAmount)", con);
            cmd.CommandType = CommandType.Text;
            Remaining();

            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", textBox3.Text);
            cmd.Parameters.AddWithValue("@Location", textBox4.Text);
            cmd.Parameters.AddWithValue("@CnicNo", textBox5.Text);
            cmd.Parameters.AddWithValue("@RemainingAmount", textBox6.Text);
            cmd.Parameters.AddWithValue("@PaidAmount", textBox7.Text);
            cmd.Parameters.AddWithValue("@Date", textBox8.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", textBox1.Text);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("New Costumer Successfully Added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetCostumerInfo();
            ResetFormText();

        }

        private bool IsValid()
        {
            if(textBox2.Text == String.Empty)
            {
                MessageBox.Show("Student Name Is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetFormText();
        }

        private void ResetFormText()
        {
            KhataNo = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            KhataNo = Convert.ToInt32 (dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox2.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsValid()) ;
            Remaining();

            SqlCommand cmd = new SqlCommand("UPDATE  Costumer SET Name=@Name,PhoneNo=@PhoneNo,Location=@Location,CnicNo=@CnicNo,AmountRemaining=@AmountRe,AmountPaid=@AmountPaid,Date=@Date,TotalAmount=@TotalAmount WHERE KhataNo=@ID", con);
                cmd.CommandType = CommandType.Text;

               
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", textBox3.Text);
                cmd.Parameters.AddWithValue("@Location", textBox4.Text);
                cmd.Parameters.AddWithValue("@CnicNo", textBox5.Text);
                cmd.Parameters.AddWithValue("@AmountRe", textBox6.Text);
                cmd.Parameters.AddWithValue("@AmountPaid", textBox7.Text);
                cmd.Parameters.AddWithValue("@Date", textBox8.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", textBox1.Text);
            cmd.Parameters.AddWithValue("@ID", this.KhataNo);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Costumer Info Updated Successfully ", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCostumerInfo();
                ResetFormText();
              

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IsValid()) ;
           
            SqlCommand cmd = new SqlCommand("Delete From Costumer WHERE KhataNo=@KhataNo", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@KhataNo",this.KhataNo);
           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Costumer Successfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetCostumerInfo();
            ResetFormText();

        }
    }
}
