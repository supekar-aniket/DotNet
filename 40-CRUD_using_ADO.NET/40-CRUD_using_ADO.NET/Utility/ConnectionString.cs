namespace _40_CRUD_using_ADO.NET.Utility
{
    public static class ConnectionString
    {
        private static string cs = "Server=DESKTOP-K0LK76T\\SQLEXPRESS; Database=CRUDUsingADONET; Trusted_Connection=true;TrustServerCertificate=true";

        public static string dbcs { get => cs; }
    }
}
