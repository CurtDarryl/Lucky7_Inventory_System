namespace Lucky7_Inventory_System_Application.Services;

public static class EntityUpdater
{
    public static void UpdateProperty<T>(Action<T> setProperty, T currentValue, T newValue)
    {
        if (newValue != null && !newValue.Equals(default(T)) && !newValue.Equals(currentValue))
        {
            setProperty(newValue);
        }
    }
}
