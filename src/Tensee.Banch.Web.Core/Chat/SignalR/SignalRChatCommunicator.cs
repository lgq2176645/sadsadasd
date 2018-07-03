#if FEATURE_SIGNALR_ASPNETCORE
using System.Collections.Generic;
using System.IO;
using Abp;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.ObjectMapping;
using Abp.RealTime;
using Castle.Core.Logging;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Tensee.Banch.Chat;
using Tensee.Banch.Chat.Dto;
using Tensee.Banch.Friendships;
using Tensee.Banch.Friendships.Dto;

namespace Tensee.Banch.Web.Chat.SignalR
{
    public class SignalRChatCommunicator : IChatCommunicator, ITransientDependency
    {
        /// <summary>net461
        /// Reference to the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        private readonly IObjectMapper _objectMapper;

        private static IHubContext<ChatNoAnnoy.ChatNoAnnoy> ChatHub;

        public SignalRChatCommunicator(IObjectMapper objectMapper, IHubContext<ChatNoAnnoy.ChatNoAnnoy> hubContext)
        {
            _objectMapper = objectMapper;
            Logger = NullLogger.Instance;
            ChatHub = hubContext;
            Logger.Debug("SignalR Hub:" + Newtonsoft.Json.JsonConvert.SerializeObject(ChatHub));
        }

        public void SendMessageToClient(IReadOnlyList<IOnlineClient> clients, ChatMessage message)
        {
            Logger.Debug("Message:" + message.Message + "count:" + clients.Count);
            foreach (var client in clients)
            {
                Logger.Debug("client:" + JsonConvert.SerializeObject(client));
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null)
                {
                    return;
                }

                signalRClient.SendAsync("getChatMessage", _objectMapper.Map<ChatMessageDto>(message));
            }
        }

        public void SendFriendshipRequestToClient(IReadOnlyList<IOnlineClient> clients, Friendship friendship, bool isOwnRequest, bool isFriendOnline)
        {
            foreach (var client in clients)
            {
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null)
                {
                    return;
                }

                var friendshipRequest = _objectMapper.Map<FriendDto>(friendship);
                friendshipRequest.IsOnline = isFriendOnline;

                //signalRClient.getFriendshipRequest(friendshipRequest, isOwnRequest);
            }
        }

        public void SendUserConnectionChangeToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user, bool isConnected)
        {
            foreach (var client in clients)
            {
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null)
                {
                    continue;
                }

                //signalRClient.getUserConnectNotification(user, isConnected);
            }
        }

        public void SendUserStateChangeToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user, FriendshipState newState)
        {
            foreach (var client in clients)
            {
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null)
                {
                    continue;
                }

                //signalRClient.getUserStateChange(user, newState);
            }
        }

        public void SendAllUnreadMessagesOfUserReadToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user)
        {
            foreach (var client in clients)
            {
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null)
                {
                    continue;
                }

                //signalRClient.getallUnreadMessagesOfUserRead(user);
            }
        }

        public void SendReadStateChangeToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user)
        {
            foreach (var client in clients)
            {
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null)
                {
                    continue;
                }

                //signalRClient.GetReadStateChange(user);
            }
        }

        private IClientProxy GetSignalRClientOrNull(IOnlineClient client)
        {
            var signalRClient = ChatHub.Clients.Client(client.ConnectionId);
            if (signalRClient == null)
            {
                Logger.Debug("Can not get chat user " + client.UserId + " from SignalR hub!");
                return null;
            }

            return signalRClient;
        }
    }
}
#endif