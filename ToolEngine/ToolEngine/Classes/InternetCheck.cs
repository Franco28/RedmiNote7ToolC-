
namespace Franco28Tool.Engine
{
    public class InternetCheck
    {
        public static bool Ping(string host)
        {
            System.Net.NetworkInformation.Ping pp = new System.Net.NetworkInformation.Ping();
            if (pp.Send(host, 500).Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
