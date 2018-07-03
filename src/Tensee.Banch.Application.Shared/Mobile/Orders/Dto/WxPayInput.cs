namespace Tensee.Banch.Mobile.Orders.Dto
{
    public class WxPayInput
    {
        public string SessionId { get; set; }
        public int OrderAmount { get; set; }
        public int OrderId { get; set; }
    }
}
