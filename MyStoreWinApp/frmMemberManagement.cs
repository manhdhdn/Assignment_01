using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.DataAccess;
using DataAccess.Repository;
using BusinessObject;
namespace MyStoreWinApp
{
    public partial class frmMemberManagement : Form
    {
        public frmMemberManagement()
        {
            InitializeComponent();
        }
        public IMemberRepository? MemberRepository { get; set; }

        public bool AdminOrMember { get; set; }

        public MemberObject? MemberInfo { get; set; }
        
    }
}
