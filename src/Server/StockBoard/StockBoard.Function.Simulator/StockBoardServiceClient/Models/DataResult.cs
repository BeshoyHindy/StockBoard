namespace StockBoard.Function.Simulator.StockBoardServiceClient.Models
{
    public class DataResult<T> 
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}