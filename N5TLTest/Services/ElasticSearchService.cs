using Confluent.Kafka;
using Elastic.Clients.Elasticsearch;
using N5TLTest.Commands.Permissions;
using N5TLTest.Handlers.ports;

namespace N5TLTest.Services
{
    public class ElasticSearchService : ISearchEngineService
    {
        private const string INDEX_NAME = "permission-index";
        ElasticsearchClient _elasticsearchClient;
        public ElasticSearchService()
        {
            _elasticsearchClient = new ElasticsearchClient(new Uri("http://localhost:9200"));
        }

        public async Task AddToIndex(AddPermissionCommand command) {
            var indexExist = _elasticsearchClient.Indices.Exists(INDEX_NAME).Exists;
            if (!indexExist) {
                var createdIndex = await _elasticsearchClient.Indices.CreateAsync(INDEX_NAME);
            }

            var response = await _elasticsearchClient.IndexAsync(command, INDEX_NAME);
        }
    }
}
