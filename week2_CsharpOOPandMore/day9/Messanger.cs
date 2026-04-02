
class Messanger<T, P> 
    where T : Message 
    where P : Person
{
    public void SendMessage(P sender, P receiver, T message)
    {
        Console.WriteLine($"Sender: {sender.Name}");
        Console.WriteLine($"Receiver: {receiver.Name}");
        Console.WriteLine($"Message: {message.Text}");
    }
}