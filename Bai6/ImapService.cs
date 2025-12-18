using MailKit.Net.Imap;
using MailKit;
using MailKit.Search;
using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bai6
{
    public class ImapService
    {
        private ImapClient _client;

        public ImapService()
        {
            _client = new ImapClient();
        }

        public bool IsConnected => _client.IsConnected;
        public bool IsAuthenticated => _client.IsAuthenticated;

        public async Task ConnectAsync(string host, int port, bool useSsl)
        {
            if (!_client.IsConnected)
            {
                await _client.ConnectAsync(host, port, useSsl);
            }
        }

        public async Task AuthenticateAsync(string username, string password)
        {
            if (_client.IsConnected && !_client.IsAuthenticated)
            {
                await _client.AuthenticateAsync(username, password);
            }
        }

        public async Task<List<UniqueId>> GetRecentEmailIdsAsync(int limit = 100)
        {
            if (!_client.IsConnected || !_client.IsAuthenticated) return new List<UniqueId>();

            var inbox = _client.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadOnly);

            // Get IDs of recent messages, sorted by date descending
            var uids = await inbox.SearchAsync(SearchQuery.All);
            var recentUids = new List<UniqueId>();

            // Get last 'limit' emails (fetching from end of list)
            int start = uids.Count - 1;
            int end = start - limit + 1;
            if (end < 0) end = 0;

            for (int i = start; i >= end; i--)
            {
                recentUids.Add(uids[i]);
            }

            return recentUids;
        }

        public async Task<List<IMessageSummary>> GetHeadersAsync(List<UniqueId> uids)
        {
             if (!_client.IsConnected || !_client.IsAuthenticated) return new List<IMessageSummary>();
             
             var inbox = _client.Inbox;
             // Fetch only Envelope (Subject, From, Date) to be fast
             var summaries = await inbox.FetchAsync(uids, MessageSummaryItems.Envelope | MessageSummaryItems.UniqueId);
             
             return new List<IMessageSummary>(summaries);
        }

        public async Task<MimeMessage> GetMessageAsync(UniqueId uid)
        {
            if (!_client.IsConnected || !_client.IsAuthenticated) return null;
            return await _client.Inbox.GetMessageAsync(uid);
        }

        public async Task DisconnectAsync()
        {
            if (_client.IsConnected)
            {
                await _client.DisconnectAsync(true);
            }
        }
    }
}
