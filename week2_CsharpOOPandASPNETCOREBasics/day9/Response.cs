
class Response<T>
{
    public bool isSuccess {get; set;} = false;
    public string Text {get;}
    public T Data {get;set;}

    public Response(bool isSuccess, string text, T data)
    {
        isSuccess = isSuccess;
        Text = text;
        Data = data;

    }    
    
}