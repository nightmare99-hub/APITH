using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace FrontEndOfTH7
{
    public partial class QLSP : Form
    {
        private DataGridView dataGridView = new DataGridView();
        private string link = "https://localhost:44384/";
        public QLSP()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_OnLoad()
        {

        }
        private void getloai()
        {

        }
        private List<SanPham> getdata()
        {
            List<SanPham> product = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(link);
                var respondtask = client.GetAsync("SanPhams/all");
                respondtask.Wait();
                var rs = respondtask.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readtask = rs.Content.ReadAsAsync<List<SanPham>>();
                    readtask.Wait();
                    product = readtask.Result;
                }
                else product = null;
            }
            return product;
        }

        private void QLSP_Load(object sender, EventArgs e)
        {
            var data = getdata().ToArray();
            
            foreach (var item in data)
            {
               
                dataGridView1.Rows.Add(item.Ma,item.Ten,item.DonGia,item.MaDanhMuc);
                    }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}