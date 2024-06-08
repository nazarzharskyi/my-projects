namespace OnlineShop.EntityServices
{
    public class CommonEntityService<T>
    {
        private List<T> list = new();
        public string GetListType()
        {
            return list.AsQueryable().ElementType.Name;
        }

        public string OutputList(List<T> list)
        {
            if (list.Count == 0)
                return $"No {GetListType()} in the list.";

            string result = $":\n";
            foreach (var item in list)
            {
                result += item.ToString() + "\n";
            }
            return result;
        }



    }
}
