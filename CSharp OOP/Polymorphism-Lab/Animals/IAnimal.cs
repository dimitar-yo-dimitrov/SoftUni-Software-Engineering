namespace Animals
{
    interface IAnimal
    {
        public string Name { get; set; }
        
        public string FavouriteFood { get; set; }

        public string ExplainSelf();
    }
}
