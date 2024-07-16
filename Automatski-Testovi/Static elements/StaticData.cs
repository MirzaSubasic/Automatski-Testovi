namespace Automatski_Testovi.Static_elements
{
    public class StaticData
    {
        public string StandardUser { get; set; } = "standard_user";
        public string LockedOutUser { get; set; } = "locked_out_user";
        public string ProblemUser { get; set; } = "problem_user";
        public string PerformanceGlitchUser { get; set; } = "performance_glitch_user";
        public string ErrorUser { get; set; } = "error_user";
        public string VisualUser { get; set; } = "visual_user";


        public string Password { get; set; } = "secret_sauce";


        public string LoginURL { get; set; } = "https://www.saucedemo.com/";
        public string InventoryURL { get; set; } = "https://www.saucedemo.com/inventory.html";
        public string CartUrl { get; set; } = "https://www.saucedemo.com/cart.html";
    }
}
