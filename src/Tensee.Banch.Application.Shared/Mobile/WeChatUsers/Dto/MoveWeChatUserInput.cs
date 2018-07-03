namespace Tensee.Banch.Mobile.WeChatUsers.Dto
{
    public class MoveWeChatUserInput
    {
        /// <summary>
        /// 本用户Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 新的父节点Id
        /// </summary>
        public int? NewParentId { get; set; }

    }
}