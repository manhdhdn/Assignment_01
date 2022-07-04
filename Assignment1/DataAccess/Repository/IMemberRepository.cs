using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        bool Login(string email, string password);
        IEnumerable<MemberObject> GetMembers(string? memberName, string? country, string? city);
        MemberObject GetMember(int memberID, string? email, string? password);
        void InsertMember(MemberObject member);
        void UpdateMember(MemberObject member);
        void DeleteMember(int memberID);
    }
}
