
class Connection : IDisposable
{
    Socket? activeSocket = null;
 
    // для открытия сетевого подключения передаем сокет
    public void Open(Socket? socket)
    {
        if(activeSocket != socket)  // проверяем сокет
        {
            Close();    // закрываем сокет, если ранее был установлен другой сокет
            activeSocket = socket;
            activeSocket?.IsOpened = true;  // открываем новый сокет
            Console.WriteLine("Подключение открыто. Можно посылать пакеты по сети");
        }
    }
    // закрываем сокет
    public void Close()
    {
        if(activeSocket is not null)
        {
            activeSocket?.IsOpened = false;
            Console.WriteLine("Подключение закрыто...");
        }
    }
    public void Dispose()
    {
        Close();
    }
}