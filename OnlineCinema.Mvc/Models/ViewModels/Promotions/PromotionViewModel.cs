namespace OnlineCinema.Mvc.Models.ViewModels.Promotions
{
    public class PromotionViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ButtonText { get; set; }
        public string DisplayName { get; set; }
    }
}
