using DataAccess.Repository;
using DataAccess.DataAccess;

namespace MyStoreWinApp;

public partial class frmLogin : Form
{
    public IMemberRepository MemberRepository = new MemberRepository();
    public frmLogin()
    {
        InitializeComponent();
    }
     
    private void bntLogin_Click(object sender, EventArgs e)
    {
        if (MemberRepository.Login(txtEmail.Text, txtPassword.Text))
        {
            frmMemberManagement frmMemberManagement = new frmMemberManagement
            {
                Text = "Member Management",
                MemberRepository = MemberRepository,
                AdminOrMember = true,
                MemberInfo = MemberRepository.GetMember(0, txtEmail.Text, txtPassword.Text)
            };
            frmMemberManagement.ShowDialog();
        }
        else
        {
            if (MemberRepository.GetMember(0, txtEmail.Text, txtPassword.Text) != null)
            {
                frmMemberManagement frmMemberManagement = new frmMemberManagement
                {
                    Text = "Member Infomation",
                    MemberRepository = MemberRepository,
                    AdminOrMember = false,
                    MemberInfo = MemberRepository.GetMember(0, txtEmail.Text, txtPassword.Text)
                };
                frmMemberManagement.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect Email or Password");
            }
        }
    }
   

    private void bntClose_Click(object sender, EventArgs e) => Close();

    private void frmLogin_FormClosed(object sender, FormClosedEventArgs e) => Close();

    private void frmLogin_Load(object sender, EventArgs e)
    {

    }
    private void txtPassword_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {

    }
}