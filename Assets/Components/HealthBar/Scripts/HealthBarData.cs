namespace Components.HealthBar.Scripts {
    public class HealthBarData {
        public float CurrentHealth { get; private set; }
        public bool IsVisible { get; private set; }
        
        public HealthBarData(float currentHealth, bool isVisible) {
            CurrentHealth = currentHealth;
            IsVisible = isVisible;
        }
    }
}