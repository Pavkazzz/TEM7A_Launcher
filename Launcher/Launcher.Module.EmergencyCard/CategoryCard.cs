namespace Launcher.Module.EmergencyCard
{
    public class CategoryCard
    {
        public CategoryCard()
        {
        }

        public CategoryCard(string Category_name)
        {
            CategoryName = Category_name;
        }

        public string CategoryName { get; private set; }
    }
}