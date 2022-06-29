using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject;
using DataAccess.Repository;

namespace MyStoreWinApp
{
    public partial class frmMemberDetails : Form
    {
        public frmMemberDetails()
        {
            InitializeComponent();
        }

        
        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public MemberObject MemberInfo { get; set; }

        private void frmMemberDetails_Load(object sender, EventArgs e)
        {
            cboCountry.SelectedIndex = 0;
            cboCity.SelectedIndex = 0;
            txtMemberID.Enabled = !InsertOrUpdate;
            if(InsertOrUpdate == true)
            {
                txtMemberID.Text = MemberInfo.MemberID.ToString();
                txtMemberName.Text = MemberInfo.MemberName;
                txtEmail.Text = MemberInfo.Email;
                txtPassword.Text = MemberInfo.Password;
                cboCountry.Text = MemberInfo.Country.Trim();
                cboCity.Text = MemberInfo.City.Trim();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        
    }
}
