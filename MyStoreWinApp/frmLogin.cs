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
     


    private void frmLogin_FormClosed(object sender, FormClosedEventArgs e) => Close();

    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (MemberRepository.Login(txtEmail.Text, txtPassword.Text))
        {
            frmMemberManagement frmMemberManagement = new frmMemberManagement
            {
                Text = "Member Management",
                MemberRepository = MemberRepository,
                InsertOrUpdate = true
            };
            frmMemberManagement.ShowDialog();
        }
        else
        {
            var memberInfo = MemberRepository.GetMember(0, txtEmail.Text, txtPassword.Text);

            if (memberInfo != null)
            {
                frmMemberDetails frmMemberDetails = new frmMemberDetails
                {
                    Text = memberInfo.MemberName + " details",
                    MemberRepository = MemberRepository,
                    MemberInfo = memberInfo,
                    InsertOrUpdate = false
                };
                frmMemberDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect Email or Password");
            }
        }
    }
}