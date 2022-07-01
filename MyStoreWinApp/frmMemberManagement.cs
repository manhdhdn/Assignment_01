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
        readonly IMemberRepository memberRepository = new MemberRepository();
        BindingSource source = null!;
        public frmMemberManagement()
        {
            InitializeComponent();
        }
        //-------------------

        private void FrmMemberManagement_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
            btnDelete.Enabled = false;
            dgvMemberList.CellDoubleClick += DgvMemberList_CellDoubleClick;
        }

        private void DgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMemberDetails frmMemberDetails = new frmMemberDetails
            {
                Text = "Update member profile",
                InsertOrUpdate = true,
                MemberInfo = GetMemberObject(),
                MemberRepository = memberRepository,
            };
            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }

        private void Cleartext()
        {
            txtMemberID.Text = string.Empty;
            txtMemberName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtCountry.Text = string.Empty;
        }

        private MemberObject GetMemberObject()
        {
            MemberObject memberObject = null!;
            try
            {
                memberObject = new MemberObject
                {
                    MemberID = int.Parse(txtMemberID.Text),
                    MemberName = txtMemberName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Country = txtCountry.Text,
                    City = txtCity.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");
            }
            return memberObject;
        }

        public void LoadMemberList()
        {
            var members = memberRepository.GetMembers(null, null, null);
            try
            {
                source = new BindingSource
                {
                    DataSource = members
                };

                txtMemberID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtCity.DataBindings.Clear();

                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtMemberName.DataBindings.Add("Text", source, "MemberName");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtCity.DataBindings.Add("Text", source, "City");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (!members.Any())
                {
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }
        public void Filter()
        {
            try
            {
                var Filter = memberRepository.GetMembers(null, cboFilterCountry.Text == "" ? null : cboFilterCountry.Text, cboFilterCity.Text == "" ? null : cboFilterCity.Text);
                source = new BindingSource { DataSource = Filter };

                txtMemberID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtCity.DataBindings.Clear();

                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtMemberName.DataBindings.Add("Text", source, "MemberName");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtCity.DataBindings.Add("Text", source, "City");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (!Filter.Any())
                {
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filer member list");
            }
        }

        public void SearchByID()
        {
            try
            {
                var search = memberRepository.GetMember(int.Parse(txtSearch.Text), null, null);
                if (search == null)
                {
                    throw new Exception("Not found.");
                }
                source = new BindingSource
                {
                    DataSource = search
                };

                txtMemberID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtCity.DataBindings.Clear();

                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtMemberName.DataBindings.Add("Text", source, "MemberName");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtCity.DataBindings.Add("Text", source, "City");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (search == null)
                {
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search member by ID");
            }
        }

        public void SearchByName()
        {
            try
            {
                var search = memberRepository.GetMembers(txtSearch.Text, null, null);
                source = new BindingSource
                {
                    DataSource = search
                };

                txtMemberID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtCity.DataBindings.Clear();

                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtMemberName.DataBindings.Add("Text", source, "MemberName");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtCity.DataBindings.Add("Text", source, "City");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;

                if (search == null)
                {
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search member by Name");
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (cboSearch.Text == "Member ID")
            {
                SearchByID();
            }
            if (cboSearch.Text == "Member Name")
            {
                SearchByName();
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmMemberDetails frmMemberDetails = new frmMemberDetails
            {
                Text = "Add new member",
                InsertOrUpdate = false,
                MemberRepository = memberRepository
            };
            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var member = GetMemberObject();
                memberRepository.DeleteMember(member.MemberID);
                LoadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a member");
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }
    }
}
