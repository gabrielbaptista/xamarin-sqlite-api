using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SQLite;


namespace AppSample.Helpers
{
    public static class SqliteConnectionHelper
    {
        //Definição da conexão e o nome do banco de dados
        private static SQLiteAsyncConnection _connection;
        public const string DbFileName = "sample.db";

        public static SQLiteAsyncConnection GetConnection()
        {
            if (_connection == null)
            {
                //Cria uma pasta base local para o dispositivo
                var path = new LocalRootFolder();
                //Cria o arquivo
                var arquivo = path.CreateFile(DbFileName, CreationCollisionOption.OpenIfExists);
                //Abre o BD
                _connection = new SQLiteAsyncConnection(arquivo.Path);
            }
            return _connection;
        }
    }
}
