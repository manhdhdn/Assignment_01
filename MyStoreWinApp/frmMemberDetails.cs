using BusinessObject;
using DataAccess.Repository;

namespace MyStoreWinApp
{
    public partial class FrmMemberDetails : Form
    {
        public IMemberRepository MemberRepository { get; set; } = null!;
        public bool InsertOrUpdate { get; set; }
        public MemberObject MemberInfo { get; set; } = null!;

        public FrmMemberDetails()
        {
            InitializeComponent();
        }

        private void FrmMemberDetails_Load(object sender, EventArgs e)
        {
            txtMemberID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtMemberID.Text = MemberInfo.MemberID.ToString();
                txtMemberName.Text = MemberInfo.MemberName;
                txtEmail.Text = MemberInfo.Email;
                txtPassword.Text = MemberInfo.Password;
                cboCountry.Text = MemberInfo.Country.Trim();
                cboCity.Text = MemberInfo.City.Trim();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new MemberObject
                {
                    MemberID = int.Parse(txtMemberID.Text),
                    MemberName = txtMemberName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Country = cboCountry.Text,
                    City = cboCity.Text
                };

                if (InsertOrUpdate == false)
                {
                    MemberRepository.InsertMember(member);
                }
                else
                {
                    MemberRepository.UpdateMember(member);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new member" : "Update member profile");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) => Close();

        private void CboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCity.SelectedIndex = -1;

            switch (cboCountry.SelectedIndex)
            {
                case 0:
                    cboCity.Items.Clear();
                    cboCity.Items.AddRange(new object[]
                    {
                        "HCM",
                        "Ha Noi",
                        "Nha Trang",
                        "Long Xuyen"
                    });
                    break;
                case 1:
                    cboCity.Items.Clear();
                    cboCity.Items.AddRange(new object[]
                    {
                        "Bangkok",
                        "Chiang Mai",
                        "Phuket"
                    });
                    break;
                case 2:
                    cboCity.Items.Clear();
                    cboCity.Items.AddRange(new object[]
                    {
                        "Tokyo",
                        "Hiroshima",
                        "Nagasaki"
                    });
                    break;
                case 3:
                    cboCity.Items.Clear();
                    cboCity.Items.AddRange(new object[]
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
