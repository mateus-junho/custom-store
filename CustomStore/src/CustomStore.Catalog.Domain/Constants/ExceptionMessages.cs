namespace CustomStore.Catalog.Domain.Constants
{
    public static class ExceptionMessages
    {
        // Product
        public const string NameValidationMessage = "Name cannot be empty";
        public const string DescriptionValidationMessage = "Description cannot be empty";
        public const string CategoryIdValidationMessage = "Category Id cannot be empty";
        public const string PriceValidationMessage = "Price cannot be less or equals than 0";
        public const string QuantityValidationMessage = "Quantity cannot be less than 0";
        public const string ImageValidationMessage = "Image cannot be empty";

        // Dimensions
        public const string HeightValidationMessage = "Height should be greater than 0";
        public const string WidthValidationMessage = "Width should be greater than 0";
        public const string DepthValidationMessage = "Depth should be greater than 0";
    }
}
