using DataAccess.Repository;
using BusinessObject;

namespace MyStoreWinApp
{
    public partial class FrmMemberManagement : Form
    {
        public IMemberRepository MemberRepository { get; set; } = null!;
        BindingSource source = null!;

        public FrmMemberManagement()
        {
            InitializeComponent();
        }

        private void FrmMemberManagement_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
            btnDelete.Enabled = false;
        }

        private void DgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmMemberDetails frmMemberDetails = new()
            {
                Text = "Update member profile",
                InsertOrUpdate = true,
                MemberInfo = GetMemberObject(),
                MemberRepository = MemberRepository,
            };

            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
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
            try
            {
                var members = MemberRepository.GetMembers(null, null, null);
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
                var Filter = MemberRepository.GetMembers(null, cboFilterCountry.Text == "" ? null : cboFilterCountry.Text, cboFilterCity.Text == "" ? null : cboFilterCity.Text);
                source = new BindingSource
                {
                    DataSource = Filter
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
                var search = MemberRepository.GetMember(int.Parse(txtSearch.Text), null, null);
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
                var search = MemberRepository.GetMembers(txtSearch.Text, null, null);
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
            FrmMemberDetails frmMemberDetails = new()
            {
                Text = "Add new member",
                InsertOrUpdate = false,
                MemberRepository = MemberRepository
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
                MemberRepository.DeleteMember(member.MemberID);
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

        private void CboFilterCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFilterCity.SelectedIndex = -1;

            switch (cboFilterCountry.SelectedIndex)
            {
                case 0:
                    cboFilterCity.Items.Clear();
                    cboFilterCity.Items.AddRange(new object[]
                    {
                        "HCM",
                        "Ha Noi",
                        "Nha Trang",
                        "Long Xuyen"
                    });
                    break;
                case 1:
                    cboFilterCity.Items.Clear();
                    cboFilterCity.Items.AddRange(new object[]
                    {
                        "Bangkok",
                        "Chiang Mai",
                        "Phuket"
                    });
                    break;
                case 2:
                    cboFilterCity.Items.Clear();
                    cboFilterCity.Items.AddRange(new object[]
                    {
                        "Tokyo",
                        "Hiroshima",
                        "Nagasaki"
                    });
                    break;
                case 3:
                    cboFilterCity.Items.Clear();
                    cboFilterCity.Items.AddRange(new object[]
                    {
                        "Wuhan",
                        "Beijing",
                        "Changsha"
                    });
                    break;
                default:
                    break;
            }
        }
    }
}
