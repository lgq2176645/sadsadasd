namespace Tensee.Banch.DictionaryData
{
    public class MoveDicInput
    {
        public int Id { get; set; }

        /// <summary>
        /// 排序 可直接赋值
        /// </summary>
        public int? Sort { get; set; }
        /// <summary>
        /// 是否上移  true 上移 false 下移
        /// </summary>
        public bool IsUp { get; set; }
    }
}