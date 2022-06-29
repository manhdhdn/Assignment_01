using BusinessObject;
using DataAccess.DataAccess;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public bool Login(string email, string password) => MemberDBContext.Login(email, password);

        public IEnumerable<MemberObject> GetMembers(string? memberName, string? country, string? city) => MemberDBContext.Instance.GetMembers(memberName, country, city);   

        public MemberObject GetMember(int memberID, string? email, string? password) => MemberDBContext.Instance.GetMember(memberID, email, password);

        public void InsertMember(MemberObject member) => MemberDBContext.Instance.AddNew(member);

        public void UpdateMember(MemberObject member) => MemberDBContext.Instance.Update(member);          

        public void DeleteMember(int memberID) => MemberDBContext.Instance.Remove(memberID);
        
    }
}
