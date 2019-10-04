using GraphQlSample.Entities;
using GraphQL.Types;

namespace GraphQlSample.Schema
{
    public class ProductTypeEnum : EnumerationGraphType
    {
        public ProductTypeEnum()
        {
            Name = "ProductType";
            Description = "The type of the product";

            AddValue(ProductType.Mobile.ToString(), "Mobile device", (int)ProductType.Mobile);
            AddValue(ProductType.MusicPlayer.ToString(), "Music player", (int)ProductType.MusicPlayer);
            AddValue(ProductType.PersonalComputer.ToString(), "Personal Computer", (int)ProductType.PersonalComputer);
            AddValue(ProductType.Tablet.ToString(), "Tablet", (int)ProductType.Tablet);
        }
    }
}