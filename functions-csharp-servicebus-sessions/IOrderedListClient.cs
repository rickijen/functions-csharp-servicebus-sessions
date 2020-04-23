using System.Threading.Tasks;

namespace Edwards.Function
{
    public interface IOrderedListClient
    {
        Task PushData(string key, string value);
    }
}