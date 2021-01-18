namespace ECommerce
{
    interface IQueryable
    {
        void SearchInFile(string path, string searchTerm);
        void WriteToFile(string path);
        string ToInlineString();
    }
}