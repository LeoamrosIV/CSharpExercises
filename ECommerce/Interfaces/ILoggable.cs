namespace ECommerce
{
    interface ILoggable
    {
        bool Login(string email, string password);
        void Logout();
    }
}