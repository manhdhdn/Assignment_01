using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        bool Login(string username, string password);
        IEnumerable<MemberObject> GetMembers();
        MemberObject GetMember(int memberID, string? email, string? password);
        void InsertMember(MemberObject member);
        void UpdateMember(MemberObject member);
        void DeleteMember(int memberID);
    }
}
