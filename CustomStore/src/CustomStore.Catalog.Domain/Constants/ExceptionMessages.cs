namespace CustomStore.Catalog.Domain.Constants
{
    internal static class ExceptionMessages
    {
        // Product
        internal const string NameValidationMessage = "Name cannot be empty";
        internal const string DescriptionValidationMessage = "Description cannot be empty";
        internal const string CategoryIdValidationMessage = "Category Id cannot be empty";
        internal const string PriceValidationMessage = "Price cannot be less or equals than 0";
        internal const string QuantityValidationMessage = "Quantity cannot be less than 0";
        internal const string ImageValidationMessage = "Image cannot be empty";

        // Dimensions
        internal const string HeightValidationMessage = "Height should be greater than 0";
        internal const string WidthValidationMessage = "Width should be greater than 0";
        internal const string DepthValidationMessage = "Depth should be greater than 0";
    }
}
