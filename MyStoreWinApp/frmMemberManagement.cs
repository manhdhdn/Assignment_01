using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Repository;
using BusinessObject;
using DataAccess.DataAccess;

namespace MyStoreWinApp
{
    public partial class frmMemberManagement : Form
    {
        IMemberRepository memberRepository = new MemberRepository();
        BindingSource source;
        public frmMemberManagement()
        {
            InitializeComponent();
        }
       //-------------------

        private void frmMemberManagement_Load(object sender, EventArgs e)
        {           
        }

        private void Cleartext()
        {
            txtMemberID.Text = string.Empty;
            txtMemberName.Text = string.Empty;
        }

        public void LoadMemberList()
        {
            var members = memberRepository.GetMembers();
            try
            {
                source = new BindingSource();
                source.DataSource = members;

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if(members.Count() == 0)
                {
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Load member list");
            }
        }

        public void Search()
        {
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }
    }
}
