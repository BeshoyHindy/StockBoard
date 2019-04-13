// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

using Newtonsoft.Json;

namespace StockBoard.Function.Simulator.StockBoardServiceClient.Models
{
    public partial class StockViewModel
    {
        /// <summary>
        /// Initializes a new instance of the StockViewModel class.
        /// </summary>
        public StockViewModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the StockViewModel class.
        /// </summary>
        public StockViewModel(System.Guid? id = default(System.Guid?), string name = default(string), double? price = default(double?))
        {
            Id = id;
            Name = name;
            Price = price;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public System.Guid? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public double? Price { get; set; }

    }
}
