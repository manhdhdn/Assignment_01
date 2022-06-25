using BusinessObject;
using DataAccess.DataAccess;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public bool Login(string username, string password) => MemberDBContext.Login(username, password);

        public IEnumerable<MemberObject> GetMembers()
        {
            throw new NotImplementedException();
        }

        public MemberObject GetMember(int memberID, string? email, string? password) => MemberDBContext.Instance.GetMember(memberID, email, password);

        public void InsertMember(MemberObject member) => MemberDBContext.Instance.AddNew(member);

        public void UpdateMember(MemberObject member)
        {
            throw new NotImplementedException();
        }

        public void DeleteMember(int memberID)
        {
            throw new NotImplementedException();
        }
    }
}
