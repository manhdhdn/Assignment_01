using DataAccess.Repository;
using DataAccess.DataAccess;

namespace MyStoreWinApp;

public partial class FrmLogin : Form
{
    private readonly IMemberRepository memberRepository = new MemberRepository();

    public FrmLogin()
    {
        InitializeComponent();
    }

    private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e) => Close();

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        if (memberRepository.Login(txtEmail.Text, txtPassword.Text))
        {
            this.Hide();

            FrmMemberManagement frmMemberManagement = new()
            {
                Text = "Member Management",
                MemberRepository = memberRepository
            };
            frmMemberManagement.ShowDialog();

            this.Close();
        }
        else
        {
            var memberInfo = memberRepository.GetMember(0, txtEmail.Text, txtPassword.Text);

            if (memberInfo != null)
            {
                this.Hide();

                FrmMemberDetails frmMemberDetails = new()
                {
                    Text = " Member Details",
                    MemberRepository = memberRepository,
                    MemberInfo = memberInfo,
                    InsertOrUpdate = true
                };
                frmMemberDetails.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Email or Password");
            }
        }
    }

    private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnLogin.PerformClick();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
    }
}